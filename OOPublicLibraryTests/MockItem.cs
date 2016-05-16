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
        public MockItem(bool available)
        {
            this.available = available;
        }
        public bool Available()
        {
            return available;
        }

        public bool CheckOut(Patron patron)
        {
            //throw new NotImplementedException();
            return true;
        }

        public int GetCirculationTimeInSeconds()
        {
            throw new NotImplementedException();
        }
    }
}
