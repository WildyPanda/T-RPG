using TRPG.Global.BuffClasses.Buffs;
using TRPG.Global.DataClasses;
using TRPG.Global.FighterClasses;
using TRPG.Global.SkillClasses.SkillEffects;

namespace TRPG.Global.SkillClasses.Skills
{
    public class BootsSkill : Skill
    {
        public override int Id { get; } = 4;

        public BootsSkill() : base()
        {
            this.name = "Boots";
            this.description = "Give a speed buff to an ally";

            this.cost = 5;
            this.range = 12;
            this.cooldown = 1;
            this.needLOS = false;

            this.addEffect(new SkillBuffEffect(new BootsBuff(15, 3), AreaType.Single, 0, false, true, true));

            this.sprite = SpritesData.getSkillSprite("Boots");
        }

        public BootsSkill(BootsSkill boots) : base(boots) { }


        public override Skill Clone()
        {
            return new BootsSkill(this);
        }
    }
}
