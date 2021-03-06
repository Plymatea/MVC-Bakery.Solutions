using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Vendors.Models;
using System;

namespace Vendors.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {

    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfItem_Item()
    {
      Vendor newVendor = new Vendor("test", "test");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void VendorConstructior_RetrievePropertiesOfItem_True()
    {
      Vendor newVendor = new Vendor("test", "test");
      Assert.AreEqual("test", newVendor.Name);
      Assert.AreEqual(1, newVendor.Id);
      List<Order> orders = new List<Order> {};
      CollectionAssert.AreEqual(orders, newVendor.Orders);
    }

    [TestMethod]
    public void ClearAll_ClearVendorList_True()
    {
      Vendor newVendor = new Vendor("test", "test");
      List<Vendor> vendors = new List<Vendor> {};
      Vendor.ClearAll();
      CollectionAssert.AreEqual(vendors, Vendor.GetAll());
    }

    [TestMethod]
    public void GetAll_Retrieve_instances_True()
    {
      Vendor newVendor = new Vendor("test", "test");
      List<Vendor> vendors = new List<Vendor> {};
      vendors.Add(newVendor);
      CollectionAssert.AreEqual(vendors, Vendor.GetAll());
    }
    
    [TestMethod]
    public void Find_RetrieveVendorFromList_True()
    {
      Vendor newVendor = new Vendor("test", "test");
      Assert.AreEqual(newVendor, Vendor.Find(1));
    }

    [TestMethod]
    public void AddOrder_AddOrderToOrdersList_True()
    {
      Vendor newVendor = new Vendor("test", "test");
      Order newOrder = new Order("test", "test", "test", "test", "test");
      newVendor.AddOrder(newOrder);
      List<Order> testOrders = new List<Order> {};
      testOrders.Add(newOrder);
      CollectionAssert.AreEqual(testOrders, newVendor.Orders);
    }
  }
}
