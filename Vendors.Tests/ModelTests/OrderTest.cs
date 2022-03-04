using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Vendors.Models;
using System;

namespace Orders.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {

    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfItem_Item()
    {
      Order newOrder = new Order("test", "test");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

        [TestMethod]
    public void OrderConstructor_RetrievePropertiesOfItem_True()
    {
      Order newOrder = new Order("test", "test");
      Assert.AreEqual("test", newOrder.Vendor);
      Assert.AreEqual(1, newOrder.Id);
    }

 
  }
}