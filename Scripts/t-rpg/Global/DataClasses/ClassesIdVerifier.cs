using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TRPG.FightConstructor.CatalogClasses;
using TRPG.Global.BuffClasses;
using TRPG.Global.CreatureClasses;
using TRPG.Global.Others;
using TRPG.Global.SkillClasses;
using TRPG.Global.SpiritClasses;
using TRPG.Global.StatsClasses;
using Unity.VisualScripting;
using UnityEngine;

namespace TRPG.Global.DataClasses
{
    public static class ClassesIdVerifier
    {
        public static void AllIdentifiableVerifier(bool verbose = false)
        {
            IdentifiableVerifier<Buff>(verbose);
            IdentifiableVerifier<Creature>(verbose);
            IdentifiableVerifier<Skill>(verbose);
            IdentifiableVerifier<SkillPotential>(verbose);
            IdentifiableVerifier<Spirit>(verbose);
            IdentifiableVerifier<SpiritStats>(verbose);
            IdentifiableVerifier<SkillTree>(verbose);
        }

        
        public static void IdentifiableVerifier<T>(bool verbose = false) where T : Identifiable
        {
            Dictionary<int, List<T>> keyValuePairs = new Dictionary<int, List<T>>();
            foreach (Type type in Assembly.GetAssembly(typeof(T)).GetTypes().
                Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                T obj = (T)Activator.CreateInstance(type);
                if (obj.Id == 0)
                    Debug.LogWarning(typeof(T).Name + " have a type with Id 0, its preferable to be changed to keep Id 0 for debugging, type : " + obj.GetType().Name);
                if (keyValuePairs.Keys.Contains(obj.Id))
                    keyValuePairs[obj.Id].Add(obj);
                else
                    keyValuePairs.Add(obj.Id, new List<T> { obj });
            }
            List<int> conflicts = new List<int>();
            foreach (int i in keyValuePairs.Keys)
            {
                if (keyValuePairs[i].Count > 1)
                {
                    if(i != -1)
                        conflicts.Add(i);
                }
            }

            if (verbose)
            {
                string verb = typeof(T).Name + " Id verifier \nId used : \n";
                foreach (int i in keyValuePairs.Keys)
                {
                    verb += i + " / ";
                }
                Debug.Log(verb);
            }

            if (conflicts.Count > 0)
            {
                string err = "Conflict with " + typeof(T).Name + " id : \n";
                foreach (int i in conflicts)
                {
                    string line = "id : " + i + " shared by : ";
                    foreach (T obj in keyValuePairs[i])
                    {
                        line += obj.GetType().Name + " | ";
                    }
                    line += "\n";
                    err += line;
                }
                throw new Exception(err);
            }
        }
    }
}
