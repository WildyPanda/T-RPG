using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

namespace TRPG.Global.StatsClasses.SpiritsStats
{
    public class WolfSpiritStats : SpiritStats
    {
        public override int Id { get; } = 2;

        public WolfSpiritStats() : base()
        {
            this.globalAttack = 10;
            this.percentGlobalAttack = 125;
        }

        public WolfSpiritStats(WolfSpiritStats stats) : base(stats) { }

        public override SpiritStats Clone()
        {
            return new WolfSpiritStats(this);
        }
    }
}
