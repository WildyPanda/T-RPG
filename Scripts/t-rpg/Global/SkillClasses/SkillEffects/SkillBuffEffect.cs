using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.BuffClasses;
using TRPG.Global.DataClasses;
using TRPG.Global.FighterClasses;
using TRPG.Global.PlayerClasses.Util;

namespace TRPG.Global.SkillClasses.SkillEffects
{
    public class SkillBuffEffect : SkillEffect
    {
        public Buff buff { get; protected set; }
        public int areaRange { get; protected set; }
        public AreaType areaType { get; protected set; }
        public bool targetEnemy { get; protected set; }
        public bool targetAlly { get; protected set; }
        public bool targetSelf { get; protected set; }

        public SkillBuffEffect(Buff buff, AreaType areaType, int areaRange, bool targetEnemy, bool targetAlly, bool targetSelf)
        {
            this.buff = buff;
            this.areaType = areaType;
            this.areaRange = areaRange;
            this.targetEnemy = targetEnemy;
            this.targetAlly = targetAlly;
            this.targetSelf = targetSelf;
        }

        public SkillBuffEffect(SkillBuffEffect SkillBuffEffect)
        {
            this.buff = SkillBuffEffect.buff;
            this.targetEnemy = SkillBuffEffect.targetEnemy;
            this.targetAlly = SkillBuffEffect.targetAlly;
            this.targetSelf = SkillBuffEffect.targetSelf;
        }

        public void effect(Fighter attacker, Fighter target, bool ally, bool self)
        {
            if (self && targetSelf)
            {
                attacker.giveBuff(target, buff);
            }
            else if ((ally && targetAlly) || (!ally && targetEnemy))
            {
                attacker.giveBuff(target, buff);
            }
        }

        public string toDescriptionLine()
        {
            return "Give the buff : " + this.buff.name;
        }

        public SkillEffect Clone()
        {
            return new SkillBuffEffect(this);
        }
    }
}
