using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Sudoku
    {
        private int[,] grid = new int[9, 9];
        public Sudoku(int[,] table)
        {
            grid = table;
        }
        public void Show()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    Console.Write(grid[i, j] + " ");
                Console.WriteLine();
            }
        }
        public int[,] GetSudokuFill()
        {
            return grid;
        }
        public bool Possible(int y, int x, int n)
        {
            for (int i = 0; i < 9; i++)
                if (grid[y, i] == n)
                    return false;
            for (int i = 0; i < 9; i++)
                if (grid[i, x] == n)
                    return false;

            int x0 = (x / 3) * 3;
            int y0 = (y / 3) * 3;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (grid[y0 + i, x0 + j] == n)
                        return false;
            return true;
        }

        public void Solve()
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (grid[y, x] == 0)
                    {
                        for (int n = 1; n < 10; n++)
                        {                            
                            if (Possible(y, x, n))
                            {
                                grid[y, x] = n;
                                Solve();
                                grid[y, x] = 0;
                            }
                        }
                        return;
                    }
                }
            }
            Show();
        }
    }
}