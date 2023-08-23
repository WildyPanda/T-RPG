using TRPG.Global.FighterClasses;
using UnityEngine;

namespace TRPG.Fight.GuiClasses
{
    public class FighterShow
    {
        public Vector2 position { get; private set; }
        private GameObject fighterObject;
        private SpriteRenderer fighterImage;

        public FighterShow(Fighter fighter, Transform parent)
        {
            //fighterObject = new GameObject(fighter.name);
            fighterObject.transform.parent = parent;
            fighterObject.transform.localScale = new Vector3(10, 10, 0);

            fighterImage = fighterObject.AddComponent<SpriteRenderer>();
            //fighterImage.sprite = fighter.sprites.fighterSprite;
        }

        public void Move(Vector2 position)
        {
            fighterObject.transform.position = new Vector3(2.5f + position.x * 5, 2.5f + position.y * 5, 0);
        }
    }
}
