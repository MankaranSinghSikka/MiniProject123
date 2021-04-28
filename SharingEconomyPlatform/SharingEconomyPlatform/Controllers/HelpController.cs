using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using SharingEconomyPlatform.Models;
    namespace SharingEconomyPlatform.Controllers
{
    public class HelpController : Controller
    {
        // GET: Help
        protected ApplicationDbContext _context;
        public HelpController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Requests()
        {
            var data = _context.Helprequests.ToList();
            return View(data);
        }
        public ActionResult Query()
        {
            return View(new HelpView());
        }
        [HttpPost]
        public ActionResult Query(HelpView r)
        {
            string id = User.Identity.GetUserId();
            var user = _context.Users.Where(u => u.Id == id).FirstOrDefault();
            var h = new Helprequest() { Status = 'R',Description=r.Description,Title=r.Title,Time=DateTime.Now,User=user };
            _context.Helprequests.Add(h);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}