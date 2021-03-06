using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Vendors.Models;

namespace Vendors.Controllers
{
  public class VendorsController : Controller
  {

    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string vendorName, string vendorDesc)
    {
      Vendor newVendor = new Vendor(vendorName, vendorDesc);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(id);
      List<Order> vendorOrders = selectedVendor.Orders;
      model.Add("vendors", selectedVendor);
      model.Add("orders", vendorOrders);
      return View(model);
    }

    // This one creates new Orders within a given Category, not new Categories:
    [HttpPost("/vendors/{vendorId}/orders/")]
    public ActionResult Create(int vendorId, string orderTitle, string vendor, string orderDesc, string price, string orderDate)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor foundVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(orderTitle, vendor, orderDesc, price, orderDate);
      foundVendor.AddOrder(newOrder);
      List<Order> vendorOrders = foundVendor.Orders;
      model.Add("orders", vendorOrders);
      model.Add("vendors", foundVendor);
      return View("Show", model);
    }

    [HttpPost("vendors/delete")]
    public ActionResult DeleteAll()
    {
      Vendor.ClearAll();
      return RedirectToAction("Index");
    }
  }
}