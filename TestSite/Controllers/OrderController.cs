using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSite.Entity;
using TestSite.Models;

namespace TestSite.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        DataContext db=new DataContext();
        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrderModel()
            {
                Id=i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.OrderLines.Count
            }).ToList();

            return View(orders);
        }

        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    Username =i.Username,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    AdresBasligi = i.AdresBasligi,
                    Adres = i.Adres,
                    Il = i.Il,
                    Ilce = i.Ilce,
                    PostaKodu = i.PostaKodu,
                    OrderLines = i.OrderLines.Select(a => new OrderLineModel()
                    {
                        ProductId = a.ProductId,
                        ProductName = a.Product.Name,
                        Image = a.Product.Image,
                        Quantity = a.Quantity,
                        Price = a.Price
                    }).ToList()
                }).FirstOrDefault();
            return View(entity);
        }

        public ActionResult UpdateOrderState(int OrderId,EnumOrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);
            if (order !=null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();
                TempData["message"] = "Bilgileriniz kayıt edildi.";
                return RedirectToAction("Details", new {id = OrderId});
            }
            return RedirectToAction("Index");
        }
    }
}