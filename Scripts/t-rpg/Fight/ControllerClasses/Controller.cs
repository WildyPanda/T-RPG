using System.Collections.Generic;
using TRPG.Fight.GuiClasses;
using TRPG.Global.DataClasses;
using TRPG.Global.DataClasses.GuiClasses;
using TRPG.Global.GroundClasses;
using TRPG.Global.PlayerClasses;
using Unity.VisualScripting;
using UnityEngine;

namespace TRPG.Fight.ControllerClasses
{
    public class Controller : MonoBehaviour
    {
        Canvas canvas;
        GUIController guiController;
        Ground ground;
        GroundVisual groundVisual;
        ClickController clickController;

        // Start is called before the first frame update
        void Start()
        {
            canvas = GetComponentInChildren<Canvas>();
            ground = createGround();
            groundVisual = new GroundVisual(ground);
            guiController = new GUIController(canvas);
            clickController = this.AddComponent<ClickController>();

            List<PlayerController> team1 = new List<PlayerController> { PlayerControllerExamples.Example1(0), PlayerControllerExamples.Example2(1) };
            List<Vector2> posT1 = new List<Vector2> { new Vector2(2, 1), new Vector2(1, 2) };
            List<PlayerController> team2 = new List<PlayerController> { PlayerControllerExamples.Example3(0), PlayerControllerExamples.Example2(1) };
            List<Vector2> posT2 = new List<Vector2> { new Vector2(47, 48), new Vector2(47, 48) };


            FightController fc = new FightController(team1, posT1, team2, posT2, ground, groundVisual, guiController);
            //fc.startTurn();
        }


        // Update is called once per frame
        void Update()
        {
        }

        private Ground createGround()
        {
            List<Vector2> vector2s = new List<Vector2>();
            for (int i = 0; i < 50; i++)
            {
                for (int o = 0; o < 50; o++)
                {
                    if (i == 0 || i == 49 || o == 0 || o == 49)
                    {
                        vector2s.Add(new Vector2(i, o));
                    }
                    else if ((i, o) != (1, 1) && (i, o) != (48, 48) && i != 1 && i != 48 && o != 1 && o != 48)
                    {
                        if (Random.Range(0f, 1f) < .15f)
                        {
                            vector2s.Add(new Vector2(i, o));
                        }
                    }
                }
            }

            return new Ground(50, 50, vector2s);
        }

        private Ground createGround(List<Vector2> playerPos)
        {
            List<Vector2> vector2s = new List<Vector2>();
            for (int i = 0; i < 50; i++)
            {
                for (int o = 0; o < 50; o++)
                {
                    if (i == 0 || i == 49 || o == 0 || o == 49)
                    {
                        vector2s.Add(new Vector2(i, o));
                    }
                    else if (!playerPos.Contains(new Vector2(i, o)) && i != 1 && i != 48 && o != 1 && o != 48)
                    {
                        if (Random.Range(0f, 1f) < .15f)
                        {
                            vector2s.Add(new Vector2(i, o));
                        }
                    }
                }
            }

            return new Ground(50, 50, vector2s);
        }
    }

}
