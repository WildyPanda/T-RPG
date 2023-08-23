using System.Collections.Generic;
using UnityEngine;
using TRPG.Fight.gui;
using TRPG.Global.SkillClasses;
using TRPG.Global.SpiritClasses;
using TRPG.Global.FighterClasses;
using TRPG.Global.FighterClasses.states;

namespace TRPG.Fight.GuiClasses
{
    public class GUIController
    {
        private Canvas canvas;
        private LifeBar lifeBar;
        private MovementBar movementBar;
        private ActionBar actionBar;

        private SkillBar skillBar;
        private CreatureBar creatureBar;
        private SpiritBar spiritBar;
        private CharacterOrberBar characterOrderBar;

        private ParameterButton parameterButton;
        private CharacterButton characterButton;

        public GUIController(Canvas canvas)
        {
            this.canvas = canvas;

            lifeBar = new LifeBar(canvas.transform);
            movementBar = new MovementBar(canvas.transform);
            actionBar = new ActionBar(canvas.transform);

            skillBar = new SkillBar(canvas.transform);
            creatureBar = new CreatureBar(canvas.transform);
            spiritBar = new SpiritBar(canvas.transform);
            characterOrderBar = new CharacterOrberBar(canvas.transform);

            parameterButton = new ParameterButton(canvas.transform);
            characterButton = new CharacterButton(canvas.transform);
        }

        public void updateGUI(Fighter fighter)
        {
            updateLife(fighter.stats.getHealth(), fighter.stats.getMaxHealth());
            updateAction(fighter.stats.getAction(), fighter.stats.getMaxAction());
            updateMovement(fighter.stats.getMovement(), fighter.stats.getMaxMovement());
            updateSkills(fighter.skills);
        }

        public void updateLife(int life, int maxLife)
        {
            lifeBar.update(life, maxLife);
        }

        public void updateAction(int action, int maxAction)
        {
            actionBar.update(action, maxAction);
        }

        public void updateMovement(int movement, int maxMovement)
        {
            movementBar.update(movement, maxMovement);
        }

        public void updateSkills(List<Skill> skills)
        {
            skillBar.changeSkills(skills);
        }

        public void changeSkillLine(int i)
        {
            if(i > 0)
            {
                skillBar.increaseSkillLine();
            }
            else if(i < 0){
                skillBar.decreaseSkillLine();
            }
        }

        public int clickSkill(int index)
        {
            return index + this.skillBar.skillLine * 5;
        }

        public void updateCreatures(CreatureState[] creatures)
        {
            creatureBar.changeCreatures(creatures);
        }

        public void updateSpirits(List<Spirit> spirits)
        {
            spiritBar.changeSpirits(spirits);
        }

        public void updateCharacterOrder(Sprite actualFighterSprite, Sprite[] fighterSprite, bool[] isPlayer)
        {
            characterOrderBar.nextTurn(actualFighterSprite, fighterSprite, isPlayer);
        }

        public void greyingCreature(int index)
        {
            creatureBar.greyingCreature(index);
        }

        public void greyingAllCreatures()
        {
            creatureBar.greyingAllCreatures();
        }

        public void unGreyingCreature(int index)
        {
            creatureBar.unGreyingCreature(index);
        }

        public void unGreyingAllCreatures()
        {
            creatureBar.unGreyingAllCreatures();
        }







    }
}