using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.DataClasses;

namespace TRPG.Global.StatsClasses
{
    public class ArchivedStats
    {
        public int level { get; }
        public int stage { get; }
        public StatsRank health { get; }
        public StatsRank speed { get; }
        public StatsRank globalAttack { get; }
        public StatsRank[] attack { get; }
        public StatsRank globalDefense { get; }
        public StatsRank[] defense { get; }

        public ArchivedStats(LevelStats stats)
        {
            level = stats.level;
            stage = stats.stage;
            health = toRank(stats.health);
            speed = toRank(stats.speed);
            globalAttack = toRank(stats.globalAttack);
            globalDefense = toRank(stats.globalDefense);
            attack = new StatsRank[ElementData.nbElements];
            defense = new StatsRank[ElementData.nbElements];
            for (int i = 0; i < ElementData.nbElements; i++)
            {
                attack[i] = toRank(stats.attack[i]);
                defense[i] = toRank(stats.defense[i]);
            }
        }

        private StatsRank toRank(int stat)
        {
            if (stat <= 10)
                return StatsRank.H;
            if (stat <= 20)
                return StatsRank.G;
            if (stat <= 30)
                return StatsRank.F;
            if (stat <= 40)
                return StatsRank.E;
            if (stat <= 50)
                return StatsRank.D;
            if (stat <= 60)
                return StatsRank.C;
            if (stat <= 70)
                return StatsRank.B;
            if (stat <= 80)
                return StatsRank.A;
            if (stat <= 90)
                return StatsRank.S;
            return StatsRank.SS;

        }

        public int getHealth()
        {
            return (int)(((int)health / 100));
        }

        public int getSpeed()
        {
            return (int)(((int)speed / 100));
        }

        public int getGlobalAttack()
        {
            return (int)(((int)globalAttack / 100));
        }

        public int getGlobalDefense()
        {
            return (int)(((int)globalDefense / 100));
        }

        public int getAttack(int index)
        {
            return (int)(((int)attack[index] / 100));
        }

        public int[] getAttack()
        {
            int[] attack = new int[ElementData.nbElements];
            for (int i = 0; i < attack.Length; i++)
            {
                attack[i] = ((int)this.attack[i] / 100);
            }
            return attack;
        }

        public int getDefense(int index)
        {
            return (int)(((int)defense[index] / 100));
        }

        public int[] getDefense()
        {
            int[] defense = new int[ElementData.nbElements];
            for (int i = 0; i < defense.Length; i++)
            {
                defense[i] = ((int)this.defense[i] / 100);
            }
            return defense;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ArchivedStats)) return false;
            ArchivedStats o = (ArchivedStats)obj;
            bool sameLevel = this.level == o.level;
            bool sameStage = this.stage == o.stage;
            bool sameHealth = this.health == o.health;
            bool sameSpeed = this.speed == o.speed;
            bool sameGlobalAttack = this.globalAttack == o.globalAttack;
            bool sameAttack = this.attack.Equals(o.attack);
            bool sameGlobalDefense = this.defense == o.defense;
            bool sameDefense = this.defense.Equals(o.defense);
            return sameLevel && sameStage && sameHealth && sameSpeed && sameGlobalAttack && sameAttack && sameGlobalDefense && sameDefense;
        }
    }

}
