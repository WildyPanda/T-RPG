using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.BuffClasses.Buffs;
using TRPG.Global.SkillClasses.Skills;

namespace TRPG.Global.SkillClasses.SkillTrees.Elements
{
    public class GrassSkillTree : SkillTree
    {
        public override int Id { get; } = 4;
        public override string Name { get; } = "Grass Skill Tree";

        public GrassSkillTree()
        {
            this.originSkill = new SkillCell(typeof(ShieldSkill));
        }

    }
}
