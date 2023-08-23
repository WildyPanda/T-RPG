using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TRPG.Global.PlayerClasses;
using TRPG.Global.DataClasses.GuiClasses;
using TRPG.Global.SpiritClasses;

namespace TRPG.Fight.gui
{
    public class SpiritBar
    {
        private List<Spirit> spirits; // List of spirits shown
        private GameObject spiritBar; // The main GameObject of the SpiritBar
        private Image spiritBarImage; // The image of spiritBar
        private GameObject[] spiritsViews; // GameObjects for the 3 spirits shown
        private Image[] spiritsViewsImages; // Images of the 3 spirits shown

        public SpiritBar(List<Spirit> spirits, Transform parent)
        {
            // init
            this.spirits = spirits;
            this.spiritsViews = new GameObject[3];
            this.spiritsViewsImages = new Image[3];

            // creation of spiritBar and its image
            this.spiritBar = new GameObject();
            this.spiritBar.name = "SpiritBar";
            this.spiritBar.transform.parent = parent;

            this.spiritBarImage = this.spiritBar.AddComponent<Image>();
            this.spiritBarImage.rectTransform.anchorMin = new Vector2(0, .115f);
            this.spiritBarImage.rectTransform.anchorMax = new Vector2(.065f, .46f);
            this.spiritBarImage.rectTransform.offsetMin = Vector2.zero;
            this.spiritBarImage.rectTransform.offsetMax = Vector2.zero;
            this.spiritBarImage.sprite = GUIData.spiritBarSprite;

            // creation of the 3 spirits view and their image
            for (int i = 0; i < 3; i++)
            {
                this.spiritsViews[i] = new GameObject();
                this.spiritsViews[i].name = "Spirit-" + i;
                this.spiritsViews[i].transform.parent = this.spiritBar.transform;

                this.spiritsViewsImages[i] = this.spiritsViews[i].AddComponent<Image>();
                this.spiritsViewsImages[i].rectTransform.anchorMin = new Vector2(.1f, .04f + .32f * i);
                this.spiritsViewsImages[i].rectTransform.anchorMax = new Vector2(.9f, .32f + .32f * i);
                this.spiritsViewsImages[i].rectTransform.offsetMin = Vector2.zero;
                this.spiritsViewsImages[i].rectTransform.offsetMax = Vector2.zero;
                this.spiritsViewsImages[i].sprite = GUIData.emptySpiritSprite;
            }
            // updating images of the spirits views
            this.updateSpiritView();
        }

        public SpiritBar(Transform parent) : this(new List<Spirit>(), parent) { }

        protected void updateSpiritView()
        {
            for (int i = 0; i < 3; i++)
            {
                if (this.spirits.Count > i)
                {
                    this.spiritsViewsImages[i].sprite = this.spirits[i].sprite;
                }
                else
                {
                    this.spiritsViewsImages[i].sprite = GUIData.emptySpiritSprite;
                }
            }
        }

        public void changeSpirits(List<Spirit> spirits)
        {
            this.spirits = spirits;
            updateSpiritView();
        }
    }
}
