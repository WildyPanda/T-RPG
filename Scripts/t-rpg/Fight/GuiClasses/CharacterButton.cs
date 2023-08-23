using TRPG.Global.DataClasses.GuiClasses;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG.Fight.GuiClasses
{
    internal class CharacterButton
    {
        private GameObject characterButton; // The main GameObject of the CharacterButton
        private Image characterButtonImage; // The image of characterButton
        public CharacterButton(Transform parent)
        {
            // creation of characterButton and its image
            this.characterButton = new GameObject();
            this.characterButton.name = "CharacterButton";
            this.characterButton.transform.parent = parent;

            this.characterButtonImage = this.characterButton.AddComponent<Image>();
            this.characterButtonImage.rectTransform.anchorMin = new Vector2(.935f, 0);
            this.characterButtonImage.rectTransform.anchorMax = new Vector2(1, .115f);
            this.characterButtonImage.rectTransform.offsetMin = Vector2.zero;
            this.characterButtonImage.rectTransform.offsetMax = Vector2.zero;
            this.characterButtonImage.sprite = GUIData.characterButtonSprite;
        }
    }
}
