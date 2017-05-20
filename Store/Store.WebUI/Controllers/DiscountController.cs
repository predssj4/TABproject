using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.DataAccess.Repositories;
using Store.DataAccess.ViewModels;

namespace Store.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        // GET: Discount

        private DiscountRepository _discountrepo;


        public DiscountController()
        {
            _discountrepo = new DiscountRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddDiscount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDiscount(DiscountViewModel model)
        {
            var result = _discountrepo.AddDiscount(model);
            return View("Info", (object) result);
        }

        [HttpGet]
        public ActionResult GetDiscounts()
        {
            return View(_discountrepo.GetDiscounts());
        }
    }
}