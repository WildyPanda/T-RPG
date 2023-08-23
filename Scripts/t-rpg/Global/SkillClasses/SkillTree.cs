using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.Others;
using UnityEngine;

namespace TRPG.Global.SkillClasses
{
    public abstract class SkillTree : Identifiable
    {
        // 1 -> neutral | 2-99 -> Elements ( X -> element.key + 2) | 100+ -> creature unique trees | 10000+ -> specials trees
        public abstract int Id { get; }
        public abstract string Name { get; }
        public SkillCell originSkill { get; protected set; }

        public List<Skill> unlockedSkills()
        {
            if(originSkill == null)
                return new List<Skill>();
            return originSkill.unlockedSkills();
        }

        public List<Skill> lockedSkills()
        {
            if (originSkill == null)
                return new List<Skill>();
            return originSkill.lockedSkills();
        }

        public GameObject showGUI(Transform parent)
        {
            if(originSkill == null)
                throw new Exception("No originSkill in " + this.GetType().Name);
            originSkill.initPosition();
            GameObject SkillTreePrefabs = Resources.Load<GameObject>("Prefabs/FightConstructor/SkillTree/SkillTree");
            GameObject SkillTreeObject = GameObject.Instantiate(SkillTreePrefabs, parent);
            Transform content = SkillTreeObject.transform.GetChild(0).GetChild(0).GetChild(0);
            RectTransform contentRect = content.GetComponent<RectTransform>();
            contentRect.sizeDelta = new Vector2(100 + 150 * this.originSkill.treeWidth, 100 + 150 * this.originSkill.treeHeight);
            this.originSkill.showGUI(contentRect);
            return SkillTreeObject;
        }

    }
}
