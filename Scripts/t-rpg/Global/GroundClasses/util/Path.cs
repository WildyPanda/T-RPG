using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TRPG.Global.GroundClasses.Util
{
    public class Path
    {
        Vector2 position;
        bool isOrigin;
        Path parent;

        public Path(Vector2 position)
        {
            this.position = position;
            this.isOrigin = true;
        }

        public Path(Vector2 position, Path parent)
        {
            this.position = position;
            if(parent != null)
            {
                this.isOrigin = false;
                this.parent = parent;
            }
            else
            {
                this.isOrigin = true;
            }
        }

        public Vector2 getOrigin()
        {
            if(this.isOrigin)
            {
                return this.position;
            }
            return parent.getOrigin();
        }

        public int size()
        {
            if (!this.isOrigin)
            {
                return 1 + parent.size();
            }
            return 1;
        }

        // check if the origin and the destination are the same
        // return true if the first and last position of the path are the same
        public bool sameTravel(Path path)
        {
            return this.position == path.position && this.getOrigin() == path.getOrigin();
        }

        // return true if new path is quicker than this path
        public bool isPathQuicker(Path path)
        {
            return this.size() > path.size();
        }

        public List<Vector2> getList()
        {
            List<Vector2> list = new List<Vector2>();
            if (this.isOrigin)
            {
                list.Add(this.position);
            }
            else
            {
                list.AddRange(parent.getList());
            }
            return list;
        }

        public List<Vector2>.Enumerator GetEnumerator()
        {
            return getList().GetEnumerator();
        }
    }
}