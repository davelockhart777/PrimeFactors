using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PrimeNumbers
{
    class FactorIOManager
    {
        private List<FactorGen> numberList;

        public FactorIOManager()
        {
            numberList = new List<FactorGen>();

        }

        /// <summary>
        /// checks if the given file exist
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>bool</returns>
        private bool fileExist(string filename)
        {
            if (!System.IO.File.Exists(filename))
            {
                Console.WriteLine("Could not find file : " + filename);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Reads the file and processes each line
        /// Returns false if the given filename does not exist.
        /// Returns false if errors are produced while processing the file.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>bool</returns>
        public bool readFile(string filename)
        {
            int lineCounter = 0;
            int successCounter = 0;
            int errorCounter = 0;
            string line = "";
            int maxErrorThreshold = 10;
            bool readResult = false;
            StreamReader file = null;

            if (!fileExist(filename))
            {
                return false;
            }

            try
            {
                Console.WriteLine("Reading File: " + filename);
                file = new System.IO.StreamReader(filename);
                while ((line = file.ReadLine()) != null)
                {
                    lineCounter++;
                    FactorGen item = new FactorGen(line);
                    if (item.status == FactorGen.FAIL)
                    {
                        errorCounter++;
                        Console.WriteLine("ERROR: line - " + lineCounter + " " + item.errorMsg);
                        if (errorCounter > maxErrorThreshold)
                        {
                            Console.WriteLine("ABORT: encountered too many errors");
                            file.Close();
                            return false;
                        }
                    }
                    else
                    {
                        numberList.Add(item);
                        successCounter++;
                    }

                }
                readResult = true;
                Console.WriteLine("Processed " + lineCounter + " lines.");
                Console.WriteLine("Errors : " + errorCounter);

            }
            catch (Exception e)
            {
                readResult = false;
                Console.WriteLine("ABORT: " + e.Message);

            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }

            return readResult;
        }

        /// <summary>
        /// Displays the results for the list of numbers
        /// </summary>
        public void showResults()
        {
            Console.WriteLine("Results:");
            Console.WriteLine("------------------------------------");

            foreach (FactorGen item in numberList)
            {
                Console.WriteLine(item.getFactorString());
            }
        }

    }
}
