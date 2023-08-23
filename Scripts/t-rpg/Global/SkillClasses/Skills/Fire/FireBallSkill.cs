using TRPG.Global.DataClasses;
using TRPG.Global.FighterClasses;
using TRPG.Global.SkillClasses.SkillEffects;

namespace TRPG.Global.SkillClasses.Skills.Fire
{
    public class FireBallSkill : Skill
    {
        public override int Id { get; } = 1;

        public FireBallSkill() : base()
        {
            this.name  = "Fire Ball";
            this.description  = "A ball of fire damaging everyone in a large area";

            this.cost = 5;
            this.range = 12;
            this.cooldown = 0;
            this.useByTurn = 0;
            this.needLOS = true;

            this.addEffect(new SkillDamageEffect(80, ElementData.getElementByName("Fire"), AreaType.Circle, 3, true, true, true));

            this.sprite = SpritesData.getSkillSprite("FireBall");
        }

        public FireBallSkill(FireBallSkill fireball) : base(fireball) { }


        public override Skill Clone()
        {
            return new FireBallSkill(this);
        }
    }
}
