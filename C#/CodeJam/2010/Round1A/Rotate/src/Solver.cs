using System;
using System.Collections.Generic;

namespace CodeJam._2010.Round1A.Rotate.src
{
    public class Solver
    {
        public string Solve(Case newCase)
        {
            var list = GravityRight(newCase.Grid);
            var RWins = this.CheckWin(list, 'R', newCase.K);
            var BWins = this.CheckWin(list, 'B', newCase.K);

            if (RWins && BWins)
            {
                return "Both";
            }
            if (BWins)
            {
                return "Blue";
            }
            if (RWins)
            {
                return "Red";
            }
            return "Neither";
        }

        public bool CheckWin(char[,] grid, char player, int k)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                for (int y = 0; y < grid.GetLength(0); y++)
                {
                    if (grid[y, x] == player)
                    {
                        //up
                        if (this.Check(grid, player, k, x, y, 0, 1))
                            return true;

                        //down
                        if (this.Check(grid, player, k, x, y, 0, -1))
                            return true;

                        //left
                        if (this.Check(grid, player, k, x, y, 1, 0))
                            return true;

                        //right
                        if (this.Check(grid, player, k, x, y, 0, -1))
                            return true;

                        //ne
                        if (this.Check(grid, player, k, x, y, 1, 1))
                            return true;

                        //se
                        if (this.Check(grid, player, k, x, y, 1, -1))
                            return true;

                        //sw
                        if (this.Check(grid, player, k, x, y, -1, -1))
                            return true;

                        //nw
                        if (this.Check(grid, player, k, x, y, -1, 1))
                            return true;
                    }
                }
            }
            return false;
        }

        public bool Check(char[,] grid, char player, int k, int x, int y, int modX, int modY)
        {
            var length = grid.GetLength(0);
            var matching = 0;
            for (int i = 0; i < k; i++)
            {
                var newX = x + (modX * i);
                var newY = y + (modY * i);
                if (length > newX && newX > -1 && length > newY && newY > -1 && grid[newY, newX] == player)
                {
                    matching++;
                    if (matching == k)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public char[,] GravityRight(char[,] grid)
        {
            var rows = grid.GetLength(0);
            var columns = grid.GetLength(1);
            var newGrid = new char[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                var row = new List<char>();
                for (int j = columns - 1; j >= 0; j--)
                {
                    var cell = grid[i, j];
                    if (cell == 'R' || cell == 'B')
                    {
                        row.Add(grid[i, j]);
                    }
                }
                for (int j = 0; j < row.Count; j++)
                {
                    var position = columns - 1 - j;
                    newGrid[i, position] = row[j];
                }
            }
            return newGrid;
        }

        public List<string> GravityRightCorner(char[,] grid)
        {
            var rows = grid.GetLength(0);
            var columns = grid.GetLength(1);
            var newGrid = new List<string>();
            for (int i = 0; i < rows; i++)
            {
                var row = string.Empty;
                for (int j = columns - 1; j >= 0; j--)
                {
                    var cell = grid[i, j];
                    if (cell == 'R' || cell == 'B')
                    {
                        row += cell;
                    }
                }
                if (string.IsNullOrEmpty(row))
                {
                    break;
                }
                newGrid.Add(row);
            }
            return newGrid;
        }

        public bool CheckWin(List<string> grid, char player, int k)
        {
            var win = new string(player, k);
            var length = 0;

            //horz
            for (int i = 0; i < grid.Count; i++)
            {
                var row = grid[i];
                if (length < row.Length)
                {
                    length = row.Length;
                }
                if (grid[i].Contains(win))
                {
                    return true;
                }
            }

            //vert
            for (int i = 0; i < length; i++)
            {
                var column = string.Empty;
                for (int j = 0; j < grid.Count; j++)
                {
                    if (grid[j].Length > i)
                    {
                        column += grid[j][i];
                    }
                }

                if (column.Contains(win))
                {
                    return true;
                }
            }

            //dia up
            for (int j = 0; j < grid.Count; j++)
            {
                var updiag = string.Empty;
                for (int l = 0; l < length; l++)
                {
                    if (grid.Count > j + l && grid[j + l].Length > l)
                    {
                        updiag += grid[j + l][l];
                    }
                }
                if (updiag.Contains(win))
                {
                    return true;
                }
            }
            for (int j = 0; j < length; j++)
            {
                var updiag = string.Empty;
                for (int l = 0; l < grid.Count; l++)
                {
                    if (grid[l].Length > j + l)
                    {
                        updiag += grid[l][j + l];
                    }
                }
                if (updiag.Contains(win))
                {
                    return true;
                }
            }

            //dia down

            for (int j = 0; j < grid.Count; j++)
            {
                var downdiag = string.Empty;
                for (int l = 0; l < length; l++)
                {
                    if (-1 < j - l && grid[j - l].Length > l)
                    {
                        downdiag += grid[j - l][l];
                    }
                    else
                    {
                        downdiag += '.';
                    }
                }
                if (downdiag.Contains(win))
                {
                    return true;
                }
            }

            for (int j = 0; j < length; j++)
            {
                var downdiag = string.Empty;
                for (int l = 0; l < grid.Count; l++)
                {
                    if (-1 < j - l && grid[l].Length > j - l)
                    {
                        downdiag += grid[l][j - l];
                    }
                    else
                    {
                        downdiag += '.';
                    }
                }
                if (downdiag.Contains(win))
                {
                    return true;
                }
            }

            for (int j = 0; j < length; j++)
            {
                var downdiag = string.Empty;
                for (int l = 0; l < grid.Count; l++)
                {
                    if (grid.Count - l - 1 < -1 && grid[grid.Count - l - 1].Length > l)
                    {
                        downdiag += grid[grid.Count - l - 1][l];
                    }
                    else
                    {
                        downdiag += '.';
                    }
                }
                if (downdiag.Contains(win))
                {
                    return true;
                }
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------");
            Console.WriteLine(win);
            Console.WriteLine();
            foreach (var item in grid)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------------------");
            Console.WriteLine();
            return false;
        }
    }
}