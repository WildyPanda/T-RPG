using TRPG.Global.BuffClasses.Buffs;
using TRPG.Global.DataClasses;
using TRPG.Global.FighterClasses;
using TRPG.Global.SkillClasses.SkillEffects;

namespace TRPG.Global.SkillClasses.Skills
{
    public class ShieldSkill : Skill
    {
        public override int Id { get; } = 2;

        public ShieldSkill() : base()
        {
            this.name = "Shield";
            this.description = "Give a defensive buff to an ally";

            this.cost = 3;
            this.range = 17;
            this.cooldown = 0;
            this.needLOS = false;

            this.addEffect(new SkillBuffEffect(new ShieldBuff(20, 3), AreaType.Single, 0, false, true, true));

            this.sprite = SpritesData.getSkillSprite("Shield");
        }

        public ShieldSkill(ShieldSkill shield) : base(shield) { }


        public override Skill Clone()
        {
            return new ShieldSkill(this);
        }
    }
}
