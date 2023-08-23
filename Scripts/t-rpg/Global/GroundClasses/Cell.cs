using TRPG.Global.FighterClasses;
using TRPG.Global.PlayerClasses;

namespace TRPG.Global.GroundClasses
{
    public class Cell
    {
        public Fighter fighter { get; private set; }
        public int id { get; private set; }
        private bool obstacle = false;

        public Cell(int id)
        {
            this.id = id;
        }

        public void toObstacle()
        {
            obstacle = true;
        }

        public void toFree()
        {
            obstacle = false;
        }

        public bool isObstacle()
        {
            return this.obstacle;
        }

        public void clearFighter()
        {
            this.fighter = null;
        }

        public bool isOccupied()
        {
            return this.obstacle || this.fighter != null;
        }

        public void addPlayer(Fighter fighter)
        {
            this.fighter = fighter;
        }
    }
}