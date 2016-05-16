using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPublicLibrary
{
    class CompactDisc : Iitem
    {
        int circulationTimeInSeconds = 3 * 7 * 24 * 60 * 60;
        bool available;
        Patron checkedOutTo;

        DateTime checkouttime;

        decimal fineAmount = 2;
        decimal fineMax = 15;

        /* adding name and description for item */
        string name;
        string description;

        public CompactDisc(bool available)
        {
            this.available = available;
        }

        public bool Available()
        {
            return available;
        }

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
            return fineAmount;
        }
        public int GetFineRate(DateTime start, DateTime end)
        {
            // fine accrues daily
            return (end - start).Days;
        }
        public Decimal GetFineMax()
        {
            return fineMax;
        }
    }
}
