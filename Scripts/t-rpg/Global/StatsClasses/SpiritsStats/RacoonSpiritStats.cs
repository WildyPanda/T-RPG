using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

namespace TRPG.Global.StatsClasses.SpiritsStats
{
    public class RacoonSpiritStats : SpiritStats
    {
        public override int Id { get; } = 3;

        public RacoonSpiritStats() : base()
        {
        }

        public RacoonSpiritStats(RacoonSpiritStats stats) : base(stats) { }

        public override SpiritStats Clone()
        {
            return new RacoonSpiritStats(this);
        }
    }
}
