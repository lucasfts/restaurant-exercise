using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Business;
using Restaurant.Data;
using System;

namespace Restaurant.UnitTests
{
    [TestClass]
    public class OrderTests
    {
        OrderService _service;

        [TestInitialize]
        public void Setup()
        {
            //I would mock the repository if it had to access infrastructure resources like a database
            _service = new OrderService(new OrderRepository());
        }

        [TestMethod]
        [DataRow(1, 2)]
        [DataRow(2, 1)]
        [DataRow(2, 3)]
        public void Order_ValidState_OrderCreated(int pointOfSaleId, int mealId)
        {
            var order = _service.ReceiveOrder(pointOfSaleId, mealId).Result;

            Assert.IsTrue(order.OrderId > 0);
        }

        [TestMethod]
        [DataRow(0, 2)]
        [DataRow(2, -1)]
        [DataRow(-1, 0)]
        public void Order_InValidState_ThrowsException(int pointOfSaleId, int mealId)
        {
            try
            {
                var order = _service.ReceiveOrder(pointOfSaleId, mealId).Result;
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }
    }
}
