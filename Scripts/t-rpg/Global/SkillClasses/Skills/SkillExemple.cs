using TRPG.Global.BuffClasses.Buffs;
using TRPG.Global.DataClasses;
using TRPG.Global.FighterClasses;
using TRPG.Global.SkillClasses.SkillEffects;

namespace TRPG.Global.SkillClasses.Skills
{
    public class SkillExemple : Skill
    {
        public override int Id { get; } = -1;

        public SkillExemple() : base()
        {
            this.name = "Skill Name";
            this.description = "What the skill do";

            this.cost = 1; // mana cost of the skill
            this.range = 1; // range of the skill
            this.cooldown = 0; // 0 -> no cooldown
            this.useByTurn = 0; // 0 -> no limit
            this.needLOS = false; // need line of sight

            //this.addEffect(Effects);

            //this.sprite = SpritesData.getSkillSprite("Sprite-Name");
        }

        // clone
        public SkillExemple(SkillExemple skill) : base(skill) { }


        public override Skill Clone()
        {
            return new SkillExemple(this);
        }
    }
}
