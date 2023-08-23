using TRPG.Global.DataClasses;
using TRPG.Global.SkillClasses.SkillPotentials;
using TRPG.Global.SkillClasses.SkillPotentials.Creatures;
using TRPG.Global.StatsClasses;

namespace TRPG.Global.CreatureClasses.Creatures
{
    public class Cheetah : Creature
    {
        public override int Id { get; } = 3;

        public Cheetah()
        {
            this.name = "Cheetah";
            this.description = "A small cheetah";

            this.level = 1;
            this.stage = 1;
            this.stats = new Stats();
            this.skillPotential = new CheetahSkillPotential();

            this.sprites = new FighterSprites(false, "Cheetah");
            this.spellSprite = SpritesData.getCreatureFaceSprite("Cheetah");
        }
    }
}
