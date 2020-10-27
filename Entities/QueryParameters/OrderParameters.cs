using ERPBackend.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPBackend.Entities.QueryParameters
{
    public class OrderParameters
    {
        public int SalesmanId { get; set; }
        public int WarehousemanId { get; set; }
    }
}