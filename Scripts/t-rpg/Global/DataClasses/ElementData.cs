using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.PlayerClasses.Util;
using UnityEngine;

namespace TRPG.Global.DataClasses
{
    public static class ElementData
    {
        // number of elements | must be equal to the size of this.elements
        public const int nbElements = 3;

        // list containing all elements
        public static List<Element> elements = new List<Element> {
            new Element("Fire", 0),
            new Element("Water", 1),
            new Element("Grass", 2)
        };//setUpElements();

        public static T[] dictToElementArray<T>(Dictionary<int, T> dict)
        {
            T[] arr = new T[nbElements];
            foreach (int i in dict.Keys)
            {
                arr[i] = dict[i];
            }
            return arr;
        }

        public static Element getElementByName(string elementName)
        {
            foreach (Element element in elements)
            {
                if (element.name == elementName)
                {
                    return element;
                }
            }
            return null;
        }


    }
}
