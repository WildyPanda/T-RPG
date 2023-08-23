using System.Collections.Generic;
using UnityEngine;
using TRPG.Global.PlayerClasses.Util;
using TRPG.Global.DataClasses;
using TRPG.FightConstructor.CatalogClasses;
using TRPG.Global.GroundClasses;
using TRPG.Global.Others;
using TRPG.Global.FighterClasses;
using UnityEngine.UI;
using TRPG.Global.DataClasses.GuiClasses;
using TMPro;
using System.Net.Sockets;
using UnityEngine.TextCore.Text;
using TRPG.Fight.EffectClasses;
using TRPG.Global.SkillClasses.SkillEffects;

namespace TRPG.Global.SkillClasses
{
    public abstract class Skill : Catalogable, Cloneable<Skill>, Identifiable
    {
        // unique id of the skill
        public abstract int Id { get; }
        // the name of the skill
        public string name { get; protected set; } = "defaultSkill";
        // the description of the skill
        public string description { get; protected set; } = "no description";

        // all the effects of the skill
        public List<SkillEffect> effects { get; protected set; }
        // the mana cost of the skill
        public int cost { get; protected set; } = 0;
        // the range of the skill
        public int range { get; protected set; } = 0;
        // the cooldown of the skill :
        // 0 = useable every turns
        // X = unuseable for X turns
        // ex with cooldown 1, used on turn 1, reuseable on turn 3
        public int cooldown { get; protected set; } = 0;
        // the numbre of use by turn
        // only checked if cooldown = 0
        // 0 : no limits
        // X : useable X times by turns
        public int useByTurn { get; protected set; } = 0;
        // does the skill need lign of sight
        public bool needLOS { get; protected set; } = true;

        // the sprite of the skill
        public Sprite sprite { get; protected set; } = SpritesData.noTexture;

        public Skill()
        {
            this.effects = new List<SkillEffect>();
        }

        public Skill(Skill skill)
        {
            this.name = skill.name;
            this.description = skill.description;

            this.effects = Data.ListDeepCopy(skill.effects);
            this.cost = skill.cost;
            this.range = skill.range;
            this.cooldown = skill.cooldown;
            this.useByTurn = skill.useByTurn;
            this.needLOS = skill.needLOS;

            this.sprite = skill.sprite;

        }

        /* use the skill
         * do the effect all the targets in the area of effect
         */
        public virtual void useSkill(Ground ground, Fighter attacker, Vector2 AOECenter, Vector2 direction)
        {
            foreach(SkillEffect effect in this.effects)
            {
                foreach(Fighter target in effect.getTargets(ground, attacker, AOECenter, direction))
                {
                    effect.effect(attacker, target, attacker.team == target.team, attacker.Equals(target));
                }
            }
        }

        protected void addEffect(SkillEffect effect)
        {
            this.effects.Add(effect);
        }

        protected string completeDescription()
        {
            string completeDescription = this.description + "\n";
            completeDescription += "cost : " + this.cost.ToString() + "\n";
            completeDescription += "range : " + this.range.ToString() + "\n";
            if(this.cooldown != 0)
                completeDescription += "cooldown : " + this.cooldown.ToString() + "\n";
            if(this.cooldown == 0 && this.useByTurn != 0)
                completeDescription += "use by turn : " + this.useByTurn.ToString() + "\n";
            foreach (SkillEffect effect in this.effects)
            {
                completeDescription += effect.beforeDescLine() + effect.toDescriptionLine() + "\n";
            }
            return completeDescription;
        }

        protected GameObject toCreatureSpiritCell(Transform contentTransform, GameObject cellPrefabs, bool locked)
        {
            /* Cell (Gameobject)
             *  Sprites (Gameobject)
             *    SkillSprite (Image)
             *    AreaTypeSprite (Image)
             *    LOSSprite (Image)
             *  Texts (Gameobject)
             *    Name (TMP)
             *    Description (TMP)
             */
            GameObject cell = GameObject.Instantiate(cellPrefabs, contentTransform);
            cell.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = this.sprite;
            if (this.needLOS)
                cell.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = GUIData.LosTSprite;
            else
                cell.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = GUIData.LosFSprite;


            cell.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.name;
            string completeDescription = this.completeDescription();
            cell.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().spriteAsset = Resources.Load<TMP_SpriteAsset>("SpriteAssets/Skill/SkillTargets");
            cell.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = completeDescription;
            int nbLine = completeDescription.Split("\n").Length - 1;
            RectTransform cellTransform = cell.GetComponent<RectTransform>();
            RectTransform descTransform = cell.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
            if (!locked)
            {
                cellTransform.sizeDelta = new Vector2(cellTransform.sizeDelta.x, 35 + 15 * nbLine);
                descTransform.anchoredPosition = new Vector2(descTransform.anchoredPosition.x, 7.5f * nbLine);
            }
            else
            {
                cellTransform.sizeDelta = new Vector2(cellTransform.sizeDelta.x, 45 + 15 * nbLine);
                descTransform.anchoredPosition = new Vector3(descTransform.anchoredPosition.x, 10 + 7.5f * nbLine);
            }
            descTransform.sizeDelta = new Vector2(descTransform.sizeDelta.x, 15 * nbLine);
            return cell;
        }

        public GameObject toCreatureCell(Transform contentTransform, bool locked = false)
        {
            GameObject cellPrefabs;
            if (!locked)
                cellPrefabs = Resources.Load<GameObject>("Prefabs/FightConstructor/Catalog/Creature/CreatureUnlockedSkillCell");
            else
                cellPrefabs = Resources.Load<GameObject>("Prefabs/FightConstructor/Catalog/Creature/CreatureLockedSkillCell");
            return this.toCreatureSpiritCell(contentTransform, cellPrefabs, locked);
        }

        public GameObject toSpiritCell(Transform contentTransform)
        {
            GameObject cellPrefabs;
            cellPrefabs = Resources.Load<GameObject>("Prefabs/FightConstructor/Catalog/Spirit/SpiritSkillCell");
            return this.toCreatureSpiritCell(contentTransform, cellPrefabs, false);
        }

        public GameObject toPage(Transform catalog)
        {
            return new GameObject();
        }

        public abstract Skill Clone();
    }

    
}