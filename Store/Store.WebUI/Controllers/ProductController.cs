using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.DataAccess;
using Store.DataAccess.ViewModels;

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


        [HttpGet]
        public ActionResult AddProduct()
        {

            return View();
        }


        [HttpPost]
        public ActionResult AddProduct(ProductViewModel model)
        {
            var result =  _productRepo.AddProduct(model);

            return Content(result);

        }

        [HttpGet]
        public ActionResult GetProductsList()
        {
            var result = _productRepo.GetProductsList();

            return View(result);
        }

        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            var result = _productRepo.DeleteProduct(id);

            return View("Info", result);
        }
    }
}