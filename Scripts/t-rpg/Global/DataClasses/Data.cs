using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TRPG.Global.Others;
using TRPG.Global.PlayerClasses.Util;
using Unity.VisualScripting;
using UnityEngine;

namespace TRPG.Global.DataClasses
{
    public static class FightData
    {
        // calculate the amount of damage recieved
        public static int damageOfAttack(int skillPower, int attack, int defense)
        {
            return (int)(skillPower * attackToMultiplier(attack) * defenseToMultiplier(defense));
        }

        // how the attack affect the damage of the skill
        // for the moment 1 + attack/100 => attack 0 = x1 / attack 100 = x2 / attack 50 = 1.5x etc
        private static float attackToMultiplier(int attack)
        {
            return 1 + (attack / 100);
        }

        // how the defense affect the damage of the skill
        // for the moment 500 / (500 + defense)
        // for slower increase in defense increase the fixed number
        // will get 50% reduced damage at 500 defense
        // will get 90% reduced damage at 4500 defense
        private static float defenseToMultiplier(int defense)
        {
            return 500 / (500 + defense);
        }
    }

    public static class Data
    {
        public static int maxCreatures = 6;
        public static int maxSpirits = 3;

        public static List<T> ListDeepCopy<T>(List<T> l) where T : Cloneable<T>
        {
            List<T> newList = new List<T>();
            foreach (T item in l)
            {
                newList.Add(item.Clone());
            }
            return newList;
        }

        public static List<T> ListCopy<T>(List<T> l)
        {
            List<T> newList = new List<T>();
            foreach (T item in l)
            {
                newList.Add(item);
            }
            return newList;
        }

        public static T[] ArrayDeepCopy<T>(T[] l) where T : Cloneable<T>
        {
            T[] newArray = new T[l.Length];
            for (int i = 0; i < l.Length; i++)
            {
                newArray[i] = l[i].Clone();
            }
            return newArray;
        }

        public static T[] ArrayCopy<T>(T[] l)
        {
            T[] newArray = new T[l.Length];
            for (int i = 0; i < l.Length; i++)
            {
                newArray[i] = l[i];
            }
            return newArray;
        }

        public static bool ListEquals<T>(List<T> l1, List<T> l2)
        {
            if (l1.Count != l2.Count)
            {
                return false;
            }
            for (int i = 0; i < l1.Count; i++)
            {
                if (!(l1[i].Equals(l2[i])))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ArrayEquals<T>(T[] l1, T[] l2)
        {
            if(l1.Length != l2.Length) return false;
            for (int i = 0; i < l1.Length; i++)
            {
                if (l1[i] == null ^ l2[i] == null) return false;
                if (!(l1[i] == null) && !(l1[i].Equals(l2[i]))) return false;
            }
            return true;
        }
    }
}