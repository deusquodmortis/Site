using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using TestSite.Entity;
using TestSite.Identity;
using TestSite.Models;

namespace TestSite.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db=new DataContext();
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);

        }
        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders
                .Where(i => i.Username == username)
                .Select(i => new UserOrderModel()
                {
                    Id = i.Id,
                    OrderNumber = i.OrderNumber,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    Total = i.Total
                }).OrderByDescending(i=>i.OrderDate).ToList();
            return View(orders);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    AdresBasligi = i.AdresBasligi,
                    Adres = i.Adres,
                    Il = i.Il,
                    Ilce = i.Ilce,
                    PostaKodu = i.PostaKodu,
                    OrderLines = i.OrderLines.Select(a=>new OrderLineModel()
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

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        // POST: Account
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //Kayıt İşlemleri
                ApplicationUser user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.Username;
                var result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    //kullanıcıyı oluşturduk ve rol atayacağız
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası.");
                }
            }

            return View(model);
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        // POST: Account
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Login İşlemleri
                var user = UserManager.Find(model.Username, model.Password);
                if (user != null)
                {
                    //var olan kullanıcıyı sisteme ekle.
                    //appcookie olusturup sisteme bırakıyoruz.

                    var authManager = HttpContext.GetOwinContext().Authentication;

                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    (authProperties).IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);
                    return RedirectToAction("Index", "Home");
                    if (string.IsNullOrEmpty(ReturnUrl))
                    {
                       return Redirect(ReturnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Kullanıcı girişi hatası.");
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}