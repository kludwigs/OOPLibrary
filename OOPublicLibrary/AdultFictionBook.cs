using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPublicLibrary;

namespace OOPublicLibrary
{
    public class AdultFictionBook : Iitem
    {
        bool available;
        Patron checkedOutTo;
        Int32 circulationTimeInSeconds = 3 * 7 * 24 * 60 * 60;
        public AdultFictionBook(bool available)
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
            }
            return false;
        }

        public int GetCirculationTimeInSeconds()
        {
            return circulationTimeInSeconds;
        }
    }
}
