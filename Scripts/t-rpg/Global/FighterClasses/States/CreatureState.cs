using System.Collections.Generic;
using TRPG.Global.CreatureClasses;
using TRPG.Global.DataClasses;
using TRPG.Global.PlayerClasses.Util;
using TRPG.Global.SkillClasses;
using TRPG.Global.StatsClasses;
using UnityEngine;

namespace TRPG.Global.FighterClasses.states
{
    public class CreatureState : Fightable
    {
        public string name { get; protected set; }
        public int Id { get; protected set; }
        public Stats stats { get; protected set; }
        public List<Skill> skills { get; protected set; }
        public FighterSprites sprites { get; protected set; }
        public Sprite spellSprite { get; protected set; }

        public bool isSpawned { get; protected set; }

        public CreatureState(Creature creature)
        {
            this.name = creature.name;
            this.Id = creature.Id;
            this.stats = creature.stats.Clone();
            this.skills = Data.ListDeepCopy(creature.GetSkills());
        }

        public List<Skill> GetSkills()
        {
            return this.skills;
        }

        public void spawn()
        {
            this.isSpawned = true;
        }
    }
}
