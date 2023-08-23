using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.BuffClasses.Buffs;
using TRPG.Global.SkillClasses.Skills;
using TRPG.Global.SkillClasses.Skills.Fire;

namespace TRPG.Global.SkillClasses.SkillTrees.Creatures
{
    public class EagleSkillTree : SkillTree
    {
        public override int Id { get; } = 100;
        public override string Name { get; } = "Unique Skill Tree";

        public EagleSkillTree()
        {
            this.originSkill = new SkillCell(typeof(FireBallSkill));
        }

    }
}
