using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PrimeNumbers
{
    public class Program
    {


        /// <summary>
        /// Outputs Factors Numbers
        /// </summary>
        /// <param name="args">filename</param>
        static void Main(string[] args)
        {


            try
            {
                if (hasParameter(args))
                {

                    FactorIOManager fio = new FactorIOManager();
                    if (fio.readFile(args[0]))
                    {
                        fio.showResults();
                    }

                }

                Console.WriteLine("\n press Enter to exit:");
                Console.ReadLine();
                return;

            }
            catch (Exception e)
            {

                Console.WriteLine("oops - " + e.Message);
            }
        }

        /// <summary>
        /// checks for at least one parameter
        /// </summary>
        /// <param name="args"></param>
        /// <returns>bool</returns>
        static bool hasParameter(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("ERROR:");
                Console.WriteLine(" Please provide a filename as a command line argument.");
                Console.WriteLine(" Usage: PrimeNumbers <your file name here> ");
                Console.WriteLine(" Example: PrimeNumbers myNumbers.txt ");
                return false;
            }
            return true;
        }



    }
}
