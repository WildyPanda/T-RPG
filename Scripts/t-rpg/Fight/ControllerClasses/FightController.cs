using System.Collections.Generic;
using UnityEngine;
using TRPG.Fight.GuiClasses;
using TRPG.Global.PlayerClasses;
using TRPG.Global.Others;
using TRPG.Global.GroundClasses;
using TRPG.Global.SkillClasses;
using TRPG.Global.FighterClasses;

namespace TRPG.Fight.ControllerClasses
{
    public enum FightState
    {
        waitForMovement,
        waitForAction,
        waitForCreatureSpawn,
        waitForSpiritPossession,
        waitNothing
    }

    public class FightController
    {
        public List<FighterController> team1;
        public List<FighterController> team2;
        public ListStartEnd<FighterController> speedOrder;
        public Ground ground;
        public GroundVisual groundVisual;
        public GUIController guiController;

        public FightState state;

        
        public FightController(List<PlayerController> team1, List<Vector2> startingPositionsT1, List<PlayerController> team2, List<Vector2> startingPositionsT2, Ground ground, GroundVisual groundVisual, GUIController guiController)
        {// create a fight between players from team 1 and 2 on a ground
            foreach (PlayerController player in team1)
            {
                this.team1.Add(new FighterController(player, FighterTeam.Team1, this, guiController));
            }
            foreach (PlayerController player in team2)
            {
                this.team2.Add(new FighterController(player, FighterTeam.Team2, this, guiController));
            }
            this.ground = ground;
            this.speedOrder = orderTeamBySpeed();
            this.speedOrder.Next();
            this.groundVisual = groundVisual;
            this.guiController = guiController;
            this.state = FightState.waitNothing;
        }

        public void endTurn()
        {
            speedOrder.current.endTurn();
        }
        
        public void startTurn()
        {
            state = FightState.waitNothing;
            speedOrder.current.startTurn();
        }

        public void nextPlayerController()
        {
            speedOrder.Next();
            startTurn();
        }

        public void click(GameObject gameObject, Vector3 position)
        {
            if(gameObject.name == "EmptyUI")
            {
                Debug.Log(position);
            }
            else
            {
                Debug.Log(gameObject.name);
            }
        }























        public void updatePlayerOrder(Sprite[] sprites, bool[] isPlayer, int i)
        {
            ListStartEnd<FighterController> playerOrder = new ListStartEnd<FighterController>(speedOrder);
            while(i < 9)
            {
                i += playerOrder.Next().updatePlayerOrder(sprites, isPlayer, i);
            }
        }

        protected int ComparePlayerControllerBySpeed(FighterController x, FighterController y) // wip
        {// - if player x is quicker + else
            return 0;// y.player.stats.speed - x.player.stats.speed;
        }

        protected ListStartEnd<FighterController> orderTeamBySpeed()
        {// create an array  with all FighterConstructor sorted by Player speed
            ListStartEnd<FighterController> newList = new ListStartEnd<FighterController>();
            newList.AddRange(this.team1);
            newList.AddRange(this.team2);
            newList.SafeSort(ComparePlayerControllerBySpeed);
            return newList;
        }

        protected bool team1Dead()
        {// true if team 1 have only dead player
         // true if team 2 is empty
            List<FighterController>.Enumerator it = this.team1.GetEnumerator();
            while (it.MoveNext())
            {
                if (!it.Current.isDead())
                {
                    return false;
                }
            }
            return true;
        }

        protected bool team2Dead()
        {// true if team 2 have only dead player
         // true if teamn 2 is empty
            List<FighterController>.Enumerator it = this.team2.GetEnumerator();
            while (it.MoveNext())
            {
                if (!it.Current.isDead())
                {
                    return false;
                }
            }
            return true;
        }

        protected bool bothTeamDead()
        {// true if both team have only dead player
            return this.team1Dead() && this.team2Dead();
        }
        
        protected bool isEnded()
        {// true if all the Player ( not creatures ) from a team are dead
            return this.team1Dead() || this.team2Dead();
        }


        public bool moveFighter(Fighter fighter, Vector2 direction)
        {// wip ( work in progress )
         // move a fighter with a Vector2 movement
         // true if the movement could be done
            return true;
        }

        public void attackFighter(Fighter attacking, Fighter defending, Skill skillUsed)
        {// execute attack from attacking with skill skillUsed on defending
            //defending.takeHit(attacking, skillUsed);
        }

    }
}