using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interfaces;
using OOPublicLibrary;

namespace OOPublicLibraryTests
{
    [TestClass]
    public class PatronTest
    {
        [TestMethod]
        public void TestCheckoutAvailableItem()
        {
            Iitem item = new MockItem(true);
            Patron patron = new Patron();
            bool success = patron.CheckOut(item);
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void TestCheckoutUnavailableItem()
        {
            Iitem item = new MockItem(false);
            Patron patron = new Patron();
            bool success = patron.CheckOut(item);
            Assert.IsFalse(success);
        }
        [TestMethod]
        public void TestReturnItemPatronHas()
        {
            Patron patron = new Patron();
            Iitem item = new MockItem(true);
            patron.CheckOut(item);
            bool returned = patron.Return(item);
            Assert.IsTrue(returned);
        }
        [TestMethod]
        public void TestReturnItemPatronDoesNotHave()
        {
            Patron patron = new Patron();
            Iitem item = new MockItem(true);
            bool returned = patron.Return(item);
            Assert.IsFalse(returned);
        }
    }
}
