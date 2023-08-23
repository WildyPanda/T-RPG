using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.FighterClasses;
using Unity.VisualScripting;

namespace TRPG.Global.BuffClasses.Buffs
{
    public class BootsBuff : Buff
    {
        public override int Id { get; } = 3;

        public int speedIncrease { get; protected set; }
        public int duration { get; protected set; }

        public Fighter fighter { get; protected set; }

        public BootsBuff()
        {
            this.name = "Boots buff";
            this.speedIncrease = 0;
            this.duration = 0;
        }

        public BootsBuff(int speedIncrease, int duration)
        {
            this.name = "Boots buff";
            this.speedIncrease = speedIncrease;
            this.duration = duration;
        }

        public override void Instantiate(Fighter fighter)
        {
            fighter.stats.changeGlobalDefense(speedIncrease);
            fighter.events.startTurnEvent.AddListener(this.startTurn);
            this.fighter = fighter;
        }

        public override void endBuff()
        {
            this.fighter.stats.changeGlobalDefense(-speedIncrease);
            this.fighter.loseBuff(this.Id);
        }

        protected void startTurn()
        {
            this.duration--;
            if(this.duration <= 0)
            {
                this.endBuff();
            }
        }
    }
}
