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

        decimal overdueFineRate = 2;
        decimal fineMax = 15;

        /* adding name and description for item */
        string name;
        string description;

        public bool Available()
        {
            throw new NotImplementedException();
        }

        public bool CheckOut(Patron patron)
        {
            throw new NotImplementedException();
        }

        public int GetCirculationTimeInSeconds()
        {
            throw new NotImplementedException();
        }
        public bool Return(Patron patron)
        {
            throw new NotImplementedException();
        }
        public DateTime GetCheckOutTime()
        {
            throw new NotImplementedException();
        }
        public DateTime GetItemDueDate()
        {
            throw new NotImplementedException();
        }
        public decimal GetFineAmount()
        {
            throw new NotImplementedException();
        }
        public int GetFineRate(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
        public decimal GetFineMax()
        {
            throw new NotImplementedException();
        }
    }
}
