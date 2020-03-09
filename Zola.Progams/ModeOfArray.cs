using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zola.Progams
{
   public class ModeOfArray
    {
       public void display()
        {
            Console.WriteLine("Enter array size");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];
            int i = 0;
            int count = 1;
            int maxCount = 1;
            int mode = 0;

            while (i < size)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
                i++;
            }
            int previous = arr[0];
            for (i = 1; i < size; i++)
            {
                if (arr[i] == previous)
                {
                    count++;
                }
                else
                {
                    if (count > maxCount)
                    {
                        mode = arr[i - 1];
                        maxCount = count;
                    }
                    previous = arr[i];
                    count = 1;
                }
                if (count > maxCount)
                    mode = arr[size - 1];
            }
            Console.WriteLine(mode);
        }
    }
}
