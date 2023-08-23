using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

namespace TRPG.Global.StatsClasses.SpiritsStats
{
    public class FoxSpiritStats : SpiritStats
    {
        public override int Id { get; } = 1;

        public FoxSpiritStats() : base()
        {
            this.speed = 10;
            this.percentSpeed = 110;
        }

        public FoxSpiritStats(FoxSpiritStats stats) : base(stats) { }

        public override SpiritStats Clone()
        {
            return new FoxSpiritStats(this);
        }
    }
}
