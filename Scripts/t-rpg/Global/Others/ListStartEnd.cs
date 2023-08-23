using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;

namespace TRPG.Global.Others
{
    public class ListStartEnd<T> : List<T>, IEnumerable<T>
    {
        public T current { get; private set; }
        public int curIndex { get; private set; }


        public ListStartEnd() : base()
        {
            curIndex = -1;
        }

        public ListStartEnd(IEnumerable<T> collection) : base(collection)
        {
            curIndex = -1;
        }

        public ListStartEnd(int capacity) : base(capacity)
        {
            curIndex = -1;
        }

        public ListStartEnd(ListStartEnd<T> collection) : base(collection) { curIndex = collection.curIndex; }

        // true if the list isn't empty
        // have always a next if the list isn't empty cause end and start are linked
        public bool HasNext()
        {
            return this.Count > 0;
        }

        public T Next()
        {
            if (this.Count == 0)
            {
                throw new Exception("Can't Next an empty list");
            }
            curIndex++;
            if (curIndex >= this.Count)
            {
                curIndex = 0;
            }
            current = this[curIndex];
            return current;
        }

        // true if the list isn't empty
        // have always a next if the list isn't empty cause end and start are linked
        public bool HasPrev()
        {
            return this.Count > 0;
        }

        public T Prev()
        {
            if (this.Count == 0)
            {
                throw new Exception("Can't Prev an empty list");
            }
            curIndex--;
            if (curIndex < 0)
            {
                curIndex = this.Count-1;
            }
            current = this[curIndex];
            return current;
        }

        public void SafeSort(Comparison<T> comparison)
        {
            this.Sort(comparison);
            this.curIndex = this.IndexOf(current);
        }
    }
}
