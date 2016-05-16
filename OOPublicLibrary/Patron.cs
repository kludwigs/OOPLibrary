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
        protected int maxAdultFictionBooks = 10;
        public int MaxAdultFictionBooks{get{return maxAdultFictionBooks;}}

        protected int maxCompactDiscs = 5;
        public int MaxCompactDiscs{get{return maxCompactDiscs;}}

        /* file says 30 even though max items for a regular patron is 15 */
        protected int maxPictureBooks = 30;
        public int MaxPictureBooks {get{return maxPictureBooks;}}

        protected int maxItems = 15;
        public int MaxItems {get{return maxItems; }}

        protected decimal fines = 0;

        IList<Iitem> items;
        public Patron()
        {
            items = new List<Iitem>();
        }

        public bool CheckOut(Iitem item)
        {                        
            if(CanWeCheckOutAnItem(item))
            {
                if (item.Available())
                {
                    items.Add(item);
                    item.CheckOut(this);
                    return true;
                }
            }
            return false;            
        }
        public bool Return(Iitem item)
        {
            //TODO: implement this method
            if(!item.Available())
            {                
                var itemToRemove = items.FirstOrDefault(x => x.Equals(item));
                
                if (itemToRemove != null)
                { 
                    /* User has the item - let's return it */                    
                    if(item.Return(this))
                    {
                        fines += GetOutstandingFine(item);
                        items.Remove(itemToRemove);                    
                        return true;
                    }
                }
            }
            return false;
        }

        public IList<Iitem> GetItems()
        {
            return items;
        }
        protected bool CanWeCheckOutAnItem(Iitem item)
        {
            if (fines > 0)
                return false;
            // children can't check out a book unless they've been assigned to an adult. They also can't check out adult fiction books
            if (this.GetType() == typeof(Child))                
                if (!IsObjectAnAdult(((Child)this).AssignedTo) || item.GetType() == typeof(AdultFictionBook))
                    return false;
            if (items.Any())
            {
                if (DoWeHaveAnOverdueItem())
                    return false;

                if (items.Count() < maxItems)
                {
                    if (item.GetType() == typeof(AdultFictionBook))
                    {
                        if (items.OfType<AdultFictionBook>().Count() == maxAdultFictionBooks)
                            return false;
                    }
                    else if (item.GetType() == typeof(CompactDisc))
                        if (items.OfType<CompactDisc>().Count() == maxCompactDiscs)
                            return false;
                        else if (item.GetType() == typeof(PictureBook))
                            if (items.OfType<PictureBook>().Count() == maxPictureBooks)
                                return false;
                }
                else
                    return false;
            }
            return true;
        }
        public bool DoWeHaveAnOverdueItem()
        {
            foreach(var item in items)
            {
                if (IsItemOverdue(item))
                    return true;
            }
            return false;
        }
        private bool IsItemOverdue(Iitem item)
        {
            DateTime dueDate = item.GetCheckOutTime().AddSeconds(item.GetCirculationTimeInSeconds());

            if(dueDate > DateTime.Now)
                return false;
            return true;
        }
        private static bool IsObjectAnAdult<T>(T myobject)
        {            
            if (myobject == null)
                return false;

            if (myobject.GetType() == typeof(Adult) || myobject.GetType().IsSubclassOf(typeof(Adult)))
                return true;
            return false;
        }
        private decimal GetOutstandingFine(Iitem item)
        {
            if (IsItemOverdue(item))
            {
                DateTime dueDate = item.GetCheckOutTime().AddSeconds(item.GetCirculationTimeInSeconds());
                decimal calcfine = item.GetFineRate(dueDate, DateTime.Now) * item.GetFineAmount();
                // fines can't exceed the max value
                return (calcfine < item.GetFineMax()) ? calcfine : item.GetFineMax();
            }
            return 0;
        }
        public void PayFines()
        {
            fines = 0;
        }
        /*
        public decimal calculateOutstandingFines()
        {
            decimal calcFines = 0;
            foreach (var item in items)
            {
                calcFines += GetOutstandingFine(item);
            }
            return calcFines;
        }
        */

    }
}
