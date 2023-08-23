using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.BuffClasses.Buffs;
using TRPG.Global.SkillClasses.Skills;

namespace TRPG.Global.SkillClasses.SkillTrees.Creatures
{
    public class CheetahSkillTree : SkillTree
    {
        public override int Id { get; } = 102;
        public override string Name { get; } = "Unique Skill Tree";

        public CheetahSkillTree()
        {
            this.originSkill = new SkillCell(typeof(BootsSkill));
        }

    }
}
