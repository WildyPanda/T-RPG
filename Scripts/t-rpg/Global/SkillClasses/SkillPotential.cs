using System;
using System.Collections.Generic;
using TRPG.Global.DataClasses;
using TRPG.Global.Others;
using TRPG.Global.SkillClasses.SkillTrees.Elements;
using TRPG.FightConstructor.SkillTreeClasses;
using UnityEngine;

namespace TRPG.Global.SkillClasses
{
    public abstract class SkillPotential: Identifiable
    {
        // 1-999 : creatures | 1000+ : players
        public abstract int Id { get; }

        // to get the skillTree of an element : skillTrees[element.key+1]
        public List<SkillTree> skillTrees { get; protected set; }

        // to get the affinity of an element : skillTrees[element.key]
        public float[] affinity { get; protected set; }

        // every level give certain amount of skill points
        // skill tree, need conditions for unlocking skills

        public SkillPotential()
        {
            this.affinity = new float[ElementData.nbElements];
            this.skillTrees = new List<SkillTree>();
        }

        public float getElementAffinity(int elementKey)
        {
            if (elementKey < 0 || elementKey >= ElementData.nbElements)
                throw new Exception("Invalid element key : " + elementKey + " in SkillPontential.getElementAffinity, must be between 0 and " + (ElementData.nbElements - 1));
            return this.affinity[elementKey];
        }

        public SkillTree getTree(int index)
        {
            if (index >= this.skillTrees.Count || index < 0)
                throw new Exception("Invalid skilltree index in SkillPotential");
            return this.skillTrees[index];
        }

        public List<Skill> unlockedSkills()
        {
            List<Skill> skills = new List<Skill>();
            foreach (SkillTree skillTree in this.skillTrees)
            {
                skills.AddRange(skillTree.unlockedSkills());
            }
            return skills;
        }

        public List<Skill> lockedSkills()
        {
            List<Skill> skills = new List<Skill>();
            foreach (SkillTree skillTree in this.skillTrees)
            {
                skills.AddRange(skillTree.lockedSkills());
            }
            return skills;
        }

        public List<Skill> uniqueUnlockedSkills()
        {
            List<Skill> skills = new List<Skill>();
            skills.AddRange(this.skillTrees[this.skillTrees.Count-1].unlockedSkills());
            return skills;
        }

        public List<Skill> uniqueLockedSkills()
        {
            List<Skill> skills = new List<Skill>();
            skills.AddRange(this.skillTrees[this.skillTrees.Count - 1].lockedSkills());
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
