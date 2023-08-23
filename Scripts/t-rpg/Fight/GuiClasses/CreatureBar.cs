using TRPG.Global.DataClasses;
using TRPG.Global.DataClasses.GuiClasses;
using UnityEngine;
using UnityEngine.UI;
using TRPG.Global.FighterClasses.states;

namespace TRPG.Fight.GuiClasses
{
    public class CreatureBar
    {
        private CreatureState[] creatures; // List of creatures shown
        private GameObject creatureBar; // The main GameObject of the CreatureBar
        private Image creatureBarImage; // The image of creatureBar
        private GameObject[] creaturesViews; // GameObjects for the 6 creatures shown
        private Image[] creaturesViewsImages; // Images of the 6 creatures shown

        public CreatureBar(CreatureState[] creatures, Transform parent)
        {
            // init
            this.creatures = creatures;
            this.creaturesViews = new GameObject[Data.maxCreatures];
            this.creaturesViewsImages = new Image[Data.maxCreatures];

            // creation of creatureBar and its image
            this.creatureBar = new GameObject();
            this.creatureBar.name = "CreatureBar";
            this.creatureBar.transform.parent = parent;

            this.creatureBarImage = this.creatureBar.AddComponent<Image>();
            this.creatureBarImage.rectTransform.anchorMin = new Vector2(.065f, 0);
            this.creatureBarImage.rectTransform.anchorMax = new Vector2(.45f, .115f);
            this.creatureBarImage.rectTransform.offsetMax = Vector2.zero;
            this.creatureBarImage.rectTransform.offsetMin = Vector2.zero;
            this.creatureBarImage.sprite = GUIData.creatureBarSprite;

            // creation of the 6 creatures view and their image
            for (int i = 0; i < Data.maxCreatures; i++)
            {
                this.creaturesViews[i] = new GameObject();
                this.creaturesViews[i].name = "Creature-" + i;
                this.creaturesViews[i].transform.parent = this.creatureBar.transform;

                this.creaturesViewsImages[i] = this.creaturesViews[i].AddComponent<Image>();
                this.creaturesViewsImages[i].rectTransform.anchorMin = new Vector2(.03f + .16f * i, .1f);
                this.creaturesViewsImages[i].rectTransform.anchorMax = new Vector2(.17f + .16f * i, .9f);
                this.creaturesViewsImages[i].rectTransform.offsetMax = Vector2.zero;
                this.creaturesViewsImages[i].rectTransform.offsetMin = Vector2.zero;
                this.creaturesViewsImages[i].sprite = GUIData.emptyCreatureSprite;
            }
            // updating images of the creatures views
            this.updateCreatureView();
        }

        public CreatureBar(Transform parent) : this(new CreatureState[Data.maxCreatures], parent) { }

        protected void updateCreatureView()
        {
            for (int i = 0; i < Data.maxCreatures; i++)
            {
                if (this.creatures.Length > i && this.creatures[i] != null)
                {
                    this.creaturesViewsImages[i].sprite = this.creatures[i].spellSprite;
                }
                else
                {
                    this.creaturesViewsImages[i].sprite = GUIData.emptyCreatureSprite;
                }
            }
        }

        public void changeCreatures(CreatureState[] creatures)
        {
            this.creatures = creatures;
            updateCreatureView();
        }

        public void greyingCreature(int index)
        {
            if (index < Data.maxCreatures && index >= 0)
            {
                creaturesViewsImages[index].color = Color.grey;
            }
        }

        public void greyingAllCreatures()
        {
            for (int i = 0; i < Data.maxCreatures; i++)
            {
                creaturesViewsImages[i].color = Color.grey;
            }
        }

        public void unGreyingCreature(int index)
        {
            if (index < Data.maxCreatures && index >= 0)
            {
                creaturesViewsImages[index].color = Color.white;
            }   
        }

        public void unGreyingAllCreatures()
        {
            for (int i = 0; i < Data.maxCreatures; i++)
            {
                creaturesViewsImages[i].color = Color.white;
            }
        }
    }
}
