using TRPG.Global.DataClasses.GuiClasses;
using UnityEngine;
using UnityEngine.UI;
namespace TRPG.Fight.GuiClasses
{
    internal class ParameterButton
    {
        private GameObject parameterButton; // The main GameObject of the ParameterButton
        private Image parameterButtonImage; // The image of parameterButton

        public ParameterButton(Transform parent) {
            // creation of parameterButton and its image
            this.parameterButton = new GameObject();
            this.parameterButton.name = "ParameterButton";
            this.parameterButton.transform.parent = parent;

            this.parameterButtonImage = this.parameterButton.AddComponent<Image>();
            this.parameterButtonImage.rectTransform.anchorMin = new Vector2(0, 0);
            this.parameterButtonImage.rectTransform.anchorMax = new Vector2(.065f, .115f);
            this.parameterButtonImage.rectTransform.offsetMax = Vector2.zero;
            this.parameterButtonImage.rectTransform.offsetMin = Vector2.zero;
            this.parameterButtonImage.sprite = GUIData.parameterButtonSprite;
        }
    }
}
