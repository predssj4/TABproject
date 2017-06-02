using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.DataAccess.Repositories;

namespace Store.WebUI.Controllers
{
    public class CustomerController : Controller
    {

        private CustomerRepository _repo;

        public CustomerController()
        {
            _repo = new CustomerRepository();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCustomersList()
        {
            return View(_repo.GetCustomersList());
        }

        public ActionResult Details(int id = 0)
        {
            return View("Details", _repo.GetCustomerDetails(id));
        }



    }
}