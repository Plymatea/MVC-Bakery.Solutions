using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Vendors.Models;
using System;

namespace Vendors.Tests
{
  [TestClass]
  public class VendorTests /*: IDisposable*/
  {

  //   public void Dispose()
  //   {
  //     Vendor.ClearAll();
  //   }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfItem_Item()
    {
      Vendor newVendor = new Vendor("test");
      Assert.AreEqual(typeof(Order), newVendor.GetType());
    }
  }
}
