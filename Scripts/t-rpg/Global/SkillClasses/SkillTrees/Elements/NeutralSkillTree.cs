using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.BuffClasses.Buffs;
using TRPG.Global.SkillClasses.Skills;
using TRPG.Global.SkillClasses.Skills.Fire;

namespace TRPG.Global.SkillClasses.SkillTrees.Elements
{
    public class NeutralSkillTree : SkillTree
    {
        public override int Id { get; } = 1;
        public override string Name { get; } = "Neutral Skill Tree";

        public NeutralSkillTree()
        {
            this.originSkill = new SkillCell(typeof(ShieldSkill));
            this.originSkill.AddNextSkill(typeof(BootsSkill));
            this.originSkill.AddNextSkill(typeof(FireBallSkill));
            this.originSkill.getNextSkill(0).AddNextSkill(typeof(WaterBallSkill));
            this.originSkill.getNextSkill(1).AddNextSkill(typeof(ShieldSkill));
            this.originSkill.getNextSkill(0).AddNextSkill(typeof(FireBallSkill));
        }

    }
}
