using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.BuffClasses;
using TRPG.Global.FighterClasses;

namespace TRPG.Global.BuffClasses.Buffs
{
    public class ArmorBreakDeBuff : Buff
    {
        public override int Id { get; } = 2;

        public int defenseDecrease { get; protected set; }
        public int duration { get; protected set; }

        public Fighter fighter { get; protected set; }

        public ArmorBreakDeBuff()
        {
            this.name = "Armor break debuff";
            this.defenseDecrease = 0;
            this.duration = 0;
        }

        public ArmorBreakDeBuff(int defenseDecrease, int duration)
        {
            this.name = "Armor break debuff";
            this.defenseDecrease = defenseDecrease;
            this.duration = duration;
        }

        public override void Instantiate(Fighter fighter)
        {
            fighter.stats.changeGlobalDefense(-defenseDecrease);
            fighter.events.startTurnEvent.AddListener(this.startTurn);
            this.fighter = fighter;
        }

        public override void endBuff()
        {
            this.fighter.stats.changeGlobalDefense(+defenseDecrease);
            this.fighter.loseBuff(this.Id);
        }

        protected void startTurn()
        {
            this.duration--;
            if (this.duration <= 0)
            {
                this.endBuff();
            }
        }
    }
}