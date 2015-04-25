using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace CountFactorielZeros
{
    class CountFactorielZeros
    {
        /// <Exercise>
        /// Write a program that calculates for given N how many trailing zeros present at the end of the number N!. 
        /// Examples: 
        /// N = 10 - N! = 3628800 - 2 zeros
        /// N = 20 - N! = 2432902008176640000 - 4 zeros
        /// Your program should work for N up to 50 000.
        /// Three variants of decision are included
        /// </Exercise>
        
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());

            int count = 1;

            BigInteger result = 1;

            do
            {
                result = result * count;

                count++;

            } while (count <= number);

            Console.WriteLine("Factoriel of {0}, is: ", number);
            Console.WriteLine(result);

            //Decision variant 1: Devison to 5 dependence is used
            //5! = 120 so 5/5 = 1 and 1/5 = 0,2 sum 1 + 0 = 1 zero at the end
            //10! = 3628800 devide 10/5 = 2 and 2/5 = 0,4 sum 2 + 0 = 2 zeros at the end
            //15! = 1307674368000 devide 15/5 = 3 and 3/5 = 0,6 sum 3 + 0 = 3 zeros at the end
            //25! = 15511210043330985984000000 devide 25/5 = 5 and 5/5 = 1,0 sum 5 + 1 = 6 zeros at the end

            # region Variant 1

            // works only for numbers up to 124!

            if (number <= 124)
            {
                int devidor = number / 5;

                int plusVlaue = devidor / 5;

                int countOfZerosVar1 = devidor + plusVlaue;

                Console.WriteLine("At the end of the result there is {0} zeros /.var1/", countOfZerosVar1);
            }

            else
            {
                Console.WriteLine("This variant works only with numbers <= 124! /.var1/");
            }

            # endregion

            //Decision variant 2: Here is used more rough, method - simply counting zeros at the end of the result
            //Using result string as array of chars and counting how many chars zero are at the end.

            # region Variant 2

            //Decision variant 2a: with for loop

            string resultString = Convert.ToString(result);

            int countOfZerosVar2A = 0;

            for (int i = resultString.Length - 1; i > 0; i--)
            {
                if (resultString[i] != '0')
                {
                    break;
                }

                else if (resultString[i] == '0')
                {
                    countOfZerosVar2A++;
                }
            }

            Console.WriteLine("At the end of the result there is {0} zeros /.var2a/", countOfZerosVar2A);


            //Decision variant 2b: with do-while loop

            int countOfZerosVar2B = 0;

            int j = resultString.Length - 1;

            do
            {
                countOfZerosVar2B++;
                j--;
            } while (resultString[j] == '0');

            Console.WriteLine("At the end of the result there is {0} zeros /.var2b/", countOfZerosVar2B);

            # endregion

            //Decision variant 3: A variant of Devison to 5 dependence is used but with do while loop 
            //to ensure counting of zeros of numbers bigger than 124!

            # region Variant 3

            int countOfZerosVar3 = 0;

            do
            {
                countOfZerosVar3 = countOfZerosVar3 + number / 5;

                number = number / 5;

            } while (number / 5 != 0);

            Console.WriteLine("At the end of the result there is {0} zeros /.var3/", countOfZerosVar3);

            #endregion
        }
    }
}
