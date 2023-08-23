using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TRPG.Global.DataClasses.GuiClasses;

namespace TRPG.Fight.GuiClasses
{
    public class LifeBar
    {
        private GameObject lifeGUI;
        private Image lifeImage;
        private GameObject lifeTextObject;
        private TextMeshProUGUI lifeText;

        public LifeBar(Transform parent) { 
            this.lifeGUI = new GameObject("LifeBar");
            this.lifeGUI.transform.parent = parent;

            this.lifeImage = this.lifeGUI.AddComponent<Image>();
            this.lifeImage.rectTransform.anchorMin = new Vector2(.45f, 0);
            this.lifeImage.rectTransform.anchorMax = new Vector2(.55f, .2f);
            this.lifeImage.rectTransform.offsetMax = new Vector2(0, 0);
            this.lifeImage.rectTransform.offsetMin = new Vector2(0, 0);
            this.lifeImage.sprite = GUIData.lifeBarSprite;

            this.lifeTextObject = new GameObject("LifeText");
            this.lifeTextObject.transform.parent = lifeGUI.transform;

            this.lifeText = this.lifeTextObject.AddComponent<TextMeshProUGUI>();
            this.lifeText.rectTransform.anchorMin = new Vector2(.04f, .52f);
            this.lifeText.rectTransform.anchorMax = new Vector2(.96f, .64f);
            this.lifeText.rectTransform.offsetMax = new Vector2(0, 0);
            this.lifeText.rectTransform.offsetMin = new Vector2(0, 0);
            this.lifeText.alignment = TextAlignmentOptions.Center;
            this.lifeText.text = "0/0";
            this.lifeText.fontSize = 30;
        }

        public void update(int life, int maxLife)
        {
            this.lifeText.text = life + "/" + maxLife;
        }
    }
}
