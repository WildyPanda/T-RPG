using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.DataClasses;
using TRPG.Global.SkillClasses;
using TRPG.Global.SkillClasses.Skills;
using TRPG.Global.SkillClasses.Skills.Fire;
using TRPG.Global.StatsClasses.SpiritsStats;
using Unity.VisualScripting;

namespace TRPG.Global.SpiritClasses.Spirits
{
    public class FoxSpirit : Spirit
    {
        public override int Id { get; } = 1;

        public FoxSpirit()
        {
            this.name = "Fox Spirit";
            this.description = "The spirit of a small fox";

            this.skills = new List<Skill> { new FireBallSkill(), new ShieldSkill()};
            this.stats = new FoxSpiritStats();

            this.sprite = SpritesData.getSpiritSprite("Fox-Spirit");
        }
    }
}
