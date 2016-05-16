using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace OOPublicLibrary
{
    public class Patron
    {
        IList<Iitem> items;
        public Patron()
        {
            items = new List<Iitem>();
        }
        public bool CheckOut(Iitem item)
        {
            if (item.Available())
            {
                items.Add(item);
                item.CheckOut(this);
                return true;
            }
            return false;
        }
        public bool Return(Iitem item)
        {
            //TODO: implement this method
            return false;
        }

        public IList<Iitem> GetItems()
        {
            return items;
        }
    }
}
