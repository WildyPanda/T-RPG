using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.FighterClasses;
using TRPG.Global.Others;

namespace TRPG.Global.BuffClasses
{
    public abstract class Buff : Identifiable
    {
        public abstract int Id { get; }

        public string name { get; protected set; }

        public virtual void Instantiate(Fighter fighter) { }

        public virtual void endBuff() { }

        public virtual void destroyedBuff() { }

        public virtual void reInstantiate(Fighter fighter) { }
    }
}
