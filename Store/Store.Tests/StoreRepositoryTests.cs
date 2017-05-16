using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using Store.DataAccess.Repositories;

namespace Store.Tests
{
    [TestFixture]
    public class StoreRepositoryTests
    {
        [Test]
        public void GetStoresIncome_ShouldBeExcecutedAnyway()
        {
            StoreRepository sr = new StoreRepository();

            var result = sr.GetStoresIncome();

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetIncomeDetails_ShouldBeExcecutedAnyway()
        {
            StoreRepository sr = new StoreRepository();

            var result = sr.GetIncomeDetails(3);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetStores_ShouldBeExecutedAnyway()
        {
            StoreRepository sr = new StoreRepository();

            var result = sr.GetStores();

            Assert.IsNotNull(result);
        }
    }
}
