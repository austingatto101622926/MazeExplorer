using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeExplorer
{
    public static class Display
    {
        public static void ReWriteMaze(Maze maze)
        {
            Console.Clear();
            for (int y = 0; y < maze.Layout.GetLength(1); y++)
            {
                for (int x = 0; x < maze.Layout.GetLength(0); x++)
                {
                    if (maze.explorer.X == x && maze.explorer.Y == y)
                    {
                        Console.Write(maze.explorer.Facing);
                    }
                    else
                    {
                        Console.Write(maze.Layout[x, y].Character);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
