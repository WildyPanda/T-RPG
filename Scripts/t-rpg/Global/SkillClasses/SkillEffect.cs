using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.DataClasses;
using TRPG.Global.FighterClasses;
using TRPG.Global.GroundClasses;
using TRPG.Global.Others;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace TRPG.Global.SkillClasses
{
    public interface SkillEffect : Cloneable<SkillEffect>
    {
        public AreaType areaType { get; }
        public int areaRange { get; }

        public bool targetEnemy { get; }
        public bool targetAlly { get; }
        public bool targetSelf { get; }

        public void effect(Fighter attacker, Fighter target, bool ally, bool self);

        public List<Fighter> getTargets(Ground ground, Fighter attacker, Vector2 AOECenter, Vector2 direction)
        {
            return ground.getTargets(attacker, this.areaType, this.areaRange, AOECenter, direction);
        }

        public string toDescriptionLine();

        public string beforeDescLine()
        {
            string res = "";
            if (targetEnemy)
                res += "<sprite=0> ";
            else
                res += "<sprite=1> ";
            if (targetAlly)
                res += "<sprite=2> ";
            else
                res += "<sprite=3> ";
            if (targetSelf)
                res += "<sprite=4> ";
            else
                res += "<sprite=5> ";
            switch (this.areaType)
            {
                case AreaType.Circle:
                    res += "<sprite=6> ";
                    break;
                case AreaType.Cross:
                    res += "<sprite=7> ";
                    break;
                case AreaType.Line:
                    res += "<sprite=8> ";
                    break;
                case AreaType.CenterLine:
                    res += "<sprite=9> ";
                    break;
                case AreaType.Single:
                    res += "<sprite=10> ";
                    break;
                case AreaType.Square:
                    res += "<sprite=11> ";
                    break;
                case AreaType.Triangle:
                    res += "<sprite=12> ";
                    break;
                case AreaType.CrossDiagonal:
                    res += "<sprite=13> ";
                    break;
            }
            return res;
        }
    }
}
