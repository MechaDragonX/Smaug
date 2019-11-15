using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smaug.Extensions;

namespace Smaug
{
    class Program
    {
        public static int[,] maze;
        public static LinkedList<Point> path = new LinkedList<Point>();

        static void Main(string[] args)
        {
            Initialize();
            Point start = Start();
            Console.WriteLine("Start at: " + start + "\n");
            Console.WriteLine("---------------------------");
            Print();
            Console.WriteLine("---------------------------");
            FindPath(start.X, start.Y);
            maze[start.X, start.Y] = 2;
            Print();
            Console.WriteLine("---------------------------");
            path.Print();
            Console.ReadKey();
        }
        private static void Initialize()
        {
            maze = new int[,] {
                                { 1, 2, 1, 1, 1, 1 },
                                { 1, 0, 1, 0, 0, 1 },
                                { 1, 0, 1, 0, 1, 1 },
                                { 1, 0, 0, 0, 0, 1 },
                                { 1, 1, 0, 1, 0, 1 },
                                { 1, 1, 0, 1, 0, 1 },
                                { 1, 0, 0, 1, 0, 1 },
                                { 1, 0, 1, 1, 1, 1 },
                                { 1, 0, 0, 0, 0, 1 },
                                { 1, 0, 1, 0, 1, 1 },
                                { 1, 1, 0, 0, 1, 1 },
                                { 1, 1, 3, 1, 1, 1 }
                            };


            //maze = new int[,] {
            //                    { 2, 1, 1, 1, 1, 1 },
            //                    { 0, 0, 0, 0, 0, 0 },
            //                    { 1, 0, 1, 0, 1, 0 },
            //                    { 1, 0, 1, 0, 1, 0 },
            //                    { 0, 0, 0, 1, 0, 3 },
            //                    { 1, 1, 0, 0, 0, 1 },
            //                };
        }
        private static Point Start()
        {
            for(int i = 0; i < maze.GetUpperBound(1); i++)
            {
                if(maze[0, i] == 2)
                {
                    return new Point(0, i);
                }
                if(maze[maze.GetUpperBound(0) - 1, i] == 2)
                {
                    return new Point(maze.GetUpperBound(0) - 1, i);
                }
            }
            for(int j = 0; j < maze.GetUpperBound(0); j++)
            {
                if(maze[j, 0] == 2)
                {
                    return new Point(j, 0);
                }
                if (maze[j, maze.GetUpperBound(1) - 1] == 2)
                {
                    return new Point(j, maze.GetUpperBound(1) - 1);
                }
            }
            return null;
        }
        private static bool FindPath(int row, int col)
        {
            Point point = new Point(row, col);
            if(point.X < 0 || point.Y < 0 || point.X > maze.GetUpperBound(0) || point.Y > maze.GetUpperBound(1))
                return false;
            if(maze[point.X, point.Y] == 3)
            {
                path.AddLast(point);
                Console.WriteLine("Exit at ({0}, {1})!", point.X, point.Y);
                return true;
            }
            if(maze[point.X, point.Y] == 1)
            {
                if(path.Contains(point)) path.Remove(point);
                Console.WriteLine("Blocked at ({0}, {1})", point.X, point.Y);
                return false;
            }
            if (maze[point.X, point.Y] == 0 || maze[point.X, point.Y] == 2)
            {
                maze[point.X, point.Y] = 4;
                Console.WriteLine("Visiting ({0}, {1})", point.X, point.Y);
                path.AddLast(point);
                if(FindPath(point.X, point.Y + 1)) return true; // right
                if(FindPath(point.X, point.Y - 1)) return true; // left
                if(FindPath(point.X - 1, point.Y)) return true; // up
                if(FindPath(point.X + 1, point.Y)) return true; // down
                maze[point.X, point.Y] = 5;
                Console.WriteLine("Left ({0}, {1})", point.X, point.Y);
                if(path.Contains(point)) path.Remove(point);
            }
            return false;
        }
        private static void Print()
        {
            for(int i = 0; i <= maze.GetUpperBound(0); i++)
            {
                for(int j = 0; j <= maze.GetUpperBound(1); j++)
                {
                    if(maze[i, j] == 0) Console.Write(maze[i, j] + "\t");
                    else if(maze[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(maze[i, j] + "\t");
                        Console.ResetColor();
                    }
                    else if(maze[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(maze[i, j] + "\t");
                        Console.ResetColor();
                    }
                    else if(maze[i, j] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(maze[i, j] + "\t");
                        Console.ResetColor();
                    }
                    else if(maze[i, j] == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(maze[i, j] + "\t");
                        Console.ResetColor();
                    }
                    else if(maze[i, j] == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(maze[i, j] + "\t");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }
    }

  
}
