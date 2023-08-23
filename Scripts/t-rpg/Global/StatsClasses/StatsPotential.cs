using TRPG.Global.DataClasses;

namespace TRPG.Global.StatsClasses
{
    public class StatsPotential
    {
        // the stats gained by each points on the stat
        // the stats are rounded at the inferior value
        // 3.99 -> 3
        public float level { get; private set; }
        public float stage { get; private set; }
        public float remainingStatPoints { get; private set; }
        public float health { get; private set; }
        public float speed { get; private set; }
        public float globalAttack { get; private set; }
        public float[] attack { get; private set; }
        public float globalDefense { get; private set; }
        public float[] defense { get; private set; }

        public StatsPotential()
        {
            this.level = 1;
            this.stage = 1;
            this.remainingStatPoints = 1;
            this.health = 1;
            this.speed = 1;
            this.globalAttack = 1;
            this.globalDefense = 1;
            this.attack = new float[ElementData.nbElements];
            this.defense = new float[ElementData.nbElements];
            for(int i = 0; i < ElementData.nbElements; i++)
            {
                this.attack[i] = 1;
                this.defense[i] = 1;
            }
        }

        public StatsPotential(float level, float stage, float remainingStatPoints, float health, float speed, float globalAttack, float[] attack, float globalDefense, float[] defense)
        {
            this.level = level;
            this.stage = stage;
            this.remainingStatPoints = remainingStatPoints;
            this.health = health;
            this.speed = speed;
            this.globalAttack = globalAttack;
            this.attack = attack;
            this.globalDefense = globalDefense;
            this.defense = defense;
        }
    }
}
