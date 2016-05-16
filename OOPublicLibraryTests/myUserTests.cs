using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interfaces;
using OOPublicLibrary;
using System.Collections;
using System.Collections.Generic;

namespace OOPublicLibraryTests
{
    [TestClass]
    public class myUserTests
    {
        [TestMethod]
        public void TestCheckOutLimitForAdultFictionBooks()
        {
            List<AdultFictionBook> books = new List<AdultFictionBook>();
            Patron patron = new Patron();

            // create 11 books
            for (int i = 0; i < patron.MaxAdultFictionBooks + 1; i++)
            {
                books.Add(new AdultFictionBook(true));
            }

            // check out 10           
            for (int i = 0; i < patron.MaxAdultFictionBooks; i++)
            {
                patron.CheckOut(books[i]);
            }

            // over the limit;
            bool success = patron.CheckOut(books[patron.MaxAdultFictionBooks]);

            Assert.IsFalse(success);

            // return a book to in order to get another book
            patron.Return(books[0]);

            success = patron.CheckOut(books[patron.MaxAdultFictionBooks]);

            Assert.IsTrue(success);
        }
        [TestMethod]
        public void TestDifferentUsersCheckingOutABook()
        {
            AdultFictionBook book1 = new AdultFictionBook(true);

            Patron patron1 = new Patron();
            Patron patron2 = new Patron();

            patron1.CheckOut(book1);
            bool success = patron2.CheckOut(book1);

            Assert.IsFalse(success);

            // return a book to so the other patron can check it out.
            patron1.Return(book1);
            success = patron2.CheckOut(book1);
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void TestTeacher()
        {
            Patron teacher = new Teacher();
            Assert.IsTrue(teacher.GetType() == typeof(Teacher));
        }
        [TestMethod]
        public void TestReturnItemForCorrectOwner()
        {
            AdultFictionBook book = new AdultFictionBook(true);

            Patron patron1 = new Patron();
            Patron patron2 = new Patron();

            patron1.CheckOut(book);

            /* have patron 2 try to check out the same book */
            bool success = patron2.CheckOut(book);
            Assert.IsFalse(success);
            /* We don't have it but we'll try to return it anyway */
            success = patron2.Return(book);
            Assert.IsFalse(success);

            success = patron1.Return(book);
            Assert.IsTrue(success);

            success = patron2.CheckOut(book);
            Assert.IsTrue(success);

        }
        [TestMethod]
        public void TestChildCheckOutWithAdult()
        {
            Patron child = new Child();
            Patron adult = new Adult();

            PictureBook pbook = new PictureBook(true);

            bool success = child.CheckOut(pbook);

            Assert.IsFalse(success);

            ((Child)child).AssignChildAnAdult(adult);

            success = child.CheckOut(pbook);

            Assert.IsTrue(success);
        }
        [TestMethod]
        public void TestChildCheckOutWithTeacher()
        {
            Patron child = new Child();
            Patron teacher = new Teacher();

            PictureBook pbook = new PictureBook(true);

            bool success = child.CheckOut(pbook);

            Assert.IsFalse(success);

            ((Child)child).AssignChildAnAdult(teacher);

            success = child.CheckOut(pbook);

            Assert.IsTrue(success);
        }
        [TestMethod]
        public void TestChildCheckOutAndReturnWithAdult()
        {
            Patron adult = new Adult();
            Patron child = new Child(adult);

            PictureBook pbook = new PictureBook(true);

            bool success = child.CheckOut(pbook);

            Assert.IsTrue(success);

            success = child.Return(pbook);

            Assert.IsTrue(success);
        }
        [TestMethod]
        public void TestChildCheckOutWithAdultFictionBook()
        {
            Patron adult = new Adult();
            Patron child = new Child(adult);

            AdultFictionBook adultbook = new AdultFictionBook(true);

            bool success = child.CheckOut(adultbook);

            Assert.IsFalse(success);
        }
        [TestMethod]
        public void TestCheckOutPassedDueDate()
        {
            Patron teacher = new Teacher();
            MockItem item1 = new MockItem(true);
            MockItem item2 = new MockItem(true);

            bool success = teacher.CheckOut(item1);
            Assert.IsTrue(success);

            // wait until item is overdue
            System.Threading.Thread.Sleep(4*1000);

            success = teacher.CheckOut(item2);
            Assert.IsFalse(success);
            // return overdue item in order to check out another item
            teacher.Return(item1);
            success = teacher.CheckOut(item2);
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void TestCheckOutPassedDueDateAndFinesAccrue()
        {
            Patron teacher = new Teacher();
            MockItem item1 = new MockItem(true);
            MockItem item2 = new MockItem(true);

            // set a fine amount for an item
            item1.fineamount = 1;

            bool success = teacher.CheckOut(item1);
            Assert.IsTrue(success);

            // wait until item is overdue
            System.Threading.Thread.Sleep(4 * 1000);
            success = teacher.CheckOut(item2);
            Assert.IsFalse(success);
            // return overdue book
            teacher.Return(item1);
            // try to check out but fines have accrued
            success = teacher.CheckOut(item2);
            Assert.IsFalse(success);
            // pay fines then try to check out again
            teacher.PayFines();
            success = teacher.CheckOut(item2);
            Assert.IsTrue(success);
        }
    }
}
