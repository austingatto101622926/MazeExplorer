using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeExplorer;

namespace MazeExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            Maze maze1 = new Maze("#######_#>   E#_#######");

            Maze maze2 = new Maze("#####E#_#<    #_#######");
            Maze maze3 = new Maze("##########_#>      E#_##########");
            Maze maze4 = new Maze("#####E#_##### #_#>    #_##### #_#######");
            Maze maze5 = new Maze("#####E#_##### #_##### #_##### #_##### #_#>    #_##### #_#######");

            maze4.Solve();
            Console.WriteLine(maze4.IsSolveable ? "Maze4 can be solved" : "Maze4 cannot be solved");

            //END
            Console.ReadLine();
        }
    }
}
