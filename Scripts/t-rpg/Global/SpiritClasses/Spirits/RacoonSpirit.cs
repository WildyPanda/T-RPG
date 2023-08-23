using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.DataClasses;
using TRPG.Global.SkillClasses;
using TRPG.Global.SkillClasses.Skills;
using TRPG.Global.StatsClasses.SpiritsStats;
using Unity.VisualScripting;

namespace TRPG.Global.SpiritClasses.Spirits
{
    public class RacoonSpirit : Spirit
    {
        public override int Id { get; } = 3;

        public RacoonSpirit()
        {
            this.name = "Racoon Spirit";
            this.description = "The spirit of a small racoon";

            this.skills = new List<Skill> { new ShieldSkill()};
            this.stats = new RacoonSpiritStats();

            this.sprite = SpritesData.getSpiritSprite("Racoon-Spirit");
        }
    }
}
