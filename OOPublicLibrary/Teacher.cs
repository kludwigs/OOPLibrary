using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace OOPublicLibrary
{
    public class Teacher : Adult
    {
        public Teacher() : base()
        {
            this.maxAdultFictionBooks *= 3;
            this.maxCompactDiscs *= 3;
            this.maxPictureBooks *= 3;
            this.maxItems = 50;
        }
    }
}

