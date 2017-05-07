using System;
using NUnit;
using NUnit.Framework;
using Store.DataAccess;


namespace Store.Tests
{
    
    [TestFixture]
    public class UnitTest2
    {
        [Test]
        public void ConnectionExecuting()
        {
            ProductRepository pr = new ProductRepository();

            
            pr.AddProduct();
        }
    }
}
