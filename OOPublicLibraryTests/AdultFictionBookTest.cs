using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPublicLibrary;

namespace OOPublicLibraryTests
{
    [TestClass]
    public class AdultFictionBookTest
    {
        [TestMethod]
        public void TestCheckoutAvailable()
        {
            AdultFictionBook book = new AdultFictionBook(true);
            Patron patron = new Patron();
            bool success = book.CheckOut(patron);
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void TestCheckoutUnavailable()
        {
            AdultFictionBook book = new AdultFictionBook(false);
            Patron patron = new Patron();
            bool success = book.CheckOut(patron);
            Assert.IsFalse(success);
        }
        [TestMethod]
        public void TestCirculationTime()
        {
            AdultFictionBook book = new AdultFictionBook(false);
            Assert.AreEqual(1814400, book.GetCirculationTimeInSeconds());
        }
    }
}
