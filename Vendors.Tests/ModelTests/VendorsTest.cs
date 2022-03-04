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
      Vendor newVendor = new Vendor("test");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void VendorConstructior_RetrievePropertiesOfItem_True()
    {
      Vendor newVendor = new Vendor("test");
      Assert.AreEqual("test", newVendor.Name);
      Assert.AreEqual(1, newVendor.Id);
      List<Order> orders = new List<Order> {};
      CollectionAssert.AreEqual(orders, newVendor.Orders);
    }

    [TestMethod]
    public void ClearAll_ClearVendorList_True()
    {
      Vendor newVendor = new Vendor("test");
      List<Vendor> vendors = new List<Vendor> {};
      Vendor.ClearAll();
      CollectionAssert.AreEqual(vendors, Vendor.GetAll());
    }

    [TestMethod]
    public void GetAll_Retrieve_instances_True()
    {
      Vendor newVendor = new Vendor("test");
      List<Vendor> vendors = new List<Vendor> {};
      vendors.Add(newVendor);
      CollectionAssert.AreEqual(vendors, Vendor.GetAll());
    }
  }
}
