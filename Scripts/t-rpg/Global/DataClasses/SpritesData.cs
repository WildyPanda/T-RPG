using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TRPG.Global.DataClasses
{
    public static class SpritesData
    {
        public static Sprite noTexture = Resources.Load<Sprite>("Sprites/No-Texture");
        public static Sprite noTextureAlt = Resources.Load<Sprite>("Sprites/No-Texture-Alt");

        public static Sprite getSkillSprite(string skillName)
        {
            Sprite sprite = Resources.Load<Sprite>("Sprites/SkillSprites/ImageSprites/" + skillName);
            if(sprite == null)
            {
                return noTexture;
            }
            return sprite;
        }

        public static Sprite getCreatureFaceSprite(string creatureName)
        {
            Sprite sprite = Resources.Load<Sprite>("Sprites/CreatureSprites/FaceSprites/"+creatureName);
            if (sprite == null)
            {
                return noTexture;
            }
            return sprite;
        }

        public static Sprite getSpiritSprite(string spiritName)
        {
            Sprite sprite = Resources.Load<Sprite>("Sprites/SpiritSprites/" + spiritName);
            if (sprite == null)
            {
                return noTexture;
            }
            return sprite;
        }

        public static Sprite getFighterSprite(string fighterName)
        {
            Sprite sprite = Resources.Load<Sprite>("Sprites/SpiritSprites/" + fighterName);
            if (sprite == null)
            {
                return noTexture;
            }
            return sprite;
        }

        public static Sprite getElementSprite(string elementName)
        {
            Sprite sprite = Resources.Load<Sprite>("Sprites/ElementsSprites/" + elementName + "-Element");
            if (sprite == null)
            {
                return noTexture;
            }
            return sprite;
        }

        public static Sprite getPlayerFaceSprite(string playerName)
        {
            Sprite sprite = Resources.Load<Sprite>("Sprites/PlayerSprites/FaceSprites/" + playerName);
            if (sprite == null)
            {
                return noTexture;
            }
            return sprite;
        }

    }
}
