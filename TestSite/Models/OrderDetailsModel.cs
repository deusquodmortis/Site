using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestSite.Entity;

namespace TestSite.Models
{
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }
        public string Username { get; set; }      
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }

        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string PostaKodu { get; set; }
        public virtual List<OrderLineModel> OrderLines { get; set; }
    }

    public class OrderLineModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}