using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TRPG.Global.DataClasses.GuiClasses;

namespace TRPG.Fight.GuiClasses
{
    public class MovementBar
    {
        GameObject movementGUI;
        Image movementImage;
        GameObject movementTextObject;
        TextMeshProUGUI movementText;

        public MovementBar(Transform parent)
        {
            this.movementGUI = new GameObject();
            this.movementGUI.name = "MovementBar";
            this.movementGUI.transform.parent = parent;
            this.movementGUI.transform.position = new Vector3(this.movementGUI.transform.position.x, this.movementGUI.transform.position.y, 0);

            this.movementImage = this.movementGUI.AddComponent<Image>();
            this.movementImage.rectTransform.anchorMin = new Vector2(.45f, 0);
            this.movementImage.rectTransform.anchorMax = new Vector2(.5f, .115f);
            this.movementImage.rectTransform.offsetMin = new Vector2(0, 0);
            this.movementImage.rectTransform.offsetMax = new Vector2(0, 0);
            this.movementImage.sprite = GUIData.movementBarSprite;

            this.movementTextObject = new GameObject();
            this.movementTextObject.name = "MovementText";
            this.movementTextObject.transform.parent = movementGUI.transform;

            this.movementText = this.movementTextObject.AddComponent<TextMeshProUGUI>();
            this.movementText.rectTransform.anchorMin = new Vector2(.052f, .07f);
            this.movementText.rectTransform.anchorMax = new Vector2(.87f, .3f);
            this.movementText.rectTransform.offsetMin = new Vector2(0, 0);
            this.movementText.rectTransform.offsetMax = new Vector2(0, 0);
            this.movementText.alignment = TextAlignmentOptions.Center;
            this.movementText.text = "0/0";
            this.movementText.fontSize = 30;
        }

        public void update(int movement, int maxMovement)
        {
            this.movementText.text = movement + "/" + maxMovement;
        }
    }
}
