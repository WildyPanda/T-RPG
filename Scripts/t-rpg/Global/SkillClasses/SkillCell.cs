using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.SkillClasses.Skills;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG.Global.SkillClasses
{
    public class SkillCell
    {
        public bool originSkill { get; protected set; }
        public SkillCell skillRequired { get; protected set; }
        public int cost { get; protected set; }
        public Type skillType { get; protected set; }
        public List<SkillCell> nextSkills { get; protected set; }

        public Vector2 position { get; protected set; }
        public int treeWidth { get; protected set; }
        public int treeHeight { get; protected set; }

        public bool unlocked { get; protected set; }

        public SkillCell(Type skillType)
        {
            this.unlocked = true;
            this.skillType = skillType;
            this.nextSkills = new List<SkillCell>();
            this.position = new Vector2();
            this.originSkill = true;
            checkSkillType();
        }

        public SkillCell(SkillCell skillRequired, int cost, Type skillType)
        {
            this.unlocked = false;
            this.cost = cost;
            this.skillType = skillType;
            this.nextSkills = new List<SkillCell>();
            this.skillRequired = skillRequired;
            this.position = new Vector2();
            this.originSkill = false;
            checkSkillType();
        }

        protected void checkSkillType()
        {
            if (!this.skillType.IsClass)
                throw new Exception("Error in SkillCell creation : invalid Skill Type : isn't a class");
            if(this.skillType.IsAbstract)
                throw new Exception("Error in SkillCell creation : invalid Skill Type : is abstract");
            if(!this.skillType.IsSubclassOf(typeof(Skill)))
                throw new Exception("Error in SkillCell creation : invalid Skill Type : isn't a subclass of skill");
        }

        public Skill getSkillInstance()
        {
            return (Skill)Activator.CreateInstance(this.skillType);
        }

        public void AddNextSkill(Type nextSkill, int cost = 0)
        {
            this.nextSkills.Add(new SkillCell(this, cost, nextSkill));
        }

        public SkillCell getNextSkill(int index)
        {
            return this.nextSkills[index];
        }

        public bool canBeUnlocked()
        {
            return skillRequired.unlocked && !unlocked;
        }

        public void unlockSkill()
        {
            this.unlocked = true;
        }

        public void lockSkill()
        {
            this.unlocked = false;
        }

        public List<Skill> unlockedSkills()
        {
            if(!unlocked)
            {
                return new List<Skill>();
            }
            List<Skill> list = new List<Skill>();
            list.Add(this.getSkillInstance());
            foreach(SkillCell cell in this.nextSkills)
            {
                list.AddRange(cell.unlockedSkills());
            }
            return list;
        }

        public List<Skill> lockedSkills()
        {
            List<Skill> list = new List<Skill>();
            if (!unlocked)
            {
                list.Add(this.getSkillInstance());
            }
            foreach(SkillCell cell in this.nextSkills)
            {
                list.AddRange(cell.lockedSkills());
            }
            return list;
        }


        public Vector2 getPosition()
        {
            if (this.position == null)
                throw new Exception("SkillCell : trying to get position without initializing it before");
            return this.position;
        }

        public void initPosition()
        {
            this.treeWidth = this.initPositionBase();
            this.initPositionCenter();
            this.treeHeight = Mathf.Abs(this.getMinY()) + 1;
        }

        // init the X position of all the last unlocked skill for every branches
        protected int initPositionBase(int y = 0, int x = 0)
        {
            if(this.nextSkills.Count == 0)
            {
                this.position = new Vector2(x, y);
                return x + 1;
            }
            else
            {
                int xTmp = x;
                foreach (SkillCell cell in this.nextSkills)
                {
                    xTmp = cell.initPositionBase(y-1, xTmp);
                }
                return xTmp;
            }

        }

        protected void initPositionCenter(int y = 0)
        {
            if (this.nextSkills.Count != 0)
            {
                float x = 0;
                foreach (SkillCell cell in this.nextSkills)
                {
                    cell.initPositionCenter(y - 1);
                    x += cell.position.x;
                }
                this.position = new Vector2(x / this.nextSkills.Count, y);
            }
        }

        protected int getMinY()
        {
            if (this.nextSkills.Count == 0)
                return (int)this.position.y;
            float ymin = 0;
            foreach(SkillCell cell in this.nextSkills)
            {
                ymin = Mathf.Min(ymin, cell.getMinY());
            }
            return (int)ymin;
        }

        public void showGUI(Transform parent)
        {
            GameObject SkillCellPrefabs = Resources.Load<GameObject>("Prefabs/FightConstructor/SkillTree/SkillCell");
            GameObject SkillCellObject = GameObject.Instantiate(SkillCellPrefabs, parent.GetChild(1));
            RectTransform SkillCellRectTransform = SkillCellObject.GetComponent<RectTransform>();
            SkillCellRectTransform.anchorMin = new Vector2(0, 1);
            SkillCellRectTransform.GetChild(0).GetComponent<Image>().sprite = this.getSkillInstance().sprite;
            SkillCellRectTransform.anchorMax = new Vector2(0, 1);
            Vector2 anchoredPosition = new Vector2(100, -100) + this.position * 150; ;
            SkillCellRectTransform.anchoredPosition = anchoredPosition;
            if (!this.originSkill)
            {
                GameObject line = new GameObject("line");
                line.transform.SetParent(parent.GetChild(0), false);
                Image lineImage = line.AddComponent<Image>();
                lineImage.color = Color.black;
                RectTransform lineRectTransform = line.GetComponent<RectTransform>();
                lineRectTransform.anchorMin = new Vector2(0, 1);
                lineRectTransform.anchorMax = new Vector2(0, 1);
                lineRectTransform.anchoredPosition = new Vector2((this.skillRequired.position.x + this.position.x) / 2 * 150 + 100, (this.skillRequired.position.y + this.position.y) / 2 * 150 - 100);
                float adj = this.skillRequired.position.x - this.position.x;
                float opp = this.skillRequired.position.y - this.position.y;
                line.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(opp, adj));
                lineRectTransform.sizeDelta = new Vector2(Mathf.Sqrt(Mathf.Pow(adj, 2) + Mathf.Pow(opp, 2)) * 150, 10);
            }
            foreach(SkillCell cell in this.nextSkills)
            {
                cell.showGUI(parent);
            }
        }
    }
}
