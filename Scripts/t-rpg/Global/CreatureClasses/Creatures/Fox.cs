using TRPG.Global.DataClasses;
using TRPG.Global.SkillClasses.SkillPotentials;
using TRPG.Global.SkillClasses.SkillPotentials.Creatures;
using TRPG.Global.StatsClasses;

namespace TRPG.Global.CreatureClasses.Creatures
{
    public class Fox : Creature
    {
        public override int Id { get; } = 2;

        public Fox()
        {
            this.name = "Fox";
            this.description = "A small fox";

            this.level = 1;
            this.stage = 1;
            this.stats = new Stats();
            this.skillPotential = new FoxSkillPotential();

            this.sprites = new FighterSprites(false, "Fox");
            this.spellSprite = SpritesData.getCreatureFaceSprite("Fox");
        }
    }
}
