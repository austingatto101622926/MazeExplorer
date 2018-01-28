using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeExplorer.Blocks;

namespace MazeExplorer
{
    public class Maze
    {
        public Block[,] Layout;
        public Explorer explorer;

        private char EmptyChar = ' ';
        private char ExitChar = 'E';
        private char WallChar = '#';
        private char SeperatorChar = '_';

        public bool IsSolveable = false;

        public Maze(string map)
        {
            //Instatiate Explorer
            explorer = new Explorer();

            //Convert map string to Char Array
            string[] hSlice = map.Split(SeperatorChar);
            Layout = new Block[hSlice[0].Length, hSlice.Length];
            
            for (int y = 0; y < hSlice.Length; y++)
            {
                for (int x = 0; x < hSlice[y].Length; x++)
                {
                    if (hSlice[y][x] == WallChar) Layout[x, y] = new Wall();
                    if (hSlice[y][x] == ExitChar) Layout[x, y] = new Exit();
                    if (hSlice[y][x] == EmptyChar) Layout[x, y] = new Empty();

                    //Set Explorer
                    foreach (char character in explorer.Characters)
                    {
                        if (hSlice[y][x] == character)
                        {
                            Layout[x, y] = new Empty();
                            explorer.SetLocation(x, y, character);
                        }
                    }
                }
            }
        }

        public void Solve()
        {
            explorer.Solve(this, true);
        }

        private Block GetBlockAt(int x, int y)
        {
            return Layout[x, y];
        }

        public bool IsFree(int x, int y)
        {
            if (GetBlockAt(x,y).Character != WallChar)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsExit(int x, int y)
        {
            if (GetBlockAt(x, y).Character == ExitChar)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
