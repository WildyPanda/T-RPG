using System;
using TRPG.Global.DataClasses.GuiClasses;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG.Fight.GuiClasses
{
    public class CharacterOrberBar
    {
        GameObject characterOrderBarObject;

        GameObject casingPrefab;
        GameObject separatorPrefab;

        public CharacterOrberBar(Transform parent)
        {
            characterOrderBarObject = new GameObject("CharacterOrder");
            characterOrderBarObject.transform.parent = parent;
            RectTransform rect = characterOrderBarObject.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(.945f, .135f);
            rect.anchorMax = new Vector2(.99f, 1);
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;

            GameObject casings = new GameObject("Casings");
            casings.transform.parent = characterOrderBarObject.transform;
            RectTransform casingTransform = casings.AddComponent<RectTransform>();
            casingTransform.anchorMin = new Vector2(0, 0);
            casingTransform.anchorMax = new Vector2(1, 1);
            casingTransform.offsetMin = Vector2.zero;
            casingTransform.offsetMax = Vector2.zero;

            GameObject separators = new GameObject("Separators");
            separators.transform.parent = characterOrderBarObject.transform;
            RectTransform separatorsTransform = separators.AddComponent<RectTransform>();
            separatorsTransform.anchorMin = new Vector2(0, 0);
            separatorsTransform.anchorMax = new Vector2(1, 1);
            separatorsTransform.offsetMin = Vector2.zero;
            separatorsTransform.offsetMax = Vector2.zero;

            casingPrefab = Resources.Load<GameObject>("Prefabs/Fight/CharacterOrder/FighterCasing");
            separatorPrefab = Resources.Load<GameObject>("Prefabs/Fight/CharacterOrder/separator");
            for (int i = 0; i < 9; i++)
            {
                GameObject.Instantiate(casingPrefab, casings.transform, false);
            }
            GameObject.Instantiate(separatorPrefab, separators.transform, false);
        }

        public void nextTurn(Sprite actualFighterSprite, Sprite[] fighterSprite, bool[] isPlayer)
        {
            if (fighterSprite.Length != 8 || isPlayer.Length != 8)
                throw new Exception("Invalid arrays in CharacterOrderBar.nextTurn : The size of the arrays must be 8");
            Transform casings = characterOrderBarObject.transform.GetChild(0);
            Transform separators = characterOrderBarObject.transform.GetChild(1);
            for (int i = 1; i < separators.childCount; i++)
            {
                GameObject.Destroy(separators.GetChild(i).gameObject);
            }

            casings.GetChild(0).GetChild(0).GetComponent<Image>().sprite = actualFighterSprite;
            float Y = .105f;
            for(int i = 1; i < 9; i++)
            {
                casings.GetChild(i).GetChild(0).GetComponent<Image>().sprite = fighterSprite[i-1];

                if (i != 1 && isPlayer[i - 1])
                {
                    RectTransform sepRect = GameObject.Instantiate(separatorPrefab, separators, false).GetComponent<RectTransform>();
                    sepRect.anchorMin = new Vector2(.3f, Y);
                    Y += .01f;
                    sepRect.anchorMax = new Vector2(.7f, Y);
                    sepRect.offsetMin = Vector2.zero;
                    sepRect.offsetMax = Vector2.zero;
                }

                Y += .005f;
                // value if isPlayer
                float xMin = .05f;
                float xMax = .95f;
                float yDiff = .08f;
                if(!isPlayer[i - 1])
                {
                    xMin = .15f;
                    xMax = .85f;
                    yDiff = .06f;
                }
                RectTransform rect = casings.GetChild(i).GetComponent<RectTransform>();
                rect.anchorMin = new Vector2(xMin, Y);
                rect.anchorMax = new Vector2(xMax, Y + yDiff);
                rect.offsetMin = Vector2.zero;
                rect.offsetMax = Vector2.zero;

                Y += yDiff + .005f;

            }

        }
    }
}
