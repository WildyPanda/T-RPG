using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using TRPG.Global.GroundClasses.Util;
using TRPG.Global.FighterClasses;
using TRPG.Global.SkillClasses;
using TRPG.Global.DataClasses;

namespace TRPG.Global.GroundClasses
{
    public class Ground
    {
        // ground[x][y]
        private Cell[][] ground;
        public int xMax { get; private set; }
        public int yMax { get; private set; }

        public Ground(int X, int Y)
        {
            this.ground = new Cell[X][];
            for (int i = 0; i < X; i++)
            {
                this.ground[i] = new Cell[Y];
                for (int o = 0; o < Y; o++)
                {
                    this.ground[i][o] = new Cell(i * Y + o);
                }
            }
            this.xMax = X;
            this.yMax = Y;
        }

        public Ground(int x, int y, List<Vector2> obstacles) : this(x, y)
        {
            addObstacles(obstacles);
        }

        // true if (x,y) is in the ground
        // don't verify cell state
        protected bool validPos(int x, int y)
        {
            if (x >= 0 && x < this.ground.Length && y >= 0 && y < this.ground[0].Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // true if (x,y) is in the ground
        // don't verify cell state
        protected bool validPos(Vector2 position)
        {
            return this.validPos((int) position.x, (int) position.y);
        }

        // true if (x,y) is in the ground and is not occupied
        protected bool freeCell(int x, int y)
        {
            if (!validPos(x, y))
            {
                return false;
            }
            return !ground[x][y].isOccupied();
        }

        // true if position is in the ground and is not occupied
        protected bool freeCell(Vector2 position)
        {
            int x = (int)position.x;
            int y = (int)position.y;
            if (!validPos(x, y))
            {
                return false;
            }
            return !ground[x][y].isOccupied();
        }

        // get the cell at pos (x,y)
        public Cell getCell(int x, int y)
        {
            return this.ground[x][y];
        }

        // get the cell at pos (x,y)
        public Cell getCell(Vector2 position)
        {
            return this.getCell((int) position.x, (int) position.y);
        }

        // Dictionnary of all accessible positions ( starting position included ) and the shortest path
        public Dictionary<Vector2, Path> possibleMovement(Vector2 position, int movementLeft, Dictionary<Vector2, Path> paths = null, Path parent = null, int[] count = null)
        {
            if (paths == null)
            {
                paths = new Dictionary<Vector2, Path>();
                count = new int[1] { 1 };
            }
            else
            {
                count[0] += 1;
            }
            Path path = new Path(position, parent);

            bool previousQuicker = false;
            if (!paths.Keys.Contains(position))
            {
                paths.Add(position, path);
            }
            else
            {
                // if key exist check if the new path is quicker to get to the position
                if (paths[position].isPathQuicker(path))
                {
                    paths[position] = path;
                }
                else
                {
                    previousQuicker = true;
                }
            }

            if (movementLeft > 0 && !previousQuicker)
            {
                if (this.freeCell(position + Vector2.up))
                {
                    this.possibleMovement(position + Vector2.up, movementLeft - 1, paths, path,count);
                }
                if (this.freeCell(position + Vector2.down))
                {
                    this.possibleMovement(position + Vector2.down, movementLeft - 1, paths, path, count);
                }
                if (this.freeCell(position + Vector2.left))
                {
                    this.possibleMovement(position + Vector2.left, movementLeft - 1, paths, path, count);
                }
                if (this.freeCell(position + Vector2.right))
                {
                    this.possibleMovement(position + Vector2.right, movementLeft - 1, paths, path, count);
                }
            }
            return paths;
        }

        protected bool actionPossibleTrue(Cell cell)
        {
            return true;
        }

        public List<Vector2> possibleAction(Vector2 position, int range, Func<Cell, bool> action = null)
        {
            if(action == null)
            {
                action = actionPossibleTrue;
            }
            List<Vector2> possible = new List<Vector2>();
            for(int i = -range; i <= range; i++)
            {
                for(int o = -range; o <= range; o++)
                {
                    Vector2 newPos = new Vector2((float)i, (float)o) + position;
                    if(Math.Abs(i) + Math.Abs(o) <= range && validPos(newPos) && !possible.Contains(newPos))
                    {
                        if (action(getCell(newPos)))
                        {
                            possible.Add(newPos);
                        }
                    }
                }
            }
            return possible;
        }

        protected Vector2 intVector2(Vector2 floatVector2)
        {
            return new Vector2(Mathf.Floor(floatVector2.x), Mathf.Floor(floatVector2.y));
        }

        public int signe(float nb)
        {
            if(nb > 0)
            {
                return 1;
            }
            else if (nb < 0)
            {
                return -1;
            }
            return 0;
        }

        protected float nextInt(Vector2 origin, Vector2 direction)
        {
            // Ox = origin.x, Dx = destination.x, Nx = floor(Ox)+1, Mx = ceil(Ox)-1
            // lambX1, lambX2
            // Ox + lambX1 * Dx = Nx
            // lambX1 = (Nx - Ox) / Dx
            // lambX1 is the factor  of Dx needed to go to the superior integer
            // Ox + lambX2 * Dx = Mx
            // lambX2 = (Mx - Ox) / Dx
            // lambX2 is the factor  of Dx needed to go to the inferior integer
            // lambX = max(lambX1,lambX2) // we want the positive one the other is always negative
            // do the same for lambY
            // lamb = min(lambX,lambY) // we want the smaller on so we don't skip a cell
            // return origin + lamb * direction
            float Ox = origin.x;
            float Dx = direction.x;
            float Nx = Mathf.Floor(Ox) + 1;
            float Mx = Mathf.Ceil(Ox) - 1;
            float lambdaX = Mathf.Max((Nx - Ox) / Dx, (Mx - Ox) / Dx);

            float Oy = origin.y;
            float Dy = direction.y;
            float Ny = Mathf.Floor(Oy) + 1;
            float My = Mathf.Ceil(Oy) - 1;
            float lambdaY = Mathf.Max((Ny - Oy) / Dy, (My - Oy) / Dy);

            float lambda = Mathf.Min(lambdaX, lambdaY);
            return lambda;
        }

        public bool isSeen(Vector2 origin, Vector2 destination)
        {
            if (origin == destination)
            {
                return true;
            }
            bool seen = true;
            origin = intVector2(origin) + new Vector2(.5f, .5f);
            destination = intVector2(destination) + new Vector2(.5f, .5f);
            Vector2 direction = destination - origin;
            bool xNeg = direction.x < 0;
            bool yNeg = direction.y < 0;
            if(Math.Abs(direction.x) != Mathf.Abs(direction.y))
            {
                Vector2 position = origin;
                float lambda = nextInt(position, direction);
                while (lambda < 1 && seen)
                {
                    position = origin + lambda * direction;
                    if (position.x == Mathf.Floor(position.x) && xNeg && position.y == Mathf.Floor(position.y) && yNeg)
                    {
                        if (getCell(intVector2(position) - new Vector2(1,1)).isOccupied())
                        {
                            seen = false;
                        }
                    }
                    else if (position.x == Mathf.Floor(position.x) && xNeg)
                    {
                        if (getCell(intVector2(position) - new Vector2(1, 0)).isOccupied())
                        {
                            seen = false;
                        }
                    }
                    else if (position.y == Mathf.Floor(position.y) && yNeg)
                    {
                        if (getCell(intVector2(position) - new Vector2(0, 1)).isOccupied())
                        {
                            seen = false;
                        }
                    }
                    else
                    {
                        if (getCell(intVector2(position)).isOccupied())
                        {
                            seen = false;
                        }
                    }
                    lambda += nextInt(position, direction);
                }
            }
            else
            {
                for(int i = 1; i <= Mathf.Abs(direction.x) && seen; i++)
                {
                    if (getCell(intVector2(origin + i*new Vector2(signe(direction.x),signe(direction.y)))).isOccupied())
                    {
                        seen = false;
                    }
                }
            }
            return seen;
        }

        public List<Vector2> lineOfSight(Vector2 origin, List<Vector2> positionTested)
        {
            List<Vector2> lines = new List<Vector2>();
            foreach(Vector2 pos in positionTested)
            {
                if (isSeen(origin, pos))
                {
                    lines.Add(pos);
                }
            }
            return lines;
        }

        // get the array of arrays of cells
        public Cell[][] GetCells()
        {
            return this.ground;
        }

        // the cell x,y become an obstacle
        public void addObstacle(int x, int y)
        {
            this.ground[x][y].toObstacle();
        }

        public void addObstacle(Vector2 position)
        {
            this.addObstacle((int) position.x, (int) position.y);
        }

        public void addObstacles(List<Vector2> obstacles)
        {
            foreach(Vector2 position in obstacles)
            {
                addObstacle(position);
            }
        }

        // the cell x,y become a free cell
        public void addFree(int x, int y)
        {
            this.ground[x][y].toFree();
        }

        public void addFree(Vector2 position)
        {
            this.addFree((int) position.x,(int) position.y);
        }

        // 
        public List<Fighter> getTargets(Fighter attacker, AreaType AOEType, int range, Vector2 center, Vector2 direction)
        {
            List<Vector2> cellsInRange = AreaData.getAreaTypeFunc(AOEType)(center, range, direction, 0, this.xMax, 0, this.yMax);
            List<Fighter> targets = new List<Fighter>();
            foreach(Vector2 position in cellsInRange)
            {
                Fighter target = this.getCell(position).fighter;
                if(target != null)
                {
                    targets.Add(target);
                }
            }
            return targets;
        }

        // DEBUG //
        public static void showPaths(Path paths)
        {
            foreach (Vector2 key in paths.getList())
            {
                Debug.Log("////////////");
                Debug.Log(key);
            }
        }

        
    }
}