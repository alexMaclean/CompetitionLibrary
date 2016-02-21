using System;
using System.Collections.Generic;

class Maze
{
    class MazeField
    {
        public MazeField(int row, int column, char c)
        {
            this.row = row;
            this.column = column;
            this.c = c;
        }

        public int row;
        public int column;
        public char c;
    }

    /// <summary>
    /// Prints a maze.
    /// </summary>
    public static void PrintMaze(char[,] maze)
    {
        for(int row = 0; row < maze.GetLength(0); ++row) {
            for(int column = 0; column < maze.GetLength(1); ++column) {
                Console.Write(maze[row, column]);
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    /// <summary>
    /// The SolveMaze method starts at [row,column] and goes through the maze. It won't move over any characters contained in cantPass ("walls").
    /// It will replace the fields it went over with pathChar. If printMaze is true, it prints each maze that is solved (Although we should do the output formatting in main by
    /// modifying the maze along the path*). If reachChar is '\0', the function
    /// will try to get out of the maze. If it's another character, it will try to go to that character.
    /// 
    /// It returns a List of a 3 item tuple. The first two items are the row and column where the function either "escaped" the maze or where it is in front of the reachChar.
    /// *The third element is a List of tuples of 2 ints. That's the path "walked", not including the starting position. That will be useful for printing and also finding the shortest path!
    /// 
    /// I tested this function with Pac-Dude (and it worked) and on self-made maze's.
    /// </summary>
    public static List<Tuple<int, int, List<Tuple<int, int>>>> SolveMaze(char[,] maze, int row, int column, List<char> cantPass, char pathChar = '\0', bool printMaze = false, char reachChar = '\0')
    {
        var neighbors = new MazeField[4];

        neighbors[0] = row > 0 ? new MazeField(row - 1, column, maze[row - 1, column]) : null;
        neighbors[1] = column < maze.GetLength(1) - 1 ? new MazeField(row, column + 1, maze[row, column + 1]) : null;
        neighbors[2] = row < maze.GetLength(0) - 1 ? new MazeField(row + 1, column, maze[row + 1, column]) : null;
        neighbors[3] = column > 0 ? new MazeField(row, column - 1, maze[row, column - 1]) : null;

        var result = new List<Tuple<int, int, List<Tuple<int, int>>>>();
        var mazeBackup = new char[maze.GetLength(0), maze.GetLength(1)];

        Array.Copy(maze, mazeBackup, maze.Length);
        maze[row, column] = pathChar;

        for (int i = 0; i < neighbors.Length; ++i) {
            if (reachChar != '\0' && neighbors[i] == null) {
                continue;
            }

            if (neighbors[i] == null || neighbors[i].c == reachChar) {
                result.Add(new Tuple<int, int, List<Tuple<int, int>>>(row, column, new List<Tuple<int,int>>()));
                if (printMaze) {
                    PrintMaze(maze);
                }
                break;
            }
            
            if (!cantPass.Contains(neighbors[i].c) && neighbors[i].c != pathChar) {
                maze[row, column] = pathChar;
                var res = SolveMaze(maze, neighbors[i].row, neighbors[i].column, cantPass, pathChar, printMaze, reachChar);
                if (res.Count != 0) {
                    for (int j = 0; j < res.Count; ++j) {
                        res[j].Item3.Insert(0, new Tuple<int, int>(neighbors[i].row, neighbors[i].column));
                        result.Add(res[j]);
                    }
                }
                Array.Copy(mazeBackup, maze, mazeBackup.Length);
            }
        }

        return result;
    }
}
