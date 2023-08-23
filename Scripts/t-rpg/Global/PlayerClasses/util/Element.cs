using System;
using TRPG.Global.DataClasses;
using UnityEngine;

namespace TRPG.Global.PlayerClasses.Util
{
    public class Element
    {
        public int key { get; set; }
        public string name { get; set; }
        public Sprite sprite { get; set; }

        public Element(string name, int key)
        {
            this.key = key;
            this.name = name;
            this.sprite = SpritesData.getElementSprite(name);
        }

        public Element(int key, string name, Sprite sprite) 
        {
            this.key = key;
            this.name = name;
            this.sprite = sprite;
        }

        // return the key of the element (unique for every elements)
        public int Key()
        {
            return this.key;
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Element))
            {
                return false;
            }
            Element o = (Element)obj;
            bool sameKey = this.key == o.key;
            bool sameName = this.name.Equals(o.name);
            bool sameSprite = this.sprite.Equals(o.sprite);
            return sameKey && sameName && sameSprite;
        }
    }
}