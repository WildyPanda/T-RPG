using TRPG.Global.SkillClasses.SkillPotentials.Specials;
using TRPG.Global.SkillClasses.SkillTrees.Elements;

namespace TRPG.Global.SkillClasses.SkillPotentials.Players
{
    public class PlayerSkillPotential : SkillPotential
    {
        public override int Id { get; } = 1000;

        public PlayerSkillPotential() : base()
        {
            this.skillTrees.Add(new FireSkillTree());
            this.skillTrees.Add(new GrassSkillTree());
            this.skillTrees.Add(new NeutralSkillTree());
            this.skillTrees.Add(new WaterSkillTree());
            this.skillTrees.Add(new DragonSkillTree());
        }
    }
}
