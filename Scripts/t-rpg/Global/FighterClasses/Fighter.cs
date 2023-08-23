using System.Collections.Generic;
using UnityEngine;
using TRPG.Global.PlayerClasses;
using TRPG.Global.PlayerClasses.Util;
using TRPG.Fight.GuiClasses;
using TRPG.Fight.ControllerClasses;
using UnityEngine.Events;
using TRPG.Global.DataClasses;
using TRPG.Global.SkillClasses;
using TRPG.Global.StatsClasses;
using TRPG.Global.BuffClasses;
using System;

namespace TRPG.Global.FighterClasses
{
    public class Fighter
    {
        public string Name { get; protected set; }
        public int Id { get; protected set; }

        public FighterTeam team { get; protected set; }
        public FighterStats stats { get; protected set; }
        public List<Skill> skills { get; protected set; }
        public Fightable character { get; protected set; }
        public Vector2 position { get; protected set; }
        public FighterController controller { get; protected set; }
        public FighterEvents events { get; protected set; }
        public Dictionary<int, Buff> buffs { get; protected set; }

        public FighterSprites sprites { get; protected set; }


        public Fighter(Fightable character, FighterController controller, FighterTeam team)
        {
            this.Name = character.name;
            this.Id = character.Id;

            this.team = team;
            this.stats = new FighterStats(character.stats);
            this.skills = character.GetSkills();
            this.character = character;
            this.position = new Vector2(0, 0);
            this.controller = controller;

            this.sprites = character.sprites;

            this.events = new FighterEvents(this);
        }

        public void startTurn()
        {
            this.events.startTurnEvent.Invoke();
        }

        public void endTurn()
        {
            this.events.endTurnEvent.Invoke();
            this.controller.nextFighter();
        }

        public bool isDead()
        {
            return this.stats.getHealth() > 0;
        }

        public void Heal(Fighter target, int power, Element element)
        {
            this.events.healEvent.Invoke();
            // target.Healed(power * stats.getAttack(element.id));
            // WIP
        }

        protected void Healed(int amount)
        {
            this.events.healedEvent.Invoke();
            // increase actual life by amount to a maximum of maxLife
            // WIP
        }

        public void Attack(Fighter target, int power, Element element)
        {
            this.events.attackEvent.Invoke();
            // target.Attacked(power, stats.getAttack(element.id), element)
        }

        protected void Attacked(int power, int attack, Element element)
        {
            this.events.attackedEvent.Invoke();
            // reduce the actual life by amount reduced by defense
            // amount reduced = power
        }

        public void giveBuff(Fighter target, Buff buff)
        {
            this.events.giveBuffEvent.Invoke();
            target.receiveBuff(buff);
        }

        protected void receiveBuff(Buff buff)
        {
            this.events.receiveBuffEvent.Invoke();
            buff.Instantiate(this);
        }

        public void loseBuff(int index)
        {
            this.buffs.Remove(index);
        }
    }
}