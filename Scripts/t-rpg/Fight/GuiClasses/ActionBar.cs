using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TRPG.Global.DataClasses.GuiClasses;

namespace TRPG.Fight.GuiClasses
{
    public class ActionBar
    {
        GameObject actionGUI;
        Image actionImage;
        GameObject actionTextObject;
        TextMeshProUGUI actionText;
        
        public ActionBar(Transform parent)
        {
            this.actionGUI = new GameObject();
            this.actionGUI.name = "ActionBar";
            this.actionGUI.transform.parent = parent;
            this.actionGUI.transform.position = new Vector3(this.actionGUI.transform.position.x, this.actionGUI.transform.position.y, 0);

            this.actionImage = this.actionGUI.AddComponent<Image>();
            this.actionImage.rectTransform.anchorMin = new Vector2(.5f, 0);
            this.actionImage.rectTransform.anchorMax = new Vector2(.55f, .115f);
            this.actionImage.rectTransform.offsetMin = new Vector2(0, 0);
            this.actionImage.rectTransform.offsetMax = new Vector2(0, 0);
            this.actionImage.sprite = GUIData.actionBarSprite;

            this.actionTextObject = new GameObject();
            this.actionTextObject.name = "ActionText";
            this.actionTextObject.transform.parent = actionGUI.transform;

            this.actionText = this.actionTextObject.AddComponent<TextMeshProUGUI>();
            this.actionText.rectTransform.anchorMin = new Vector2(.13f, .07f);
            this.actionText.rectTransform.anchorMax = new Vector2(.948f, .3f);
            this.actionText.rectTransform.offsetMax = new Vector2(0, 0);
            this.actionText.rectTransform.offsetMin = new Vector2(0, 0);
            this.actionText.alignment = TextAlignmentOptions.Center;
            this.actionText.text = "0/0";
            this.actionText.fontSize = 30;


            this.actionGUI.SetActive(true);
        }

        public void update(int action, int maxAction)
        {
            this.actionText.text = action + "/" + maxAction;
        }
    }
}
