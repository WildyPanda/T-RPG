using TRPG.Global.BuffClasses.Buffs;
using TRPG.Global.DataClasses;
using TRPG.Global.FighterClasses;
using TRPG.Global.SkillClasses.SkillEffects;

namespace TRPG.Global.SkillClasses.Skills
{
    public class WaterBallSkill : Skill
    {
        public override int Id { get; } = 3;

        public WaterBallSkill() : base()
        {
            this.name = "Water Ball";
            this.description = "A ball of water healing everyone in a small area";

            this.cost = 8;
            this.range = 25;
            this.cooldown = 0;
            this.needLOS = true;

            this.addEffect(new SkillHealEffect(50, ElementData.getElementByName("Water"), AreaType.Square, 1, true, true, true));
            this.addEffect(new SkillBuffEffect(new ArmorBreakDeBuff(15, 2), AreaType.Square, 1, true, true, true));

            this.sprite = SpritesData.getSkillSprite("WaterBall");
        }

        public WaterBallSkill(WaterBallSkill waterBall) : base(waterBall) { }


        public override Skill Clone()
        {
            return new WaterBallSkill(this);
        }
    }
}
