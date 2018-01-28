using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MazeExplorer;

namespace WindowedExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int CurrentMaze = 1;

        Maze[] Mazes = new Maze[6];

        public MainWindow()
        {
            InitializeComponent();  
        }

        public void DrawMap(Maze maze)
        {
            string output = "";

            for (int y = 0; y < maze.Layout.GetLength(1); y++)
            {
                for (int x = 0; x < maze.Layout.GetLength(0); x++)
                {
                    if (maze.explorer.X == x && maze.explorer.Y == y)
                    {
                        output += maze.explorer.Facing;
                    }
                    else
                    {
                        output += maze.Layout[x, y].Character;
                    }
                }
                output += "\n";
            }

            Display.Text = output;
        }

        private void maze1_Clicked(object sender, RoutedEventArgs e)
        {
            CurrentMaze = 0;
            Mazes[0] = new Maze("#######_#>   E#_#######");
            DrawMap(Mazes[0]);
        }

        private void maze2_Clicked(object sender, RoutedEventArgs e)
        {
            CurrentMaze = 1;
            Mazes[1] = new Maze("#####E#_#<    #_#######");
            DrawMap(Mazes[1]);
        }

        private void maze3_Clicked(object sender, RoutedEventArgs e)
        {
            CurrentMaze = 2;
            Mazes[2] = new Maze("##########_#>      E#_##########");
            DrawMap(Mazes[2]);
        }

        private void maze4_Clicked(object sender, RoutedEventArgs e)
        {
            CurrentMaze = 3;
            Mazes[3] = new Maze("#####E#_##### #_#>    #_##### #_#######");
            DrawMap(Mazes[3]);
        }

        private void maze5_Clicked(object sender, RoutedEventArgs e)
        {
            CurrentMaze = 4;
            Mazes[4] = new Maze("#####E#_##### #_##### #_##### #_##### #_#>    #_##### #_#######");
            DrawMap(Mazes[4]);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mazes[CurrentMaze].explorer.Step(Mazes[CurrentMaze]);
            DrawMap(Mazes[CurrentMaze]);
        }

        private void maze6_Clicked(object sender, RoutedEventArgs e)
        {
            CurrentMaze = 5;
            string map = Custom.Text.Replace("\r\n","_");
            Mazes[5] = new Maze(map);
            DrawMap(Mazes[5]);
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Mazes[CurrentMaze].explorer.ResetMoveCounter();
        }
    }
}
