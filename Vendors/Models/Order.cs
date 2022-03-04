using System.Collections.Generic;

namespace Vendors.Models
{
  public class Order
  {
    public string Title { get; set; }
    public string Vendor { get; set; }
    public string Desc { get; set; }
    public string Price { get; set; }
    public string Date { get; set; }

    public int Id { get; }
    private static List<Order> _instances = new List<Order> {};
    public Order(string orderTitle, string vendor, string orderDesc, string price, string date)
    {
      Title = orderTitle;
      Vendor = vendor;
      Desc = orderDesc;
      Price = price;
      Date = date;
      _instances.Add(this);
      Id = _instances.Count;
    }
    public static List<Order> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Order Find(int searchId)
    {
      return _instances[searchId - 1];
    }
  }
}