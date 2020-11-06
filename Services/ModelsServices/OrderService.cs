using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.OrderDtos;
using ERPBackend.Entities.Models;
using ERPBackend.Entities.Models.Additional;
using ERPBackend.Entities.QueryParameters;

namespace ERPBackend.Services.ModelsServices
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IBlobStorageService _service;

        public OrderService(IRepositoryWrapper repositoryWrapper, IBlobStorageService service)
        {
            _repository = repositoryWrapper;
            _service = service;
        }

        public async Task AccepOrderToRealization(Order order, int warehousemanId)
        {
            order.WarehousemanId = warehousemanId;
            order.RealizationStartDate = DateTime.Now;

            _repository.Order.UpdateOrder(order);
            await _repository.SaveAsync();
        }

        public async Task CompleteOrder(Order order)
        {
            order.CompletionDate = DateTime.Now;
            await FulfillOrder(order.OrderId);
            _repository.Order.UpdateOrder(order);
            await _repository.SaveAsync();
        }

        public async Task FulfillOrder(int orderId)
        {
            var order = await _repository.Order.GetOrderByIdAsync(orderId);
            if (order.Type == OrderType.Standard)
            {
                var standardOrderItems = order.StandardOrderItems;
                foreach (var item in standardOrderItems)
                {
                    var warehouseItem = await _repository.ProductWarehouseItem.GetItemByProductIdAsync(item.StandardProductId);
                    warehouseItem.Quantity = warehouseItem.Quantity - item.Quantity;
                    _repository.ProductWarehouseItem.UpdateItem(warehouseItem);
                }
                await _repository.SaveAsync();
            }
        }

        public async Task<IEnumerable<OrderDetails>> GetAllOrderDetails(OrderParameters parameters)
        {
            var orders = await _repository.Order.GetAllActiveOrders(parameters);
            List<OrderDetails> orderDetailsList = new List<OrderDetails>();
            foreach (var order in orders)
            {
                var orderDetails = await GetOrderDetails(order.OrderId);
                orderDetailsList.Add(orderDetails);
            }
            return orderDetailsList;
        }

        public async Task<OrderDetails> GetOrderDetails(int orderId)
        {
            var items = await _repository.StandardOrderItem.GetAllItemsByOrder(orderId);
            var order = await _repository.Order.GetOrderDetailsByIdAsync(orderId);
            List<StandardOrderItemDetail> orderItemDetails = new List<StandardOrderItemDetail>();
            if (order.Type == OrderType.Standard)
            {
                var warehouseItems = await _repository.ProductWarehouseItem.GetAllItemsBaseAsync();

                foreach (var item in items)
                {
                    var orderItemDetail = new StandardOrderItemDetail
                    {
                        StandardOrderItemId = item.StandardOrderItemId,
                        StandardProductId = item.StandardProductId,
                        StandardProduct = item.StandardProduct,
                        Quantity = item.Quantity
                    };

                    var warehouseItem = warehouseItems.FirstOrDefault(i => i.StandardProductId.Equals(item.StandardProductId));
                    if (warehouseItem.Quantity < item.Quantity)
                    {
                        var missingQuantity = item.Quantity - warehouseItem.Quantity;
                        orderItemDetail.Status = OrderItemDetailStatus.Unavailable;
                        orderItemDetail.MissingQuantity = missingQuantity;
                    }
                    else
                    {
                        orderItemDetail.Status = OrderItemDetailStatus.Available;
                        orderItemDetail.MissingQuantity = 0;
                    }
                    orderItemDetails.Add(orderItemDetail);
                }
            }
            var orderDetails = new OrderDetails
            {
                OrderId = order.OrderId,
                PlacingDate = order.PlacingDate,
                RealizationStartDate = order.RealizationStartDate,
                CompletionDate = order.CompletionDate,
                Status = order.Status,
                Type = order.Type,
                ClientId = order.ClientId,
                Client = order.Client,
                SalesmanId = order.SalesmanId,
                Salesman = order.Salesman,
                WarehousemanId = order.WarehousemanId,
                Warehouseman = order.Warehouseman,
                CustomOrderItems = order.CustomOrderItems,
                StandardOrderItemDetails = orderItemDetails
            };
            return orderDetails;
        }

        public async Task PlaceOrder(Order orderEntity)
        {
            orderEntity.PlacingDate = DateTime.Now;
            orderEntity.Status = OrderStatus.Placed;
            _repository.Order.CreateOrder(orderEntity);
            await _repository.SaveAsync();
            if (orderEntity.Type == OrderType.Custom)
            {
                var orderItems = orderEntity.CustomOrderItems;
                foreach (var item in orderItems)
                {
                    item.OrderDate = DateTime.Now;
                    var customProduct = item.CustomProduct;
                    customProduct.OrderDate = DateTime.Now;
                    await _service.UploadOrderFilesAsync(customProduct.FileList);
                }
            }
            await _repository.SaveAsync();
        }
    }
}
