using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using Store.DataAccess.Repositories;
using NUnit.Framework;

namespace Store.Tests
{
    [TestFixture]
    public class CustomerRepositoryTests
    {
        [Test]
        public void GetCustomersList_ShouldHaveElements()
        {
            CustomerRepository repo = new CustomerRepository();

           var result =  repo.GetCustomersList();

            Assert.IsTrue(result.Any());
        }

        [Test]
        public void GetCustomerDetails_ShouldBeExcecutedAnyway()
        {
            CustomerRepository repo = new CustomerRepository();
            var res = repo.GetCustomerDetails(3);
        }
    }
}
