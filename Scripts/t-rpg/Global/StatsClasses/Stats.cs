using System;
using TRPG.Global.DataClasses;
using Unity.Mathematics;

namespace TRPG.Global.StatsClasses
{
    public class Stats
    {
        public int level { get; protected set; }
        public int stage { get; protected set; }
        public LevelStats levelStats { get; protected set; }
        public ArchivedStats[] archivedStats { get; protected set; }
        protected StatsPotential potential;
        public int movement { get; protected set; }
        public int actionPoint { get; protected set; }

        // create a stats object using all the informations from parameters
        public Stats()
        {
            level = 1;
            stage = 1;
            levelStats = new LevelStats(level);
            archivedStats = new ArchivedStats[StatsData.maxLevel];
            potential = new StatsPotential();
            movement = 0;
            actionPoint = 0;
        }

        // create a copy of a stats object
        public Stats(Stats stats)
        {
            this.level = stats.level;
            this.levelStats = stats.levelStats.Clone();
            this.archivedStats = new ArchivedStats[StatsData.maxLevel];
            for (int i = 0; i < stats.archivedStats.Length; i++)
            {
                archivedStats[i] = stats.archivedStats[i];
            }
            this.potential = stats.potential;
            this.movement = stats.movement;
            this.actionPoint = stats.actionPoint;
        }

        // create a stats object using all the informations from an other Stats object
        // can be used to create a temporary Stats object for a fight
        public Stats(int level, LevelStats actLevel, ArchivedStats[] prevLevels, StatsPotential potential, int movement, int actionPoint)
        {
            this.level = level;
            if (actLevel == null)
            {
                this.levelStats = new LevelStats(level);
            }
            else
            {
                this.levelStats = actLevel;
            }
            archivedStats = new ArchivedStats[StatsData.maxLevel];
            if (prevLevels.Length == level - 1)
            {
                for (int i = 0; i < prevLevels.Length; i++)
                {
                    archivedStats[i] = prevLevels[i];
                }
            }
            else
            {
                throw new Exception("Incorrect number of ArchivedStats in Stats creation");
            }
            this.potential = potential;
            this.movement = movement;
            this.actionPoint = actionPoint;
        }

        public void changeMovement(int newMovement)
        {
            movement = newMovement;
        }

        public void changeActionPoint(int newActionPoint)
        {
            actionPoint = newActionPoint;
        }



        public int getLevel()
        {
            return level;
        }

        public int getStage()
        {
            return stage;
        }

        public int getHealth()
        {
            int health = levelStats.health;
            foreach (ArchivedStats stat in archivedStats)
            {
                if (stat != null)
                    health += stat.getHealth();
            }
            return (int)(health * potential.health);
        }

        public int getSpeed()
        {
            int speed = levelStats.speed;
            foreach (ArchivedStats stat in archivedStats)
            {
                if (stat != null)
                    speed += stat.getSpeed();
            }
            return (int)(speed * potential.speed);
        }

        public int getGlobalAttack()
        {
            int globalAttack = levelStats.globalAttack;
            foreach (ArchivedStats stat in archivedStats)
            {
                if (stat != null)
                    globalAttack += stat.getGlobalAttack();
            }
            return (int)(globalAttack * potential.globalAttack);
        }

        public int getGlobalDefense()
        {
            int globalDefense = levelStats.globalDefense;
            foreach (ArchivedStats stat in archivedStats)
            {
                if (stat != null)
                    globalDefense += stat.getGlobalDefense();
            }
            return (int)(globalDefense * potential.globalDefense);
        }

        public int getAttack(int index)
        {
            int attack = levelStats.attack[index];
            foreach (ArchivedStats stat in archivedStats)
            {
                if(stat != null)
                    attack += stat.getAttack(index);
            }
            return (int)(attack * potential.attack[index]);
        }

        public int getDefense(int index)
        {
            int defense = levelStats.defense[index];
            foreach (ArchivedStats stat in archivedStats)
            {
                if (stat != null)
                    defense += stat.getDefense(index);
            }
            return (int)(defense * potential.defense[index]);
        }

        public int getMovement()
        {
            return this.movement;
        }

        public int getActionPoint()
        {
            return this.actionPoint;
        }

        public int getRemainingStatsPoints()
        {
            return this.levelStats.remainingStatPoints;
        }

        public Stats Clone()
        {
            return new Stats(this);
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Stats)) return false;
            Stats o = (Stats)obj;
            bool sameLevel = this.level == o.level;
            bool sameLevelStats = this.levelStats.Equals(o.levelStats);
            bool sameArchivedStats = Data.ArrayEquals<ArchivedStats>(this.archivedStats, o.archivedStats);
            bool sameMovement = this.movement == o.movement;
            bool sameActionPoint = this.actionPoint == o.actionPoint;
            return sameLevel && sameLevelStats && sameArchivedStats && sameMovement && sameActionPoint;
        }
    }

    
}