using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TRPG.Global.PlayerClasses.Util;
using TRPG.Global.DataClasses.GuiClasses;
using TRPG.Global.SkillClasses;

namespace TRPG.Fight.GuiClasses
{
    public class SkillBar
    {
        private List<Skill> skills; // List of skills shown
        private GameObject skillBar; // The main GameObject of the SkillBar
        private Image skillBarImage; // The image of skillBar
        private GameObject[] skillsViews; // GameObjects for the 5 skills shown
        private Image[] skillsViewsImages; // Images of the 5 skills shown


        private GameObject skillLiner; // The GameObject containing elements for navigating throught skills line

        private GameObject increaseLine; // The GameObject responsible for increasing skill line when clicked
        private Image increaseLineImage; // The image associated

        private GameObject showNbLine;// The GameObject responsible for showing the actual line
        private Image showNbLineImage;
        private GameObject showNbLineTextObject;// The GameObject for the text
        private TextMeshProUGUI showNbLineText;

        private GameObject decreaseLine;// The GameObject responsible for decreasiong skill line when clicked
        private Image decreaseLineImage;

        public int skillLine { get; private set; }// the current skill line




        public SkillBar(List<Skill> skills, Transform parent)
        {
            // init
            this.skillLine = 0;
            this.skills = skills;
            this.skillsViews = new GameObject[5];
            this.skillsViewsImages = new Image[5];

            // creation of skillBar and its image
            this.skillBar = new GameObject();
            this.skillBar.name = "SkillBar";
            this.skillBar.transform.parent = parent;

            this.skillBarImage = this.skillBar.AddComponent<Image>();
            this.skillBarImage.rectTransform.anchorMin = new Vector2(.55f, 0);
            this.skillBarImage.rectTransform.anchorMax = new Vector2(.935f, .115f);
            this.skillBarImage.rectTransform.offsetMin = new Vector2(0, 0);
            this.skillBarImage.rectTransform.offsetMax = new Vector2(0, 0);
            this.skillBarImage.sprite = GUIData.skillBarSprite;

            // creation of the 5 skills view and their image
            for (int i = 0; i < 5; i++)
            {
                this.skillsViews[i] = new GameObject();
                this.skillsViews[i].name = "Skill-" + i;
                this.skillsViews[i].transform.parent = this.skillBar.transform;

                this.skillsViewsImages[i] = this.skillsViews[i].AddComponent<Image>();
                this.skillsViewsImages[i].rectTransform.anchorMin = new Vector2(.02f+.16f*i, .1f);
                this.skillsViewsImages[i].rectTransform.anchorMax = new Vector2(.16f*(i+1), .9f);
                this.skillsViewsImages[i].rectTransform.offsetMax = new Vector2(0, 0);
                this.skillsViewsImages[i].rectTransform.offsetMin = new Vector2(0, 0);
                this.skillsViewsImages[i].sprite = GUIData.emptySkillSprite;
            }

            // creation of the skill liner
            this.skillLiner = new GameObject("SkillLiner", typeof(RectTransform));
            this.skillLiner.transform.SetParent(this.skillBar.transform);
            this.skillLiner.GetComponent<RectTransform>().anchorMin = new Vector2(.845f, .09f);
            this.skillLiner.GetComponent<RectTransform>().anchorMax = new Vector2(.98f, .91f);
            this.skillLiner.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            this.skillLiner.GetComponent<RectTransform>().offsetMax = Vector2.zero;


            // creation of the increaseLine and its image
            this.increaseLine = new GameObject();
            this.increaseLine.name = "IncreaseLine";
            this.increaseLine.transform.parent = this.skillLiner.transform;

            this.increaseLineImage = this.increaseLine.AddComponent<Image>();
            this.increaseLineImage.rectTransform.anchorMin = new Vector2(0, .7f);
            this.increaseLineImage.rectTransform.anchorMax = new Vector2(1f, 1);
            this.increaseLineImage.rectTransform.offsetMin = Vector2.zero;
            this.increaseLineImage.rectTransform.offsetMax = Vector2.zero;
            this.increaseLineImage.sprite = GUIData.increaseSkillLineSprite;

            // creation of the decreaseLine and its image
            this.decreaseLine = new GameObject();
            this.decreaseLine.name = "DecreaseLine";
            this.decreaseLine.transform.parent = this.skillLiner.transform;

            this.decreaseLineImage = this.decreaseLine.AddComponent<Image>();
            this.decreaseLineImage.rectTransform.anchorMin = new Vector2(0, 0);
            this.decreaseLineImage.rectTransform.anchorMax = new Vector2(1f, .3f);
            this.decreaseLineImage.rectTransform.offsetMin = Vector2.zero;
            this.decreaseLineImage.rectTransform.offsetMax = Vector2.zero;
            this.decreaseLineImage.sprite = GUIData.decreaseSkillLineSprite;

            // creation of the showLine and its image
            this.showNbLine = new GameObject();
            this.showNbLine.name = "ShowLine";
            this.showNbLine.transform.parent = this.skillLiner.transform;

            this.showNbLineImage = this.showNbLine.AddComponent<Image>();
            this.showNbLineImage.rectTransform.anchorMin = new Vector2(0, .35f);
            this.showNbLineImage.rectTransform.anchorMax = new Vector2(1f, .65f);
            this.showNbLineImage.rectTransform.offsetMin = Vector2.zero;
            this.showNbLineImage.rectTransform.offsetMax = Vector2.zero;
            this.showNbLineImage.sprite = GUIData.showSkillLineSprite;

            // creation of the text inside showLine
            this.showNbLineTextObject = new GameObject();
            this.showNbLineTextObject.name = "ShowLineText";
            this.showNbLineTextObject.transform.parent = this.showNbLine.transform;

            this.showNbLineText = this.showNbLineTextObject.AddComponent<TextMeshProUGUI>();
            this.showNbLineText.rectTransform.anchorMin = new Vector2(0.05f, .17f);
            this.showNbLineText.rectTransform.anchorMax = new Vector2(.95f, .83f);
            this.showNbLineText.rectTransform.offsetMax = Vector2.zero;
            this.showNbLineText.rectTransform.offsetMin = Vector2.zero;
            this.showNbLineText.alignment = TextAlignmentOptions.Center;
            this.showNbLineText.text = (this.skillLine + 1).ToString();
            this.showNbLineText.fontSize = 25;
            this.showNbLineText.color = Color.black;

            // updating images of the skills views
            this.updateSkillView();
        }

        public SkillBar(Transform parent) : this(new List<Skill>(), parent) { }

        protected void updateSkillView()
        {
            this.showNbLineText.text = (this.skillLine + 1).ToString();
            for (int i = 0; i < 5; i++)
            {
                if (this.skills.Count > i + 5 * this.skillLine)
                {
                    this.skillsViewsImages[i].sprite = this.skills[i + 5 * this.skillLine].sprite;
                }
                else
                {
                    this.skillsViewsImages[i].sprite = GUIData.emptySkillSprite;
                }
            }
        }

        public void skillClicked(int index)
        {

        }

        public void increaseSkillLine()
        {
            this.skillLine += 1;
            this.updateSkillView();
        }

        public void decreaseSkillLine()
        {
            if (this.skillLine > 0)
            {
                this.skillLine -= 1;
                this.updateSkillView();
            }
        }

        public void changeSkills(List<Skill> skills)
        {
            this.skills = skills;
            this.skillLine = 0;
            this.updateSkillView();
        }
    }
}