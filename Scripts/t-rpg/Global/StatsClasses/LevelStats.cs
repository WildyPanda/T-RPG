using System;
using System.Linq;
using TRPG.Global.DataClasses;

namespace TRPG.Global.StatsClasses
{
    public class LevelStats
    {
        public int level { get; private set; }
        public int stage { get; private set; }
        public int remainingStatPoints { get; private set; }
        public int health { get; private set; }
        public int speed { get; private set; }
        public int globalAttack { get; private set; }
        public int[] attack { get; private set; }
        public int globalDefense { get; private set; }
        public int[] defense { get; private set; }

        public LevelStats(int level = 1)
        {
            if (level < 1 || level > StatsData.maxLevel)
            {
                throw new Exception("Incorrect level in LevelStats creation");
            }
            this.level = level;
            this.stage = 1;
            this.remainingStatPoints = 0;
            this.health = 0;
            this.speed = 0;
            this.globalAttack = 0;
            this.globalDefense = 0;
            this.attack = new int[ElementData.nbElements];
            this.defense = new int[ElementData.nbElements];
            for (int i = 0; i < ElementData.nbElements; i++)
            {
                this.attack[i] = 0;
                this.defense[i] = 0;
            }
        }

        public LevelStats(LevelStats stats)
        {
            this.level = stats.level;
            this.stage = stats.stage;
            this.remainingStatPoints = stats.remainingStatPoints;
            this.health = stats.health;
            this.speed = stats.speed;
            this.globalAttack = stats.globalAttack;
            this.attack = Data.ArrayCopy(stats.attack);
            this.globalDefense = stats.globalDefense;
            this.attack = Data.ArrayCopy(stats.attack);
        }

        public LevelStats(int level, int stage, int remainingStatPoints, int health, int speed, int globalAttack, int[] attack, int globalDefense, int[] defense)
        {
            this.level = level;
            this.stage = stage;
            this.remainingStatPoints = remainingStatPoints;
            this.health = health;
            this.speed = speed;
            this.globalAttack = globalAttack;
            this.globalDefense = globalDefense;
            this.attack = Data.ArrayCopy(attack);
            this.defense = Data.ArrayCopy(defense);
            checkCreation();
        }

        private void checkCreation()
        {
            if (level < 1 || level > StatsData.maxLevel)
                throw new Exception("Incorrect level in LevelStats creation");
            if (stage < 0)
                throw new Exception("Invalid stage number in LevelStats creation");
            if (remainingStatPoints < 0)
                throw new Exception("Invalid remainingStatPoints in LevelStats creation");
            if (attack.Length > ElementData.nbElements)
                throw new Exception("Too many attack stats in LevelStats creation");
            if (defense.Length > ElementData.nbElements)
                throw new Exception("Too many defense stats in LevelStats creation");
            if (health < 0 || health > 100)
                throw new Exception("Incorrect health stat in LevelStats creation");
            if (speed < 0 || speed > 100)
                throw new Exception("Incorrect speed stat in LevelStats creation");
            if (globalAttack < 0 || globalAttack > 100)
                throw new Exception("Incorrect globalAttack stat in LevelStats creation");
            if (globalDefense < 0 || globalDefense > 100)
                throw new Exception("Incorrect globalDefense stat in LevelStats creation");
            foreach (int i in attack)
                if (i < 0 || i > 100)
                    throw new Exception("Incorrect attack stat in LevelStats creation");
            foreach (int i in defense)
                if (i < 0 || i > 100)
                    throw new Exception("Incorrect defense stat in LevelStats creation");
            if (checkStatsPoints())
                throw new Exception("Invalid total of stats point in LevelStats creation");
        }

        protected bool checkStatsPoints()
        {
            int normalPoints = stage * StatsData.statPointsByStage;
            int points = remainingStatPoints;
            points += health + speed + globalAttack + globalDefense + attack.Sum() + defense.Sum();
            return normalPoints == points;
        }

        public void changeHealth(int amount)
        {
            this.health += amount;
            if (health > 100)
                health = 100;
            if (health < 0)
                health = 0;
        }

        public void changeSpeed(int amount)
        {
            this.speed += amount;
            if (speed > 100)
                speed = 100;
            if (speed < 0)
                speed = 0;
        }

        public void changeGlobalAttack(int amount)
        {
            this.globalAttack += amount;
            if (this.globalAttack > 100)
                globalAttack = 100;
            if (globalAttack < 0)
                globalAttack = 0;
        }

        public void changeGlobalDefense(int amount)
        {
            this.globalDefense += amount;
            if (this.globalDefense > 100)
                globalDefense = 100;
            if (globalDefense < 0)
                globalDefense = 0;
        }

        public void changeAttack(int amount, int elementIndex)
        {
            this.attack[elementIndex] += amount;
            if (this.attack[elementIndex] > 100)
                this.attack[elementIndex] = 100;
            if (this.attack[elementIndex] < 0)
                this.attack[elementIndex] = 0;
        }

        public void changeDefense(int amount, int elementIndex)
        {
            this.defense[elementIndex] += amount;
            if (this.defense[elementIndex] > 100)
                this.defense[elementIndex] = 100;
            if (this.defense[elementIndex] < 0)
                this.defense[elementIndex] = 0;
        }

        public LevelStats Clone()
        {
            return new LevelStats(this);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is LevelStats)) return false;
            LevelStats o = (LevelStats)obj;
            bool samelevel = this.level == o.level;
            bool sameStage = this.stage == o.stage;
            bool sameRemainingPoints = this.remainingStatPoints == o.remainingStatPoints;
            bool sameHealth = this.health == o.health;
            bool sameSpeed = this.speed == o.speed;
            bool sameGlobalAttack = this.globalAttack == o.globalAttack;
            bool sameAttack = Data.ArrayEquals<int>(this.attack, o.attack);
            bool sameGlobalDefense = this.globalDefense == o.globalDefense;
            bool sameDefense = Data.ArrayEquals<int>(this.defense, o.defense);
            return samelevel && sameStage && sameRemainingPoints && sameHealth && sameSpeed && sameGlobalAttack && sameAttack && sameGlobalDefense && sameDefense;
        }
    }

}
