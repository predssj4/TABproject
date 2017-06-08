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

        public ActionResult GetCustomersList(string filter = "IdAsc")
        {
            var result = _repo.GetCustomersList();

            switch (filter)
            {
                case "IdAsc":
                    result = result.OrderBy(x => x.CustomerId).ToList();
                    break;
                case "IdDesc":
                    result = result.OrderByDescending(x => x.CustomerId).ToList();
                    break;
                case "NameAsc":
                    result = result.OrderBy(x => x.Name).ToList();
                    break;
                case "NameDesc":
                    result = result.OrderByDescending(x => x.Name).ToList();
                    break;
                case "AddressAsc":
                    result = result.OrderBy(x => x.Address).ToList();
                    break;
                case "AddressDesc":
                    result = result.OrderByDescending(x => x.Address).ToList();
                    break;
                case "BirthAsc":
                    result = result.OrderBy(x => x.BirthDate).ToList();
                    break;
                case "BirthDesc":
                    result = result.OrderByDescending(x => x.BirthDate).ToList();
                    break;
                case "LastNameAsc":
                    result = result.OrderBy(x => x.LastName).ToList();
                    break;
                case "LastNameDesc":
                    result = result.OrderByDescending(x => x.LastName).ToList();
                    break;
            }


            return View(result);
        }

        public ActionResult Details(int id = 0)
        {
            return View("Details", _repo.GetCustomerDetails(id));
        }



    }
}