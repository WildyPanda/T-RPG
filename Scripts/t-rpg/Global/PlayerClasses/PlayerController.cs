using System.Collections.Generic;
using TRPG.Global.DataClasses;
using TRPG.Global.CreatureClasses;
using TRPG.Global.SpiritClasses;
using TRPG.Global.FighterClasses.states;
using System.Diagnostics;

namespace TRPG.Global.PlayerClasses
{
    public class PlayerController
    {
        public Player player { get; protected set; }
        public List<Creature> creatures { get; protected set; }
        public int maxCreatures { get; protected set; } = Data.maxCreatures;
        public List<Spirit> spirits { get; protected set; }
        public int maxSpirits { get; protected set; } = Data.maxSpirits;
        
        // create a PlayerController with only a Player
        // create an empty list for creatures and spirits
        public PlayerController(Player player)
        {
            this.player = player;
            this.creatures = new List<Creature>();
            this.spirits = new List<Spirit>();
        }

        // create a PlayerController with only a Player and a list of creatures
        // create an empty list for spirits
        public PlayerController(Player player, List<Creature> creatures) : this(player)
        {
            this.creatures = creatures;
        }

        // create a PlayerController with only a Player and a list of spirits
        // create an empty list for creatures
        public PlayerController(Player player, List<Spirit> spirits) : this(player)
        {
            this.spirits = spirits;
        }

        // create a PlayerController with a Player, a list of creatures and a list of spirits
        public PlayerController(Player player, List<Creature> creatures, List<Spirit> spirits) : this(player)
        {
            this.creatures = creatures;
            this.spirits = spirits; 
        }

        public CreatureState[] getCreatureStates()
        {
            CreatureState[] creatures = new CreatureState[this.creatures.Count];
            for (int i = 0; i < creatures.Length; i++)
            {
                creatures[i] = new CreatureState(this.creatures[i]);
            }
            return creatures;
        }

        public SpiritState[] getSpiritStates()
        {
            SpiritState[] spirits = new SpiritState[this.spirits.Count];
            for (int i = 0; i < spirits.Length; i++)
            {
                spirits[i] = new SpiritState(this.spirits[i]);
            }
            return spirits;
        }

        // add a creature to the list,
        // return true if the creature is successfully added
        // return false if the creature can't be added ( already max number of creatures )
        public bool AddCreature(Creature creature)
        {
            if (this.creatures.Count >= this.maxCreatures)
            {
                return false;
            }
            else
            {
                this.creatures.Add(creature);
                return true;
            }
        }

        // change the max number of creature
        // return false if the number of creatures exceed the new max number of creature | don't change the value in this case
        // return true if the number of creatures exceed the new max number of creature
        public bool changeMaxCreatures(int maxCreatures)
        {
            if (this.creatures.Count > maxCreatures)
            {
                return false;
            }
            this.maxCreatures = maxCreatures;
            return true;
        }

        public int getNbCreatures()
        {
            return this.creatures.Count;
        }

        public Creature getCreature(int index)
        {
            return this.creatures[index];
        }

        public List<Creature> getCreatures()
        {
            return this.creatures;
        }

        public void removeCreature(int index)
        {
            this.creatures.RemoveAt(index);
        }

        public bool creatureIdExist(int index)
        {
            foreach (Creature spirit in this.creatures)
            {
                if(spirit.Id == index)
                    return true;
            }
            return false;
        }

        // add a spirit to the list,
        // return true if the spirit is successfully added
        // return false if the spirit can't be added ( already max number of spirits )
        public bool AddSpirit(Spirit spirit)
        {
            if (this.spirits.Count >= this.maxSpirits)
            {
                return false;
            }
            else
            {
                this.spirits.Add(spirit);
                return true;
            }
        }

        // change the max number of spirit
        // return false if the number of spirits exceed the new max number of spirit
        // return true if the number of spirits exceed the new max number of spirit
        public bool changeMaxSpirits(int maxSpirits)
        {
            if (this.spirits.Count > maxSpirits)
            {
                return false;
            }
            this.maxSpirits = maxSpirits;
            return true;
        }

        public int getNbSpirits()
        {
            return this.spirits.Count;
        }

        public Spirit getSpirit(int index)
        {
            return this.spirits[index];
        }

        public void removeSpirit(int index)
        {
            this.spirits.RemoveAt(index);
        }

        public bool spiritIdExist(int index)
        {
            foreach (Spirit spirit in this.spirits)
            {
                if (spirit.Id == index)
                    return true;
            }
            return false;
        }

        public bool isDead()
        {
            //return this.playerFighter.isDead();
            return false;
        }

        public override bool Equals(object o)
        {
            if (!(o is PlayerController))
            {
                return false;
            }
            PlayerController other = o as PlayerController;
            bool testPlayer = this.player.Equals(other.player);
            bool testCreatures = Data.ListEquals(this.creatures, other.creatures);
            bool testMaxCreatures = this.maxCreatures == other.maxCreatures;
            bool testSpirits = Data.ListEquals(this.spirits, other.spirits); ;
            bool testMaxSpirits = this.maxSpirits == other.maxSpirits;
            return testPlayer && testCreatures && testMaxCreatures && testSpirits && testMaxSpirits;
        }

    }
}