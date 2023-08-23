using System.Collections.Generic;
using TRPG.Global.DataClasses;
using TRPG.Global.SkillClasses;
using TRPG.Global.SpiritClasses;
using TRPG.Global.StatsClasses;
using UnityEngine;

namespace TRPG.Global.FighterClasses.states
{
    public class SpiritState
    {
        public string name { get; protected set; }
        public int Id { get; protected set; }
        public SpiritStats stats { get; protected set; }
        public List<Skill> skills { get; protected set; }
        public FighterSprites sprites { get; protected set; }
        public Sprite spellSprite { get; protected set; }

        public SpiritState(Spirit spirit)
        {
            this.name = spirit.name;
            this.Id = spirit.Id;
            this.stats = spirit.stats.Clone();
            this.skills = Data.ListDeepCopy(spirit.skills);
        }
    }
}
