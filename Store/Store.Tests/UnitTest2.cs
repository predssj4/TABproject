using System;
using NUnit;
using NUnit.Framework;
using Store.DataAccess;
using Store.DataAccess.ViewModels;


namespace Store.Tests
{
    
    [TestFixture]
    public class UnitTest2
    {
        [Test]
        public void ConnectionExecuting()
        {
            ProductRepository pr = new ProductRepository();

            var product = new ProductViewModel()
            {
                Name = "Kujawski",
                Description = "Majonez",
                ProductTypeId = 2,
                Price = 43.3M
            };

           var res =  pr.AddProduct(product);

            Assert.AreEqual("", res);
        }
    }
}
