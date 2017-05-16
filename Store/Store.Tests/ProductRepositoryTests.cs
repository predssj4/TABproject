using System;
using NUnit;
using NUnit.Framework;
using Store.DataAccess;
using Store.DataAccess.ViewModels;


namespace Store.Tests
{
    
    [TestFixture]
    public class ProductRepositoryTests
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

        [Test]
        public void ProductsList_ShouldReturnList()
        {
            ProductRepository pr = new ProductRepository();
            var result = pr.GetProductsList();

        }

        [Test]
        public void DeleteProduct_ProductShouldBeDeletes()
        {
           // ProductRepository pr = new ProductRepository();
           // pr.DeleteProduct(13);
        }

        [Test]
        public void GetProduct_SomeProductShouldBeReturned()
        {
            ProductRepository pr = new ProductRepository();
            var result = pr.GetProduct(1);
            Assert.IsNotNull(result);
        }
    }


}
