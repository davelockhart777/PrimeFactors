using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    public class FactorGen
    {
        public const int SUCCESS = 0;
        public const int FAIL = 1;
        public const string TOO_LONG = " is to long.";
        public const string NOT_INT = " is not an int.";


        public int inputInt { get; set; }
        public List<int> factors;
        public int status { get; set; }
        public string errorMsg { get; set; }


        /// <summary>
        /// Constructor of FactorGen. 
        /// A factor list is created and stored until needed for display.
        /// </summary>
        /// <param name="input">integer from each line of the input file</param>
        public FactorGen(string input)
        {
            int num = 0;
            bool test = false;
            status = FAIL;
            factors = new List<int>();
            int maxLength = int.MaxValue.ToString().Length;
            int maximumFactor = 0;



            if (input.Length > maxLength)
            {
                this.errorMsg = input + TOO_LONG;
                status = FAIL;
                return;
            }

            test = int.TryParse(input, out num);
            if (test == false)
            {
                this.errorMsg = input + NOT_INT;
                status = FAIL;
                return;
            }

            //store the given number for later reference 
            inputInt = num;


            //get factors 
            while (num > 1)
            {
                var primeFactor = 2;
                if (num % primeFactor > 0)
                {
                    primeFactor = 3;
                    do
                    {
                        if (num % primeFactor == 0)
                        {
                            break;
                        }

                        primeFactor += 2;
                    } while (primeFactor < num);
                }

                num /= primeFactor;
                factors.Add(primeFactor);
                if (primeFactor > maximumFactor)
                {
                    maximumFactor = primeFactor;
                }
            }


            status = SUCCESS;
        }

        /// <summary>
        /// Returns comma delimited list of factors
        /// </summary>
        /// <returns></returns>
        public string getFactorString()
        {
            string outputString = "";
            bool needComma = false;
            foreach (int item in this.factors)
            {
                if (needComma) { outputString += ","; }
                needComma = true;
                outputString += item.ToString();
            }
           
            return outputString;
        }


    }
}
