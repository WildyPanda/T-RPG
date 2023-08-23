using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace TRPG.Global.FighterClasses
{
    public class FighterEvents
    {
        public Fighter fighter;
        public UnityEvent startTurnEvent { get; private set; } = new UnityEvent();
        public UnityEvent endTurnEvent { get; private set; } = new UnityEvent();
        public UnityEvent attackEvent { get; private set; } = new UnityEvent();
        public UnityEvent attackedEvent { get; private set; } = new UnityEvent();
        public UnityEvent healEvent { get; private set; } = new UnityEvent();
        public UnityEvent healedEvent { get; private set; } = new UnityEvent();
        public UnityEvent giveBuffEvent { get; private set; } = new UnityEvent();
        public UnityEvent receiveBuffEvent { get; private set; } = new UnityEvent();

        public FighterEvents(Fighter fighter)
        {
            this.fighter = fighter;
        }
    }
}
