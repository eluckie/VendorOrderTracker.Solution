using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorOrderTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorOrderTracker.Tests
{
  [TestClass]
  public class VendorTests
  {
    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("CompanyName", "CompanyDescription");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }
    [TestMethod]
    public void GetName_ReturnsVendorName_String()
    {
      Vendor newVendor = new Vendor("CompanyName", "CompanyDescription");
      Assert.AreEqual("CompanyName", newVendor.Name);
    }
    [TestMethod]
    public void GetDescription_ReturnsVendorDescription_String()
    {
      Vendor newVendor = new Vendor("CompanyName", "CompanyDescription");
      Assert.AreEqual("CompanyDescription", newVendor.Description);
    }
  }
}