using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.BuffClasses.Buffs;
using TRPG.Global.SkillClasses.Skills;

namespace TRPG.Global.SkillClasses.SkillTrees.Elements
{
    public class WaterSkillTree : SkillTree
    {
        public override int Id { get; } = 3;
        public override string Name { get; } = "Water Skill Tree";

        public WaterSkillTree()
        {
            this.originSkill = new SkillCell(typeof(WaterBallSkill));
        }

    }
}
