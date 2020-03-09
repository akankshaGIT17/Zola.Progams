using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zola.Progams
{
   public class AddTwoMatrices
    {
      public void display() 
        {
            int row = 3;
            int col = 4;
            int[,] matrix1 = new int[3, 4];
            int[,] matrix2 = new int[3, 4];
            int[,] matrix3 = new int[3, 4];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix1[i, j] = Convert.ToInt32(Console.ReadLine());

                }
            }
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        matrix2[i, j] = Convert.ToInt32(Console.ReadLine());

                    }
                }
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        matrix3[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write(matrix3[i, j] + "  ");
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
            
        }
    }
}
