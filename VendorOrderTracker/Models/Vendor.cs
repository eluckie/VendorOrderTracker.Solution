

namespace VendorOrderTracker.Models
{
  public class Vendor
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public int Id { get; }
    private static List<Vendor> _instances = new List<Vendor> {};
    public List<Order> Orders { get; set; }
    public Vendor(string name, string description)
    {
      Name = name;
      Description = description;
      _instances.Add(this);
      Id = _instances.Count;
      Orders = new List<Order>{};
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static List<Vendor> GetAll()
    {
      return _instances;
    }
    public static Vendor Find(int searchId)
    {
      return _instances.Find((e) => {
      return e.Id == searchId;
      });
    }
    public void AddOrder(Order order)
    {
      Orders.Add(order);
    }
    public static Vendor Delete(int searchId)
    {
      Vendor vendor = Vendor.Find(searchId);
      _instances.Remove(vendor);
      return vendor;
    }
    public void RemoveOrder(Order order)
    {
      Orders.Remove(order);
    }
    public static void DeleteAllOrders(int searchId)
    {
      Vendor vendor = Vendor.Find(searchId);
      vendor.Orders.Clear();
    }
  }
}