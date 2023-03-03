using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorOrderTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorOrderTracker.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }
    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("OrderTitle", "3/3/23");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }
    [TestMethod]
    public void GetTitle_ReturnsOrderTitle_String()
    {
      Order newOrder = new Order("OrderTitle", "3/3/23");
      Assert.AreEqual("OrderTitle", newOrder.Title);
    }
    [TestMethod]
    public void GetDate_ReturnsOrderDate_String()
    {
      Order newOrder = new Order("OrderTitle", "3/3/23");
      Assert.AreEqual("3/3/23", newOrder.Date);
    }
    [TestMethod]
    public void GetId_ReturnsOrderId_Int()
    {
      Order newOrder = new Order("OrderTitle", "3/3/23");
      Assert.AreEqual(1, newOrder.Id);
    }
    [TestMethod]
    public void GetAll_ReturnsAllOrderObjects_OrderList()
    {
      Order newOrder1 = new Order("OrderTitle1", "3/3/23");
      Order newOrder2 = new Order("OrderTitle2", "3/3/23");
      List<Order> orderList = new List<Order> { newOrder1, newOrder2 };
      CollectionAssert.AreEqual(orderList, Order.GetAll());
    }
    [TestMethod]
    public void Find_ReturnsSpecificOrder_Order()
    {
      Order newOrder1 = new Order("OrderTitle1", "3/3/23");
      Order newOrder2 = new Order("OrderTitle2", "3/3/23");
      Assert.AreEqual(newOrder2, Order.Find(2));
    }
    [TestMethod]
    public void AddOrderDescription_AddsDescriptionToSpecifiedOrdersDictionary_Dictionary()
    {
      Order newOrder = new Order("OrderTitle", "3/3/23");
      Dictionary<string, int> orderDescription = new Dictionary<string, int> { {"pastries", 2 }, { "bread", 2 } };
      newOrder.AddOrderDescription(2, 2);
      Dictionary<string, int> result = newOrder.Description;
      CollectionAssert.AreEqual(orderDescription, result);
    }
    [TestMethod]
    public void CalculateBreadTotal_ReturnsCostOfBreadInOrder_Int()
    {
      Order newOrder = new Order("OrderTitle", "3/3/23");
      newOrder.AddOrderDescription(2, 3);
      int breadQuantity = newOrder.Description["bread"];
      int result = newOrder.CalculateBreadTotal(breadQuantity);
      Assert.AreEqual(10, result);
    }
    [TestMethod]
    public void CalculatePastryTotal_ReturnsCostOfPastriesInOrder_Int()
    {
      Order newOrder = new Order("OrderTitle", "3/3/23");
      newOrder.AddOrderDescription(4, 1);
      int pastryQuantity = newOrder.Description["pastries"];
      int result = newOrder.CalculatePastryTotal(pastryQuantity);
      Assert.AreEqual(6, result);
    }
  }
}
