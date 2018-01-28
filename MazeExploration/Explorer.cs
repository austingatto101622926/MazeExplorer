using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeExplorer
{
    public class Explorer
    {
        public char[] Characters { get; private set; }
        private int MoveCounter;
        private int MoveCounterMax;

        public char Facing;
        public int X;
        public int Y;

        //CRAP
        private int StepCount = 0;
        private int maxSteps = 0;

        public Explorer()
        {
            Characters = new char[] { '>', '<', '^', 'v' };
            MoveCounter = 0;
            MoveCounterMax = 6;
        }

        public void SetLocation(int x, int y, char facing)
        {
            X = x;
            Y = y;
            Facing = facing;
        }

        public void ResetMoveCounter()
        {
            MoveCounter = 0;
        }

        public bool Step(Maze maze)
        {
            if (maze.IsExit(X, Y))
            {
                return true;
            }

            if (MoveCounter == MoveCounterMax)
            {
                TurnAround();
                MoveCounter = 0;
            }
            else if (CheckAhead(maze))
            {
                StepFoward();
            }
            else
            {
                TurnRight();
                if (CheckAhead(maze))
                {

                }
                else
                {
                    TurnAround();
                    if (CheckAhead(maze))
                    {

                    }
                    else
                    {
                        TurnLeft();
                    }
                }
            }

            return false;
        }
        public bool Solve(Maze maze, bool animate)
        {
            StepCount = 0;
            maxSteps = maze.Layout.Length * 2;

            do
            {
                if (StepCount >= maxSteps) return false;

                if (animate)
                {
                    Display.ReWriteMaze(maze);
                    System.Threading.Thread.Sleep(1000);
                }

            } while (!Step(maze));

            return true;
        }

        private bool CheckAhead(Maze maze)
        {
            int tempx = X;
            int tempy = Y;
            switch (Facing)
            {
                case '>':
                    tempx += 1;
                    break;
                case '<':
                    tempx -= 1;
                    break;
                case '^':
                    tempy -= 1;
                    break;
                case 'v':
                    tempy += 1;
                    break;
            }
            return maze.IsFree(tempx, tempy);
        }

        private void StepFoward()
        {
            switch (Facing)
            {
                case '>':
                    X += 1;
                    break;
                case '<':
                    X -= 1;
                    break;
                case '^':
                    Y -= 1;
                    break;
                case 'v':
                    Y += 1;
                    break;
            }
            MoveCounter += 1;
            StepCount += 1;
        }

        private void TurnLeft()
        {
            switch (Facing)
            {
                case '>':
                    Facing = '^';
                    break;
                case '<':
                    Facing = 'v';
                    break;
                case '^':
                    Facing = '<';
                    break;
                case 'v':
                    Facing = '>';
                    break;
            }
        }

        private void TurnRight()
        {
            switch (Facing)
            {
                case '>':
                    Facing = 'v';
                    break;
                case '<':
                    Facing = '^';
                    break;
                case '^':
                    Facing = '>';
                    break;
                case 'v':
                    Facing = '<';
                    break;
            }
        }

        private void TurnAround()
        {
            TurnRight();
            TurnRight();
        }
    }
}
