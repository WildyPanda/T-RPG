using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.SkillClasses.SkillTrees.Creatures;

namespace TRPG.Global.SkillClasses.SkillPotentials.Creatures
{
    public class CheetahSkillPotential : SkillPotential
    {
        public override int Id { get; } = 3;

        public CheetahSkillPotential() : base()
        {
            this.skillTrees.Add(new CheetahSkillTree());
        }
    }
}
