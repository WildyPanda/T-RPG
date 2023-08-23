using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.CreatureClasses;
using TRPG.Global.CreatureClasses.Creatures;
using TRPG.Global.DataClasses;
using TRPG.Global.SpiritClasses;
using TRPG.Global.SpiritClasses.Spirits;
using TRPG.Global.StatsClasses;

namespace TRPG.Global.PlayerClasses
{
    public static class PlayerControllerExamples
    {
        public static PlayerController Example1(int id, string name = "Example1")
        {
            Stats stats = new Stats();
            Player player = new Player(name, id, stats, new FighterSprites(true, "Example1"));
            List<Creature> creatures = new List<Creature> { new Cheetah() };
            List<Spirit> spirits = new List<Spirit> { new WolfSpirit() };
            PlayerController pc = new PlayerController(player, creatures, spirits);
            return pc;
        }

        public static PlayerController Example2(int id, string name = "Example2")
        {
            Stats stats = new Stats();
            Player player = new Player(name, id, stats, new FighterSprites(true, "Example2"));
            List<Creature> creatures = new List<Creature> { new Cheetah(), new Eagle() };
            List<Spirit> spirits = new List<Spirit> { new WolfSpirit(), new RacoonSpirit() };
            PlayerController pc = new PlayerController(player, creatures, spirits);
            return pc;
        }

        public static PlayerController Example3(int id, string name = "Example3")
        {
            Stats stats = new Stats();
            Player player = new Player(name, id, stats, new FighterSprites(true, "Example3"));
            List<Creature> creatures = new List<Creature> { new Eagle(), new Fox() };
            List<Spirit> spirits = new List<Spirit> { new FoxSpirit() };
            PlayerController pc = new PlayerController(player, creatures, spirits);
            return pc;
        }
    }
}
