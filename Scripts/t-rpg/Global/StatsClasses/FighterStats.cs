using System;
using System.Linq;
using System.Reflection;
using TRPG.Global.DataClasses;
using TRPG.Global.StatsClasses;
using UnityEngine;

namespace TRPG.Global.StatsClasses
{
    public class FighterStats
    {
        // if need to do a maximum in stats don't block the attributs value directly, only the outputted value for buff stats cahnge don't reduce or increase too much
        // ex maxHealthMultiplier > 10  : maxHealthMultiplier = 3 | getMaxHealthMultiplier => 10

        private int maxHealth;
        private int health;
        private int maxHealthModifier;
        // >= 0.25f
        private float maxHealthMultiplier;

        private int maxMovement;
        private int movement;
        private int maxMovementModifier;
        private float maxMovementMultiplier;

        private int maxAction;
        private int action;
        private int maxActionModifier;
        private float maxActionMultiplier;

        private int speed;
        private int speedModifier;
        private float speedMultiplier;

        private int globalAttack;
        private int globalAttackModifier;
        private float globalAttackMultiplier;

        private int[] attack;
        private int[] attackModifiers;
        private float[] attackMultipliers;

        private int globalDefense;
        private int globalDefenseModifier;
        private float globalDefenseMultiplier;

        private int[] defense;
        private int[] defenseModifiers;
        private float[] defenseMultipliers;

        public FighterStats(Stats stats) 
        {
            maxHealth = stats.getHealth();
            health = maxHealth;
            maxHealthModifier = 0;
            maxHealthMultiplier = 1;

            maxMovement = stats.getMovement();
            movement = maxMovement;
            maxMovementModifier = 0;
            maxMovementMultiplier = 1;

            maxAction = stats.getActionPoint();
            action = maxAction;
            maxActionModifier = 0;
            maxActionMultiplier = 1;

            globalAttack = stats.getGlobalAttack();
            globalAttackModifier = 0;
            globalAttackMultiplier = 1;

            attack = new int[ElementData.nbElements];
            attackModifiers = new int[ElementData.nbElements];
            attackMultipliers= Enumerable.Repeat<float>(1,ElementData.nbElements).ToArray();

            globalDefense = stats.getGlobalDefense();
            globalDefenseModifier = 0;
            globalDefenseMultiplier = 1;

            defense = new int[ElementData.nbElements];
            defenseModifiers = new int[ElementData.nbElements];
            defenseMultipliers = Enumerable.Repeat<float>(1, ElementData.nbElements).ToArray();

            for(int i = 0; i < ElementData.nbElements; i++)
            {
                attack[i] = stats.getAttack(i);
                defense[i] = stats.getDefense(i);
            }
        }

        public int getMaxHealth()
        {
            int res = (int)Mathf.Max(1, maxHealth + maxHealthModifier);
            res = (int)Mathf.Max(1, res * Mathf.Max(.25f, maxHealthModifier));
            return res;
        }
        
        public int getHealth()
        {
            return this.health;
        }

        public void changeMaxHealth(int maxHealthModifier = 0, float maxHealthMultiplier = 1)
        {
            this.maxHealthModifier += maxHealthModifier;
            this.maxHealthMultiplier *= maxHealthMultiplier;
            if( this.health > this.getMaxHealth())
            {
                this.health = this.getMaxHealth();
            }
        }

        public void loseHealth(int amount)
        {
            this.health -= amount;
        }

        public void gainHealth(int amount)
        {
            this.health -= amount;
        }


        public int getMaxMovement()
        {
            return (int)(Mathf.Max(0, (this.maxMovement +  this.maxMovementModifier) * this.maxMovementMultiplier));
        }

        public int getMovement()
        {
            return this.movement;
        }

        public void changeMaxMovement(int maxMovementModifier = 0, float maxMovementMultiplier = 1)
        {
            this.maxMovement += maxMovementModifier;
            this.maxMovementMultiplier *= maxMovementMultiplier;
            if(this.movement > this.getMaxMovement())
            {
                this.movement = this.getMaxMovement();
            }
        }

        public void loseMovement(int amount)
        {
            this.movement -= amount;
        }

        public void gainMovement(int amount)
        {
            this.movement += amount;
        }


        public int getMaxAction()
        {
            return (int)(Mathf.Max(0, (this.maxAction + this.maxActionModifier) * this.maxActionMultiplier));
        }

        public int getAction()
        {
            return this.action;
        }

        public void changeMaxAction(int maxActionModifier = 0, float maxActionMultiplier = 1)
        {
            this.maxAction += maxActionModifier;
            this.maxActionMultiplier *= maxActionMultiplier;
            if (this.action > this.getMaxAction())
            {
                this.action = this.getMaxAction();
            }
        }

        public void loseAction(int amount)
        {
            this.action -= amount;
        }

        public void gainAction(int amount)
        {
            this.action += amount;
        }


        public int getSpeed()
        {
            return (int)(Mathf.Max(1, (this.speed + this.speedModifier) * this.speedMultiplier));
        }

        public void changeSpeed(int speedModifier = 0, float speedMultiplier = 1)
        {
            this.speedModifier += speedModifier;
            this.speedMultiplier *= speedMultiplier;
        }


        public int getGlobalAttack()
        {
            return (int)Mathf.Max(1, (this.globalAttack + this.globalAttackModifier) * this.globalAttackMultiplier);
        }

        public void changeGlobalAttack(int globalAttackModifier = 0, float globalAttackMultiplier = 1)
        {
            this.globalAttackModifier += globalAttackModifier;
            this.globalAttackMultiplier *= globalAttackMultiplier;
        }


        public int getAttack(int index)
        {
            return (int)Mathf.Max(1, (this.attack[index] + this.attackModifiers[index]) * this.attackMultipliers[index]);
        }

        public void changeAttack(int index, int attackModifier = 0, float attackMultiplier = 1)
        {
            this.attackModifiers[index] += attackModifier;
            this.attackMultipliers[index] *= attackMultiplier;
        }


        public int getGlobalDefense()
        {
            return (int)Mathf.Max(1, (this.globalDefense + this.globalDefenseModifier) * this.globalDefenseMultiplier);
        }

        public void changeGlobalDefense(int globalDefenseModifier = 0, float globalDefenseMultiplier = 1)
        {
            this.globalDefenseModifier += globalDefenseModifier;
            this.globalDefenseMultiplier *= globalDefenseMultiplier;
        }


        public int getDefense(int index)
        {
            return (int)(Mathf.Max(1, (this.defense[index] + this.defenseModifiers[index]) * this.defenseMultipliers[index]));
        }

        public void changeDefense(int index, int defenseModifier = 0, float defenseMultiplier = 1)
        {
            this.defenseModifiers[index] += defenseModifier;
            this.defenseMultipliers[index] *= defenseMultiplier;
        }

    }
}
