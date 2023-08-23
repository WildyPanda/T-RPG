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
    public class WolfSpirit : Spirit
    {
        public override int Id { get; } = 2;

        public WolfSpirit()
        {
            this.name = "Wolf Spirit";
            this.description = "The spirit of a small wolf";

            this.skills = new List<Skill> { new WaterBallSkill(), new BootsSkill()};
            this.stats = new WolfSpiritStats();

            this.sprite = SpritesData.getSpiritSprite("Wolf-Spirit");
        }
    }
}
