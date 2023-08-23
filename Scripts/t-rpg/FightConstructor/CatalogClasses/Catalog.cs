using System;
using System.IO;
using System.Linq;
using System.Reflection;
using TRPG.Global.DataClasses;
using TRPG.Global.Others;
using UnityEngine;

namespace TRPG.FightConstructor.CatalogClasses
{
    public class Catalog<T> where T : Catalogable
    {
        private Transform catalog;
        private ListStartEnd<GameObject> pages;
        private ListStartEnd<Type> types;

        public Catalog(Transform catalog)
        {
            this.types = new ListStartEnd<Type>();
            this.catalog = catalog;
            this.pages = new ListStartEnd<GameObject>();
            foreach(Type type in Assembly.GetAssembly(typeof(T)).GetTypes().
                Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                this.pages.Add(((T)Activator.CreateInstance(type)).toPage(catalog));
                this.types.Add(type);
            }
            foreach(GameObject page in this.pages)
            {
                page.SetActive(false);
            }
            this.pages[0].SetActive(true);
            this.pages.Next();
            this.types.Next();
        }

        public void Next()
        {
            pages.current.SetActive(false);
            pages.Next().SetActive(true);
            this.types.Next();
        }

        public void Prev()
        {
            pages.current.SetActive(false);
            pages.Prev().SetActive(true);
            this.types.Prev();
        }

        public GameObject currentPage()
        {
            return this.pages.current;
        }

        public T current()
        {
            return (T)Activator.CreateInstance(this.types.current);
        }
    }
}
