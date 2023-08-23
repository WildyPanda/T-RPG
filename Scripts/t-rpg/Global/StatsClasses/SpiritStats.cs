using TRPG.Global.DataClasses;
using TRPG.Global.Others;

namespace TRPG.Global.StatsClasses
{
    public abstract class SpiritStats : Cloneable<SpiritStats>, Identifiable
    {
        public abstract int Id { get; }

        /* for non-percent values :
         *      0 : no changes
         *      X : +X to the stat
         *      -X : -X to the stat to a minimum of 1
         * for percent values :
         *      100 : no changes
         *      X : stat * (X/100) to a minimum of 1
         */
        public int health { get; protected set; }
        public int percentHealth { get; protected set; }
        public int speed { get; protected set; }
        public int percentSpeed { get; protected set; }
        public int globalAttack { get; protected set; }
        public int percentGlobalAttack { get; protected set; }
        public int[] attack { get; protected set; }
        public int[] percentAttack { get; protected set; }
        public int globalDefense { get; protected set; }
        public int percentGlobalDefense { get; protected set; }
        public int[] defense { get; protected set; }
        public int[] percentDefense { get; protected set; }

        public SpiritStats()
        {
            this.health = 0;
            this.speed = 0;
            this.globalAttack = 0;
            this.globalDefense = 0;
            this.attack = new int[ElementData.nbElements];
            this.defense = new int[ElementData.nbElements];
            this.percentHealth = 100;
            this.percentSpeed = 100;
            this.percentGlobalAttack = 100;
            this.percentGlobalDefense = 100;
            this.percentAttack = new int[ElementData.nbElements];
            this.percentDefense = new int[ElementData.nbElements];
            for(int i = 0; i < ElementData.nbElements; i++)
            {
                this.attack[i] = 0;
                this.defense[i] = 0;
                this.percentAttack[i] = 100;
                this.percentDefense[i] = 100;
            }
        }

        public SpiritStats(SpiritStats stats)
        {
            this.health = stats.health;
            this.percentHealth = stats.percentHealth;
            this.speed = stats.speed;
            this.percentSpeed = stats.percentSpeed;
            this.globalAttack = stats.globalAttack;
            this.percentGlobalAttack = stats.percentGlobalAttack;
            this.attack = stats.attack;
            this.percentAttack = stats.percentAttack;
            this.globalDefense = stats.globalDefense;
            this.percentGlobalDefense = stats.percentGlobalDefense;
            this.defense = stats.defense;
            this.percentDefense = stats.percentDefense;
        }

        public abstract SpiritStats Clone();
    }

}
