using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.DataClasses;
using TRPG.Global.FighterClasses;
using TRPG.Global.PlayerClasses.Util;

namespace TRPG.Global.SkillClasses.SkillEffects
{
    public class SkillDamageEffect : SkillEffect
    {
        public int power { get; protected set; }
        public Element element { get; protected set; }
        public AreaType areaType { get; protected set; }
        public int areaRange { get; protected set; }
        public bool targetEnemy { get; protected set; }
        public bool targetAlly { get; protected set; }
        public bool targetSelf { get; protected set; }

        public SkillDamageEffect(int power, Element element, AreaType areaType, int areaRange, bool targetEnemy, bool targetAlly, bool targetSelf)
        {
            this.power = power;
            this.element = element;
            this.areaType = areaType;
            this.areaRange = areaRange;
            this.targetEnemy = targetEnemy;
            this.targetAlly = targetAlly;
            this.targetSelf = targetSelf;
        }

        public SkillDamageEffect(SkillDamageEffect skillDamageEffect)
        {
            this.power = skillDamageEffect.power;
            this.element = skillDamageEffect.element;
            this.targetEnemy = skillDamageEffect.targetEnemy;
            this.targetAlly = skillDamageEffect.targetAlly;
            this.targetSelf = skillDamageEffect.targetSelf;
        }

        public void effect(Fighter attacker, Fighter target, bool ally, bool self)
        {
            if(self && targetSelf)
            {
                attacker.Attack(target, this.power, this.element);
            }
            else if((ally && targetAlly) || (!ally && targetEnemy))
            {
                attacker.Attack(target, this.power, this.element);
            }
        }

        public string toDescriptionLine()
        {
            return this.power.ToString() + " " + this.element.name + " damage";
        }

        public SkillEffect Clone()
        {
            return new SkillDamageEffect(this);
        }
    }
}
