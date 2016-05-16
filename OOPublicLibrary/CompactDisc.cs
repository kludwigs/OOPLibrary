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
    }
}
