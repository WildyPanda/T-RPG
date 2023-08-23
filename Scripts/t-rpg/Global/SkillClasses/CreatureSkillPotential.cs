using System;
using System.Collections.Generic;
using TRPG.Global.DataClasses;
using TRPG.Global.Others;
using TRPG.FightConstructor.SkillTreeClasses;
using UnityEngine;

namespace TRPG.Global.SkillClasses
{
    public abstract class CreatureSkillPotential: Identifiable
    {
        public abstract int Id { get; }

        // neutral + 1 by elements + 1 unique
        // to get the skillTree of an element : skillTrees[element.key+1]
        public SkillTree skillTree { get; protected set; }
        // no affinity for neutral and unique
        // to get the affinity of an element : skillTrees[element.key]
        public float[] affinity { get; protected set; }

        // every level give certain amount of skill points
        // skill tree, need conditions for unlocking skills

        public CreatureSkillPotential()
        {
            this.affinity = new float[ElementData.nbElements];
        }

        public float getElementAffinity(int elementKey)
        {
            if (elementKey < 0 || elementKey >= ElementData.nbElements)
                throw new Exception("Invalid element key : " + elementKey + " in SkillPontential.getElementAffinity, must be between 0 and " + (ElementData.nbElements - 1));
            return this.affinity[elementKey];
        }

        public List<Skill> unlockedSkills()
        {
            List<Skill> skills = new List<Skill>();
            skills.AddRange(skillTree.unlockedSkills());
            return skills;
        }

        public List<Skill> lockedSkills()
        {
            List<Skill> skills = new List<Skill>();
            skills.AddRange(skillTree.lockedSkills());
            return skills;
        }

        public void showGUI(Transform parent)
        {
            GameObject skillPotentialPrefabs = Resources.Load<GameObject>("Prefabs/FightConstructor/SkillTree/SkillPotential");
            GameObject skillPotentialObject = GameObject.Instantiate(skillPotentialPrefabs, parent);
            skillPotentialObject.GetComponent<SkillPotentialShowController>().init(this);
        }
    }
}
