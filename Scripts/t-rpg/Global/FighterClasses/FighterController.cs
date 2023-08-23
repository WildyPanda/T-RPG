using System.Transactions;
using TRPG.Global.DataClasses;
using TRPG.Global.DataClasses.GuiClasses;
using TRPG.Global.PlayerClasses;
using TRPG.Fight.ControllerClasses;
using TRPG.Fight.GuiClasses;
using UnityEngine;
using TRPG.Global.FighterClasses.states;

namespace TRPG.Global.FighterClasses
{
    public class FighterController
    {
        public Fighter playerFighter { get; private set; }
        public Fighter[] creatureFighters { get; private set; }
        public int[] spawnedCreature { get; private set; }
        private int curCreatureFighters;
        public CreatureState[] creatureStates { get; private set; }
        public SpiritState[] spiritStates { get; private set; }

        private const int maxSpawnedCreature = 2;

        public FightController fightController { get; private set; }
        public GUIController guiController { get; private set; }


        public FighterController(PlayerController controller, FighterTeam team, FightController fightController, GUIController guiController)
        {
            playerFighter = new Fighter(controller.player, this, team);
            creatureStates = controller.getCreatureStates();
            spiritStates = controller.getSpiritStates();
            creatureFighters = new Fighter[maxSpawnedCreature];
            spawnedCreature = new int[creatureStates.Length];
            curCreatureFighters = 0;
            this.fightController = fightController;
            this.guiController = guiController;

        }


        public void startTurn()
        {
            guiController.updateGUI(playerFighter);
            guiController.updateCreatures(this.creatureStates);
            playerFighter.startTurn();
        }

        public void nextFighter()
        {
            if(curCreatureFighters > creatureFighters.Length || creatureFighters[curCreatureFighters] == null)
            {
                endTurn();
            }
            else
            {
                creatureFighters[curCreatureFighters].startTurn();
                curCreatureFighters++;
            }
        }

        public void endTurn()
        {
            curCreatureFighters = 0;
            fightController.nextPlayerController();
        }

        public void updateGreyingCreature(GUIController guiController)
        {
            if (this.creatureFighters[0] != null && this.creatureFighters[1] != null)
            {
                guiController.greyingAllCreatures();
            }
            else
            {
                guiController.unGreyingAllCreatures();
                for (int i = 0; i < this.spawnedCreature.Length; i++)
                {
                    guiController.greyingCreature(this.spawnedCreature[i]);
                }
            }
        }

        public void updatePlayerOrder()
        {
            Sprite[] sprites = new Sprite[GUIData.maxShownPlayerOrder];
            bool[] isPlayer = new bool[GUIData.maxShownPlayerOrder];
            int i = 1;
            sprites[0] = playerFighter.sprites.faceSprite;
            isPlayer[0] = true;
            for (; i < creatureFighters.Length && creatureFighters[i-1] != null; i++)
            {
                sprites[i] = creatureFighters[i-1].sprites.faceSprite;
                isPlayer[i] = false;
            }
            this.fightController.updatePlayerOrder(sprites, isPlayer, i);

        }

        public int updatePlayerOrder(Sprite[] sprites, bool[] isPlayer, int i)
        {
            sprites = new Sprite[GUIData.maxShownPlayerOrder];
            isPlayer = new bool[GUIData.maxShownPlayerOrder];
            sprites[i] = playerFighter.sprites.faceSprite;
            isPlayer[i] = true;
            i++;
            int o = 0;
            for (; o < creatureFighters.Length && creatureFighters[o - 1] != null; i++, o++)
            {
                sprites[i] = creatureFighters[o].sprites.faceSprite;
                isPlayer[i] = false;
            }
            return o;
        }

        public bool isDead()
        {
            return playerFighter.isDead();
        }

        public void summonCreature(int index)
        {
            for(int i = 0; i < creatureFighters.Length; i++)
            {
                if (creatureFighters[i] == null)
                {
                    creatureFighters[i] = new Fighter(creatureStates[index], this, this.playerFighter.team);
                    return;
                }
            }
        }
    }
}
