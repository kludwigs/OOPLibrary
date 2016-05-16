using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace OOPublicLibrary
{    
    public class Child: Patron
    {
        protected Patron assignedTo;
        public Patron AssignedTo { get { return assignedTo; } }

        public Child(Patron adult):base()
        {
            this.assignedTo = adult;
        }
        public Child() : base()
        {
            this.assignedTo = null;
        }

        public void AssignChildAnAdult(Patron adult)
        {
            this.assignedTo = adult;
        }

    }
}
