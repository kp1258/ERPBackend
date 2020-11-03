using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities.Dtos.OrderDtos;
using ERPBackend.Entities.Models;
using ERPBackend.Entities.Models.Additional;
using ERPBackend.Entities.QueryParameters;

namespace ERPBackend.Services
{
    public class OrderManagementService : IOrderManagementService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IBlobStorageService _service;

        public OrderManagementService(IRepositoryWrapper repositoryWrapper, IBlobStorageService service)
        {
            _repository = repositoryWrapper;
            _service = service;
        }

        public async Task CompleteOrder(int orderId)
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

        public async Task<IEnumerable<MissingProduct>> GetAllMissingProducts()
        {
            var standardOrderItems = await _repository.StandardOrderItem.GetAllItemsFromActiveOrders();
            Console.WriteLine(standardOrderItems.FirstOrDefault());
            var orderedProducts = standardOrderItems
                            .GroupBy(i => i.StandardProductId)
                            .Select(i => new { productId = i.Key, quantity = i.Sum(i => i.Quantity) });
            List<MissingProduct> missingProducts = new List<MissingProduct>();
            var items = await _repository.ProductWarehouseItem.GetAllItemsAsync();

            foreach (var orderedProduct in orderedProducts)
            {
                var item = items.FirstOrDefault(i => i.StandardProductId.Equals(orderedProduct.productId));
                if (item.Quantity < orderedProduct.quantity)
                {
                    var missingQuantity = orderedProduct.quantity - item.Quantity;
                    var missingProduct = new MissingProduct
                    {
                        StandardProductId = item.StandardProductId,
                        StandardProduct = item.StandardProduct,
                        Quantity = missingQuantity
                    };
                    missingProducts.Add(missingProduct);
                }

            }
            return missingProducts;
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

        public async Task PlaceOrder(OrderCreateDto orderDto, Order orderEntity)
        {
            if (orderEntity.Type == OrderType.Custom)
            {
                var orderItems = orderEntity.CustomOrderItems;
                foreach (var item in orderItems)
                {
                    var customProduct = item.CustomProduct;
                    await _service.UploadOrderFilesAsync(customProduct.FileList);
                }
            }
            await _repository.SaveAsync();
        }
    }
}
