using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.DataAccess;

namespace Store.WebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        private readonly ProductRepository _productRepo;

        public ProductController()
        {
            _productRepo = new ProductRepository();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}