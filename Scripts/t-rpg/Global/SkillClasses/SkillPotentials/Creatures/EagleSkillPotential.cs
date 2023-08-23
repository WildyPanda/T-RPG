using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.SkillClasses.SkillTrees.Creatures;

namespace TRPG.Global.SkillClasses.SkillPotentials.Creatures
{
    public class EagleSkillPotential : SkillPotential
    {
        public override int Id { get; } = 2;

        public EagleSkillPotential() : base()
        {
            this.skillTrees.Add(new EagleSkillTree());
        }
    }
}
