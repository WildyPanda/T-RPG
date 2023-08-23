using Newtonsoft.Json;
using System;
using UnityEngine;

namespace TRPG.Global.DataClasses
{
    public static class FighterData
    {
        public static FighterSprites Player1Sprites = new FighterSprites(true, "1");
        public static FighterSprites Player2Sprites = new FighterSprites(true, "2");
        public static FighterSprites Creature1Sprites = new FighterSprites(false, "1");
        public static FighterSprites Creature2Sprites = new FighterSprites(false, "2");
    }

    public class FighterSprites
    {
        public Sprite faceSprite { get; set; }
        
        public FighterSprites(bool isPlayer, string name)
        {
            if(!isPlayer)
            {
                this.faceSprite = SpritesData.getCreatureFaceSprite(name);
            }
            else
            {
                this.faceSprite = SpritesData.noTexture;
            }
        }
    }
}
