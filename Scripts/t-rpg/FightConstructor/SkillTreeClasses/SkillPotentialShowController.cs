using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using TRPG.FightConstructor.CatalogClasses;
using TRPG.Global.SkillClasses;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG.FightConstructor.SkillTreeClasses
{
    public class SkillPotentialShowController : MonoBehaviour
    {
        protected List<GameObject> skillTreeObjects = new List<GameObject>();
        protected int actSkillTree;

        public void Start()
        {
            TextMeshProUGUI tmp = this.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
            Slider slider = this.transform.GetChild(3).GetChild(1).GetComponent<Slider>();
            this.sliderChange(slider, tmp);
            slider.onValueChanged.AddListener((float unused) => this.sliderChange(slider, tmp));
        }

        public void init(SkillPotential sp)
        {
            Transform treeChoiceContent = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0);
            Transform content = this.transform.GetChild(2);
            GameObject SkilltreeButtonPrefabs = Resources.Load<GameObject>("Prefabs/FightConstructor/SkillTree/SkillTreeButton");
            foreach (SkillTree skillTree in sp.skillTrees)
            {
                skillTreeObjects.Add(skillTree.showGUI(content));
                GameObject button = GameObject.Instantiate(SkilltreeButtonPrefabs, treeChoiceContent);
                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = skillTree.Name;
                int index = skillTreeObjects.Count - 1;
                button.GetComponent<Button>().onClick.AddListener(() => changeSkillTree(index));
                skillTreeObjects[index].SetActive(false);
            }
            this.actSkillTree = 0;
            changeSkillTree(this.actSkillTree);
        }

        public void init(CreatureSkillPotential sp)
        {
            Transform treeChoiceContent = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0);
            Transform content = this.transform.GetChild(2);
            GameObject SkilltreeButtonPrefabs = Resources.Load<GameObject>("Prefabs/FightConstructor/SkillTree/SkillTreeButton");
            skillTreeObjects.Add(sp.skillTree.showGUI(content));
            GameObject button = GameObject.Instantiate(SkilltreeButtonPrefabs, treeChoiceContent);
            button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = sp.skillTree.Name;
            int index = skillTreeObjects.Count - 1;
            button.GetComponent<Button>().onClick.AddListener(() => changeSkillTree(index));
            skillTreeObjects[index].SetActive(false);
            this.actSkillTree = 0;
            changeSkillTree(this.actSkillTree);
        }

        protected void changeSkillTree(int index)
        {
            skillTreeObjects[this.actSkillTree].SetActive(false);
            skillTreeObjects[index].SetActive(true);
            this.actSkillTree = index;
        }

        public void sliderChange(Slider slider, TextMeshProUGUI tmp)
        {
            tmp.text = slider.value.ToString();
            zoom(slider.value);
        }

        public void zoom(float amount)
        {
            if (amount < .5f)
                amount = .5f;
            if (amount > 5f)
                amount = 5f;
            foreach(GameObject gameObject in skillTreeObjects)
            {
                gameObject.transform.GetChild(0).GetChild(0).GetChild(0).localScale = new Vector3(amount, amount, 1);
            }
        }
    }
}

