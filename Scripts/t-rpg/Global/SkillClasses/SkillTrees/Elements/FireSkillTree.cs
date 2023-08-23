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
    public class FireSkillTree : SkillTree
    {
        public override int Id { get; } = 2;
        public override string Name { get; } = "Fire Skill Tree";

        public FireSkillTree()
        {
            this.originSkill = new SkillCell(typeof(FireBallSkill));
            this.originSkill.AddNextSkill(typeof(BootsSkill));
            this.originSkill.AddNextSkill(typeof(BootsSkill));
            this.originSkill.AddNextSkill(typeof(BootsSkill));
            this.originSkill.AddNextSkill(typeof(BootsSkill));
            this.originSkill.AddNextSkill(typeof(BootsSkill));
            this.originSkill.AddNextSkill(typeof(BootsSkill));
            this.originSkill.AddNextSkill(typeof(BootsSkill));
            this.originSkill.AddNextSkill(typeof(BootsSkill));
            this.originSkill.AddNextSkill(typeof(BootsSkill));
            this.originSkill.AddNextSkill(typeof(BootsSkill));
            this.originSkill.AddNextSkill(typeof(BootsSkill));
            this.originSkill.AddNextSkill(typeof(BootsSkill));
            this.originSkill.AddNextSkill(typeof(BootsSkill));
            this.originSkill.AddNextSkill(typeof(BootsSkill));
            this.originSkill.AddNextSkill(typeof(BootsSkill));
            this.originSkill.getNextSkill(0).AddNextSkill(typeof(BootsSkill));
            this.originSkill.getNextSkill(0).getNextSkill(0).AddNextSkill(typeof(BootsSkill));
            this.originSkill.getNextSkill(0).getNextSkill(0).getNextSkill(0).AddNextSkill(typeof(BootsSkill));
            this.originSkill.getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).AddNextSkill(typeof(BootsSkill));
            this.originSkill.getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).AddNextSkill(typeof(BootsSkill));
            this.originSkill.getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).AddNextSkill(typeof(BootsSkill));
            this.originSkill.getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).AddNextSkill(typeof(BootsSkill));
            this.originSkill.getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).AddNextSkill(typeof(BootsSkill));
            this.originSkill.getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).getNextSkill(0).AddNextSkill(typeof(BootsSkill));
        }

    }
}
