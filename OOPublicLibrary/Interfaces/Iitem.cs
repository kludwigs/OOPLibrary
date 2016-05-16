using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPublicLibrary;

namespace Interfaces
{
    public interface Iitem
    {
        bool Available();
        bool CheckOut(Patron patron);
        int GetCirculationTimeInSeconds();
    }
}
