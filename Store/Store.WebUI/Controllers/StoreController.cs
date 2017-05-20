using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using Store.DataAccess;
using Store.DataAccess.Repositories;
using Store.DataAccess.ViewModels;

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
            return View((object)result);
        }

        
        public ActionResult IncomeDetails(int id)
        {
            var result = _storeRepo.GetIncomeDetails(id);
            return View((object)result);
        }


        [HttpGet]
        public ActionResult AddStore()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStore(StoreViewModel model)
        {
            string result = _storeRepo.AddStore(model);
            return View("Info", (object)result);
        }

        public ActionResult AddStoreHouse(int id = 0)
        {

            if (id == 0)
            {
                return View("Info", (object)"Brak podanego id");
            }

            var storeHouses = _storeRepo.GetAllStoreHouses();

            ViewBag.storeHouses = storeHouses;

            ViewBag.storeId = id;


            return View();

        }

        public ActionResult BindStoreHouses(int storeId, List<int> storeHouses )
        {
            string result = _storeRepo.BindStoreHouses(storeId, storeHouses);

            return View("Info", (object)result);
        }
    }
}