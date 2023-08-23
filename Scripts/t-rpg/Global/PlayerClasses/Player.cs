using System.Collections.Generic;
using TRPG.Global.DataClasses;
using TRPG.Global.PlayerClasses.Util;
using TRPG.Global.SkillClasses;
using TRPG.Global.SkillClasses.SkillPotentials.Players;
using TRPG.Global.StatsClasses;

namespace TRPG.Global.PlayerClasses
{
    public class Player : Fightable
    {
        public string name { get; protected set; }
        public int Id { get; protected set; }
        public Stats stats { get; protected set; }
        public SkillPotential skillPotential { get; protected set; }
        public FighterSprites sprites { get; protected set; }

        public Player(string name, int Id, Stats stats, FighterSprites sprites)
        {
            this.name = name;
            this.Id = Id;
            this.stats = stats;
            this.sprites = sprites;
            this.skillPotential = new PlayerSkillPotential();
        }

        public void changeName(string newName)
        {
            this.name = newName;
        }

        public List<Skill> GetSkills()
        {
            return this.skillPotential.unlockedSkills();
        }

        public string toString()
        {
            return "Joueur : " + name + ", Id : " + this.Id.ToString();
        }
    }
}