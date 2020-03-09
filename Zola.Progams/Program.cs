using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zola.Progams
{
    class Program
    {/**
 * Problem Statement Given an unsorted array of integer numbers, write a
 * function which returns the number that appears maximum times in the array.
 * 
 * Example: Let the array be 1, 2, 2, 3, 1, 3, 2. Mode of this array is 2.
 * 
 * Example: Let the array be 1, 2, 2, 3, 1, 3, 3, 2. Mode of this array is 2 if
 * two number have same occurrence the lower one is the answer.
 * 
 * Note: Above one number 2 and 3 frequency are same then lower one is 2 so 2 is
 * the answer
 * 
 * Keywords: Array mode, mode of the array, relative majority, plurality, array.
 * 
 * @author kmamani
 *
 */
        static void Main(string[] args)
        {
            ModeOfArray modeProgram = new ModeOfArray();
            AddTwoMatrices matricesProgram = new AddTwoMatrices();
           // modeProgram.display();
            matricesProgram.display();

        }
    }
}
