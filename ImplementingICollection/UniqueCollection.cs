using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementingICollection
{
    internal class UniqueCollection<T>: ICollection<T>
    {
        public List<T> items = new List<T>();
        public int Count => items.Count;
        public event Action<T>? ExistItemAdded;
        public event Action<T>? NotExistItemAdded;
        public event Action<T>? ExistItemRemoved;
        public event Action<T>? NotExistItemRemoved;
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        public void Add(T itemToAdd)
        {
            if (!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
                if(NotExistItemAdded != null)
                    NotExistItemAdded(itemToAdd);
            }
            else
                if (ExistItemAdded != null)
                    ExistItemAdded(itemToAdd);
        }
        public void Clear()
        {
            while (Count > 0)
                items.RemoveAt(0);
            Console.WriteLine("List Cleared");
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in items)
                yield return item;
        }
        public bool Remove(T itemToRemove)
        {
            if (!items.Contains(itemToRemove))
            {
                if (NotExistItemRemoved != null)
                    NotExistItemRemoved(itemToRemove);
            }
            else
                ExistItemRemoved(itemToRemove);
            return items.Remove(itemToRemove);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            array = items.GetRange(arrayIndex, items.Count).ToArray();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
