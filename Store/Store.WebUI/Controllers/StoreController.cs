using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.DataAccess;
using Store.DataAccess.Repositories;

namespace Store.WebUI.Controllers
{
    public class StoreController : Controller
    {

        private readonly StoreRepository _storeRepo;

        public StoreController()
        {
            _storeRepo = new StoreRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetStoreIncome()
        {
            var result = _storeRepo.GetStoresIncome();

            return View(result);
        }

        public ActionResult IncomeDetails(int id)
        {
            var result = _storeRepo.GetIncomeDetails(id);

            return View(result);
        }
    }
}