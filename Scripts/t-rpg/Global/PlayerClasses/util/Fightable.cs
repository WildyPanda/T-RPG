using System.Collections.Generic;
using TRPG.Global.DataClasses;
using TRPG.Global.SkillClasses;
using TRPG.Global.StatsClasses;

namespace TRPG.Global.PlayerClasses.Util
{
    // Fightable are character that can become Fighter
    public interface Fightable
    {
        string name { get; }
        int Id { get; }
        Stats stats { get; }
        FighterSprites sprites { get; }

        public List<Skill> GetSkills();
    }
}