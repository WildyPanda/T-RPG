using System.Collections.Generic;
using TRPG.Global.DataClasses.GuiClasses;
using TRPG.Global.GroundClasses;
using UnityEngine;

namespace TRPG.Fight.GuiClasses
{
    public class GroundVisual
    {
        public Ground ground { get; private set; }
        public Cell[][] cells { get; private set; }

        public GameObject groundObject { get; private set; }
        public GameObject[][] gameobjects { get; private set; }
        public SpriteRenderer[][] spriteRenderers { get; private set; }

        
        public GroundVisual(Ground ground)
        {
            this.ground = ground;
            this.cells = ground.GetCells();
            int X = this.cells.Length;
            int Y = this.cells[0].Length;

            this.groundObject = new GameObject("GroundObject");
            this.groundObject.transform.position = Vector3.zero;

            this.gameobjects = new GameObject[X][];
            this.spriteRenderers = new SpriteRenderer[X][];
            for (int i = 0; i < X; i++)
            {
                this.gameobjects[i] = new GameObject[Y];
                this.spriteRenderers[i] = new SpriteRenderer[Y];
                for (int o = 0; o < Y; o++)
                {
                    this.gameobjects[i][o] = new GameObject("Cell-" + i + "-" + o);
                    this.gameobjects[i][o].transform.parent = this.groundObject.transform;
                    this.gameobjects[i][o].transform.position = new Vector3(2.5f + 5 * i, 2.5f + 5 * o, 0);
                    this.gameobjects[i][o].transform.localScale = new Vector3(10, 10, 1);
                    this.spriteRenderers[i][o] = this.gameobjects[i][o].AddComponent<SpriteRenderer>();
                    if (this.cells[i][o].isObstacle())
                    {
                        this.spriteRenderers[i][o].sprite = GUIData.obstacleCellSprite;
                    }
                    else
                    {
                        this.spriteRenderers[i][o].sprite = GUIData.freeCellSprite;
                    }
                }
            }
        }

        public void changeSprites(List<Vector2> position, Sprite sprite)
        {
            foreach(Vector2 pos in position)
            {
                changeSprite(pos, sprite);
            }
        }

        public void changeSprite(Vector2 position, Sprite sprite)
        {
            this.spriteRenderers[(int)position.x][(int) position.y].sprite= sprite;
        }

        public void resetSprite(Vector2 position)
        {
            int i = (int)position.x;
            int o = (int)position.y;
            if (this.cells[i][o].isObstacle())
            {
                this.spriteRenderers[i][o].sprite = GUIData.obstacleCellSprite;
            }
            else
            {
                this.spriteRenderers[i][o].sprite = GUIData.freeCellSprite;
            }
        }

        public void resetSprites()
        {
            for (int i = 0; i < this.cells.Length; i++)
            {
                for (int o = 0; o < this.cells[i].Length; o++)
                {
                    if (this.cells[i][o].isObstacle())
                    {
                        this.spriteRenderers[i][o].sprite = GUIData.obstacleCellSprite;
                    }
                    else
                    {
                        this.spriteRenderers[i][o].sprite = GUIData.freeCellSprite;
                    }
                }
            }
        }

        public GameObject getGroundObject() 
        { 
            return this.groundObject; 
        }
    }
}
