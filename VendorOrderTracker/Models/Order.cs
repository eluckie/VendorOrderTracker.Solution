using System.Collections.Generic;

namespace VendorOrderTracker.Models
{
  public class Order
  {
    public string Title { get; set; }
    public string Date { get; set; }
    public int Id { get; }
    private static List<Order> _instances = new List<Order> {};
    public Dictionary<string, int> Description { get; set; }
    public Order(string title, string date)
    {
      Title = title;
      Date = date;
      _instances.Add(this);
      Id = _instances.Count;
      Description = new Dictionary<string, int> {};
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static List<Order> GetAll ()
    {
      return _instances;
    }
    public static Order Find(int searchId)
    {
      return _instances[searchId - 1];
    }
    public void AddOrderDescription(int pastryOrder, int breadOrder)
    {
      Description.Add("pastries", pastryOrder);
      Description.Add("bread", breadOrder);
    }
  }
}