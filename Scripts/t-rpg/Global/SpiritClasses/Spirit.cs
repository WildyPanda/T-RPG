using System.Collections.Generic;
using UnityEngine;
using TRPG.Global.SkillClasses;
using TRPG.Global.StatsClasses;
using TRPG.FightConstructor.CatalogClasses;
using TRPG.Global.Others;
using TMPro;
using TRPG.Global.DataClasses;
using UnityEngine.UI;
using TRPG.FightConstructor;

namespace TRPG.Global.SpiritClasses
{
    public abstract class Spirit : Catalogable, Identifiable
    {
        public abstract int Id { get; }
        public string name { get; protected set; }
        public string description { get; protected set; }

        public List<Skill> skills { get; protected set; }
        public SpiritStats stats { get; protected set; }

        public Sprite sprite { get; protected set; }

        protected void createSpiritElementCells(Transform contentTransform)
        {
            for (int i = 0; i < ElementData.nbElements; i++)
            {
                /* CreatureElementCell
                 *   ElementImage
                 *   Attack
                 *     AttackDirect
                 *     AttackPercent
                 *   Defense
                 *     DefenseDirect
                 *     DefensePercent
                 */
                GameObject cellPrefabs = Resources.Load<GameObject>("Prefabs/FightConstructor/Catalog/Spirit/SpiritElementCell");
                GameObject cell = GameObject.Instantiate(cellPrefabs, contentTransform);
                cell.transform.GetChild(0).GetComponent<Image>().sprite = ElementData.elements[i].sprite;
                cell.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.stats.attack[i].ToString();
                cell.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = this.stats.percentAttack[i].ToString();
                cell.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.stats.defense[i].ToString();
                cell.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = this.stats.percentDefense[i].ToString();
            }
        }

        public GameObject toPage(Transform catalog)
        {
            GameObject pagePrefabs = Resources.Load<GameObject>("Prefabs/FightConstructor/Catalog/Spirit/SpiritPage");
            GameObject page = GameObject.Instantiate(pagePrefabs, catalog);
            page.name = name;
            Transform skillsContent = page.transform.GetChild(1).GetChild(0).GetChild(0);
            foreach (Skill skill in this.skills)
            {
                skill.toSpiritCell(skillsContent);
            }
            Transform elementsContent = page.transform.GetChild(0).GetChild(3).GetChild(1).GetChild(0).GetChild(0);
            this.createSpiritElementCells(elementsContent);
            page.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = this.sprite;
            page.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = this.name;
            page.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.stats.health.ToString();
            page.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = this.stats.percentHealth.ToString();
            page.transform.GetChild(0).GetChild(2).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.stats.speed.ToString();
            page.transform.GetChild(0).GetChild(2).GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>().text = this.stats.percentSpeed.ToString();
            page.transform.GetChild(0).GetChild(2).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.stats.globalAttack.ToString();
            page.transform.GetChild(0).GetChild(2).GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text = this.stats.percentGlobalAttack.ToString();
            page.transform.GetChild(0).GetChild(2).GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.stats.globalDefense.ToString();
            page.transform.GetChild(0).GetChild(2).GetChild(5).GetChild(1).GetComponent<TextMeshProUGUI>().text = this.stats.percentGlobalDefense.ToString();
            return page;
        }

        public void toInventoryCell(GameObject Inventory, int index)
        {
            this.toInventoryCell(Inventory.transform.GetChild(1).GetChild(index), index);
        }

        public void toInventoryCell(Transform parent, int index)
        {
            GameObject cellPrefabs = Resources.Load<GameObject>("Prefabs/FightConstructor/Inventory/SpiritInventoryCell");
            GameObject cell = GameObject.Instantiate(cellPrefabs, parent);
            cell.transform.GetChild(0).GetComponent<Image>().sprite = this.sprite;
            cell.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = this.name;
            cell.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => Camera.main.GetComponent<Controller>().removeSpirit(index));
        }
    }
}