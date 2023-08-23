using TRPG.Global.DataClasses;
using TRPG.Global.SkillClasses.SkillPotentials;
using TRPG.Global.SkillClasses.SkillPotentials.Creatures;
using TRPG.Global.StatsClasses;

namespace TRPG.Global.CreatureClasses.Creatures
{
    public class Eagle : Creature
    {
        public override int Id { get; } = 1;

        public Eagle()
        {
            this.name = "Eagle";
            this.description = "A small eagle";

            this.level = 1;
            this.stage = 1;
            this.stats = new Stats();
            this.skillPotential = new EagleSkillPotential();

            this.sprites = new FighterSprites(false, "Eagle");
            this.spellSprite = SpritesData.getCreatureFaceSprite("Eagle");
        }
    }
}
