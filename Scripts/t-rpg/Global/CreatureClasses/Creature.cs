using System.Collections.Generic;
using UnityEngine;
using TRPG.Global.PlayerClasses.Util;
using TRPG.Global.DataClasses;
using TRPG.Global.StatsClasses;
using System;
using TRPG.Global.SkillClasses;
using TRPG.FightConstructor.CatalogClasses;
using TRPG.Global.Others;
using UnityEngine.UI;
using TMPro;
using Unity.Burst.CompilerServices;
using TRPG.FightConstructor;
using System.Reflection;

namespace TRPG.Global.CreatureClasses
{
    public abstract class Creature : Fightable, Catalogable, Identifiable
    {
        public abstract int Id { get; }
        public string name { get; protected set; }
        public string description { get; protected set; }

        public int level { get; protected set; }
        public int stage { get; protected set; }
        public Stats stats { get; protected set; }
        public SkillPotential skillPotential { get; protected set; }

        public FighterSprites sprites { get; protected set; }
        public Sprite spellSprite { get; protected set; }

        protected void createCreatureElementCells(Transform contentTransform)
        {
            for(int i = 0; i < ElementData.nbElements; i++)
            {
                /* CreatureElementCell
                 *   ElementImage
                 *   Attack
                 *     AttackText
                 *   Defense
                 *     DefenseText
                 *   Affinity
                 *     AffinityText
                 */
                GameObject cellPrefabs = Resources.Load<GameObject>("Prefabs/FightConstructor/Catalog/Creature/CreatureElementCell");
                GameObject cell = GameObject.Instantiate(cellPrefabs, contentTransform);
                cell.transform.GetChild(0).GetComponent<Image>().sprite = ElementData.elements[i].sprite;
                cell.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.stats.getAttack(i).ToString();
                cell.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.stats.getDefense(i).ToString();
                cell.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.skillPotential.getElementAffinity(i).ToString();
            }
        }

        public GameObject toPage(Transform catalog)
        {
            GameObject pagePrefabs = Resources.Load<GameObject>("Prefabs/FightConstructor/Catalog/Creature/CreaturePage");
            GameObject page = GameObject.Instantiate(pagePrefabs, catalog);
            page.name = name;
            Transform skillsContent = page.transform.GetChild(1).GetChild(0).GetChild(0);
            foreach(Skill skill in skillPotential.uniqueUnlockedSkills())
            {
                skill.toCreatureCell(skillsContent);
            }
            foreach (Skill skill in skillPotential.uniqueLockedSkills())
            {
                skill.toCreatureCell(skillsContent, true);
            }
            Transform elementsContent = page.transform.GetChild(0).GetChild(10).GetChild(1).GetChild(0).GetChild(0);
            this.createCreatureElementCells(elementsContent);
            Controller ctr = Camera.main.GetComponent<Controller>();
            page.transform.GetChild(1).GetChild(3).GetComponent<Button>().onClick.AddListener(() => ctr.showSkillPotential(this.skillPotential));
            page.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = this.sprites.faceSprite;
            page.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = this.name;
            page.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.level.ToString();
            page.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.stage.ToString();
            page.transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.stats.getHealth().ToString();
            page.transform.GetChild(0).GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.stats.getSpeed().ToString();
            page.transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.stats.getGlobalAttack().ToString();
            page.transform.GetChild(0).GetChild(7).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.stats.getGlobalDefense().ToString();
            page.transform.GetChild(0).GetChild(8).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.stats.getActionPoint().ToString();
            page.transform.GetChild(0).GetChild(9).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.stats.getMovement().ToString();
            return page;
        }

        public void toInventoryCell(GameObject Inventory, int index)
        {
            this.toInventoryCell(Inventory.transform.GetChild(0).GetChild(index), index);
        }

        public void toInventoryCell(Transform parent, int index)
        {
            GameObject cellPrefabs = Resources.Load<GameObject>("Prefabs/FightConstructor/Inventory/CreatureInventoryCell");
            GameObject cell = GameObject.Instantiate(cellPrefabs, parent);
            cell.transform.GetChild(0).GetComponent<Image>().sprite = this.sprites.faceSprite;
            cell.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.name;
            cell.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.level.ToString();
            cell.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.level.ToString();
            cell.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => Camera.main.GetComponent<Controller>().removeCreature(index));
        }

        public List<Skill> GetSkills()
        {
            return this.skillPotential.unlockedSkills();
        }
    }
}