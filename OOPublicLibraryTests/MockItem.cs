using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using OOPublicLibrary;

namespace OOPublicLibraryTests
{
    class MockItem : Iitem
    {
        bool available;
        Patron checkedOutTo;
        DateTime checkouttime;
        
        // only mock item has public fineamount
        public decimal fineamount = 0;
        decimal finemax = 20;

        Int32 circulationTimeInSeconds = 3;

        public MockItem(bool available)
        {
            this.available = available;
        }
        public bool Available()
        {
            return available;
        }
        /* added additional logic so available is set to false when item is checked out */
        public bool CheckOut(Patron patron)
        {
            if (available)
            {
                available = false;
                checkedOutTo = patron;
                checkouttime = DateTime.Now;
                return true;
            }
            else
                return false;
        }
        /* Added Return Method To Toggle available back to true */
        public bool Return(Patron patron)
        {
            if (!available && checkedOutTo.Equals(patron))
            {
                available = true;
                checkedOutTo = null;
                return true;
            }
            return false;
        }

        public int GetCirculationTimeInSeconds()
        {
            return circulationTimeInSeconds;
        }
        public DateTime GetCheckOutTime()
        {
            return checkouttime;
        }
        public decimal GetFineAmount()
        {
            return fineamount;
        }
        // for interval after the due date the fine will accrue
        public int GetFineRate(DateTime start, DateTime end)
        {
            return (end - start).Seconds;
        }
        public decimal GetFineMax()
        {
            return finemax;
        }
    }
}
