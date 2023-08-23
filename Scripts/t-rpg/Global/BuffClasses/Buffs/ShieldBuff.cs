using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.FighterClasses;
using Unity.VisualScripting;

namespace TRPG.Global.BuffClasses.Buffs
{
    public class ShieldBuff : Buff
    {
        public override int Id { get; } = 1;

        public int defenseIncrease { get; protected set; }
        public int duration { get; protected set; }

        public Fighter fighter { get; protected set; }

        public ShieldBuff()
        {
            this.name = "Shield buff";
            this.defenseIncrease = 0;
            this.duration = 0;
        }

        public ShieldBuff(int defenseIncrease, int duration)
        {
            this.name = "Shield buff";
            this.defenseIncrease = defenseIncrease;
            this.duration = duration;
        }

        public override void Instantiate(Fighter fighter)
        {
            fighter.stats.changeGlobalDefense(defenseIncrease);
            fighter.events.startTurnEvent.AddListener(this.startTurn);
            this.fighter = fighter;
        }

        public override void endBuff()
        {
            this.fighter.stats.changeGlobalDefense(-defenseIncrease);
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
