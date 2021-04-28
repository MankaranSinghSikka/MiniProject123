using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Dynamic;

using System.Web.Mvc;
using SharingEconomyPlatform.Models;
namespace SharingEconomyPlatform.Controllers
{
    public class HomeController : Controller
    {
        protected ApplicationDbContext _context { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        public HomeController()
        {
            this._context = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this._context));
        }
        [Authorize(Roles ="Customer")]
        public ActionResult AddInCart(int ProId, string CusId)
        {

            Cart c = new Cart() { Customer = _context.Users.Where(u => u.Id == CusId).FirstOrDefault(), Product = _context.Products.Where(p => p.Id == ProId).FirstOrDefault() };
            _context.Carts.Add(c);
            _context.SaveChanges();
            return RedirectToAction("Product");
        }

        [Authorize(Roles = "Customer")]
        public ActionResult RemoveFromCart(int ProId, string CusId)
        {

               Cart t = _context.Carts.Where(c => c.Customer.Id == CusId && c.Product.Id == ProId).FirstOrDefault();
            _context.Carts.Remove(t);
            _context.SaveChanges();
            return RedirectToAction("ViewCart");
        }

        public ActionResult temp()
        {
           var data= _context.Products.FirstOrDefault();
            return View(data);
        }

        [Authorize(Roles = "Customer")]
        public ActionResult ViewCart()
        {
            return View();
        }

        public ActionResult Remove(string product)
        {
            return RedirectToAction("Product");

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Customer")]
        public ActionResult BuyNowProduct( int product)
        {
            var data = _context.Products.Where(p => p.Id == product).FirstOrDefault();

            return View(data);
        }
        [Authorize(Roles = "Customer")]
        public ActionResult BuyNowService( int product)
        {
            var data = _context.Services.Where(p => p.Id == product).FirstOrDefault();

            return View(data);
        }


        [Authorize(Roles = "Customer")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
        public ActionResult Product()
        {
            var products = _context.Products.ToList();
            var categorys = _context.Categories.ToList();
            var data = from ps in products
                       join cs in categorys
                       on ps.Category.Id equals cs.Id
                       join ur in _context.Users
                       on ps.Vendor.Id equals ur.Id 
                       select new productCatView{ product = ps, category =  cs, vendor = ur };
            data = data.ToList();
            return View(data);
        }

        public ActionResult Service()
        {
            var service = _context.Services.ToList();
            var categorys = _context.Categories.ToList();
            var data = from ss in service
                       join cs in categorys
                       on ss.Category.Id equals cs.Id
                       join ur in _context.Users
                       on ss.Vendor.Id equals ur.Id
                       select new serviceCatView { service = ss, category = cs, vendor = ur };
            data = data.ToList();
            

            return View(data);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Category()
        {
           _context = new ApplicationDbContext();
            var data = _context.Categories.ToList();
            return View(data);
        }

        public ActionResult AddCategory()
        {
            return View(new Category());
        }

        [HttpPost]
        public ActionResult AddCategory(Category cat)
        {
            _context.Categories.Add(cat);
            _context.SaveChanges();
            return RedirectToAction("Category", "Home");
        }
        
        [Authorize(Roles = "Admin,Vendor")]
        public ActionResult AddProduct()
        {
            return View(new ProductView());
        }
        [Authorize(Roles ="Admin,Vendor")]
        public ActionResult AddService()
        {
            return View(new ServiceView());
        }

        [Authorize(Roles = "Admin,Vendor")]
        [HttpPost]
        public ActionResult AddProduct(ProductView product)
        {
            _context.Dispose();
            Product temp = new Product();
            var con = new ApplicationDbContext();
            temp.Name = product.Name;
            temp.Stock = product.Stock;
            temp.Price = product.Price;
            temp.AvailableLocation = product.AvailableLocation;
            temp.Category =con.Categories.FirstOrDefault(c => c.Name == product.Category);
            //temp.Vendor = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            temp.Vendor = con.Users.Where(u =>u.Id == product.Vendor).FirstOrDefault();
            con.Products.Add(temp);
            con.SaveChanges();
            return RedirectToAction("Product", "Home");
        }

        [Authorize(Roles = "Admin,Vendor")]
        [HttpPost]
        public ActionResult AddSerevice(ServiceView product)
        {
            _context.Dispose();
            Service temp = new Service();
            var con = new ApplicationDbContext();
            temp.Name = product.Name;
            temp.Available = product.Available;
            temp.Price = product.Price;
            temp.AvailableLocation = product.AvailableLocation;
            temp.Category = con.Categories.FirstOrDefault(c => c.Name == product.Category);
            temp.Vendor = con.Users.Where(u => u.Id == product.Vendor).FirstOrDefault();
            con.Services.Add(temp);
            con.SaveChanges();
            return RedirectToAction("Service", "Home");
        }
    }
}