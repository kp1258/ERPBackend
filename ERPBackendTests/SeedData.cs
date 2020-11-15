using System;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;

namespace ERPBackendTests
{
    public static class SeedData
    {
        public static void InsertTestData(ERPContext erpContext)
        {
            var category = erpContext.StandardProductCategories.Find(1);
            var standardProduct1 = new StandardProduct { Name = "Produkt standardowy 1", Dimensions = "100x100", StandardProductCategoryId = 1, StandardProductCategory = category, Status = StandardProductStatus.Produced };
            var standardProduct2 = new StandardProduct { Name = "Produkt standardowy 2", Dimensions = "200x200", StandardProductCategoryId = 1, StandardProductCategory = category, Status = StandardProductStatus.Discontinued };
            erpContext.StandardProducts.Add(standardProduct1);
            erpContext.StandardProducts.Add(standardProduct2);

            erpContext.Users.Add(new User { Login = "ewa_f", Password = "password", FirstName = "Ewa", LastName = "Frankowska", PhoneNumber = "123456789", Email = "ewa_f@mail.com", Role = UserRole.Administrator, Status = UserStatus.Active });

            var standardProduct = erpContext.StandardProducts.Find(1);
            var standardProduct3 = erpContext.StandardProducts.Find(2);
            erpContext.ProductWarehouse.Add(new ProductWarehouseItem { StandardProductId = standardProduct.StandardProductId, StandardProduct = standardProduct, Quantity = 100 });
            erpContext.ProductWarehouse.Add(new ProductWarehouseItem { StandardProductId = standardProduct3.StandardProductId, StandardProduct = standardProduct3, Quantity = 100 });


            var client = erpContext.Clients.Find(2);
            var salesman = erpContext.Users.Find(2);

            // placed orders//
            //standard order
            var order2 = new Order { PlacingDate = DateTime.Now, Status = OrderStatus.Placed, Type = OrderType.Standard, ClientId = 2, Client = client, SalesmanId = 2, Salesman = salesman };
            erpContext.Orders.Add(order2);

            var stadnardOrderItem = new StandardOrderItem { OrderId = 2, Order = order2, StandardProductId = 1, StandardProduct = standardProduct, Quantity = 20 };
            var standardOrderItem2 = new StandardOrderItem { OrderId = 2, Order = order2, StandardProductId = 2, StandardProduct = standardProduct3, Quantity = 30 };
            erpContext.StandardOrderItems.Add(stadnardOrderItem);
            erpContext.StandardOrderItems.Add(standardOrderItem2);

            // orders in realization//
            //custom order
            var customProduct = new CustomProduct { Name = "Produkt na zamówienie", OrderDescription = "Opis", Status = CustomProductStatus.Ordered, OrderDate = DateTime.Now };
            var customProduct2 = new CustomProduct { Name = "Produkt na zamówienie 2", OrderDescription = "Opis", Status = CustomProductStatus.Ordered, OrderDate = DateTime.Now };
            erpContext.CustomProducts.Add(customProduct);
            erpContext.CustomProducts.Add(customProduct2);

            var order = new Order { PlacingDate = DateTime.Now, RealizationStartDate = DateTime.Now, Status = OrderStatus.InRealization, Type = OrderType.Custom, ClientId = 2, Client = client, SalesmanId = 2, Salesman = salesman };
            erpContext.Orders.Add(order);

            var customOrderItem = new CustomOrderItem { OrderId = 1, Order = order, CustomProductId = 1, CustomProduct = customProduct, Status = CustomOrderItemStatus.Ordered, Quantity = 10, OrderDate = DateTime.Now };
            var customOrderItem2 = new CustomOrderItem { OrderId = 2, Order = order, CustomProductId = 2, CustomProduct = customProduct, Status = CustomOrderItemStatus.Ordered, Quantity = 20, OrderDate = DateTime.Now };
            erpContext.CustomOrderItems.Add(customOrderItem);
            erpContext.CustomOrderItems.Add(customOrderItem2);

            // completed //
            //custom order
            var customProduct5 = new CustomProduct { Name = "Produkt na zamówienie 5", OrderDescription = "Opis", SolutionDescription = "Opis rozwiązania", Status = CustomProductStatus.Prepared, OrderDate = DateTime.Now, PreparationStartDate = DateTime.Now, PreparationCompletionDate = DateTime.Now, TechnologistId = 4 };
            var customProduct6 = new CustomProduct { Name = "Produkt na zamówienie 6", OrderDescription = "Opis", SolutionDescription = "Opis rozwiązania", Status = CustomProductStatus.Prepared, OrderDate = DateTime.Now, PreparationStartDate = DateTime.Now, PreparationCompletionDate = DateTime.Now, TechnologistId = 4 };
            erpContext.CustomProducts.Add(customProduct5);
            erpContext.CustomProducts.Add(customProduct6);

            var order3 = new Order { PlacingDate = DateTime.Now, RealizationStartDate = DateTime.Now, CompletionDate = DateTime.Now, Status = OrderStatus.Completed, Type = OrderType.Custom, ClientId = 2, Client = client, SalesmanId = 2, Salesman = salesman };
            erpContext.Orders.Add(order3);

            var customOrderItem7 = new CustomOrderItem { OrderId = 1, Order = order, CustomProduct = customProduct5, Status = CustomOrderItemStatus.Completed, Quantity = 10, OrderDate = DateTime.Now, ProductionStartDate = DateTime.Now, ProductionManagerId = 3 };
            var customOrderItem8 = new CustomOrderItem { OrderId = 2, Order = order, CustomProduct = customProduct6, Status = CustomOrderItemStatus.Completed, Quantity = 20, OrderDate = DateTime.Now, ProductionStartDate = DateTime.Now, ProductionManagerId = 3 };
            erpContext.CustomOrderItems.Add(customOrderItem);
            erpContext.CustomOrderItems.Add(customOrderItem2);

            erpContext.SaveChanges();
        }
    }
}