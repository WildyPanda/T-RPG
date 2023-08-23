using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace TRPG.Global.Others
{
    public class IncreasableList<T>
    {
        public int maxSize {  get; private set; }
        protected List<T> list;

        public T this[int index] { get { return list[index]; } }
        public int Count { get { return list.Count; } }


        public IncreasableList(int maxSize) : base()
        {
            this.maxSize = maxSize;
            this.list = new List<T>();
        }

        public bool canAdd()
        {
            return list.Count < maxSize;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (list.Count + collection.Count() >= maxSize)
                throw new Exception("Too many new elements added in the IncreasableList");
            list.AddRange(collection);
        }

        public void AddRange(IncreasableList<T> list)
        {
            if (list.Count + list.Count >= maxSize)
                throw new Exception("Too many new elements added in the IncreasableList");
            list.AddRange(list);
        }

        public void Add(T item)
        {
            if (list.Count + 1 == maxSize)
            list.Add(item);
        }

        public void changeListSize(int newSize)
        {
            if (list.Count < newSize)
                throw new Exception("Can't reduce the size of the IncreasableList below the current number of element in the list");
            this.maxSize -= newSize;
        }

        public void RemoveAt(int index)
        {
            this.list.RemoveAt(index);
        }

        public void RemoveLast()
        {
            this.list.RemoveAt(this.Count - 1);
        }
    }
}
