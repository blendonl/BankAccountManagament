using System;
using System.Linq;
using System.Text;

namespace BankAccountManagamentLibrary.Utils {
    public class NumberGenerator {
        
        private static Random random = new Random();

        public static int GeneratePin() {
            return random.Next(1000, 10000);
        }
        
        public static int GenerateCvv() {
            return random.Next(100, 1000);
        }

        public static long GenerateAccountNumber() {
            return random.Next(100000000, 1000000000);
        }

        public static int GenerateClientId() {
            return random.Next(10000, 100000);
        }

        public static long GenerateCreditCardNumber(int length, int startingPoint) {
            StringBuilder number = new StringBuilder(length);

            FillingWithBlank(number, startingPoint);
            
            FillingOdd(number, startingPoint);

            do {
                FillingEven(number, length, startingPoint);

            } while (!CheckIfnumberIsValnumber(number));

            return long.Parse(number.ToString());
        }

        private static void FillingOdd(StringBuilder number, int startingPoint) {
            for (int i = number.Capacity - 1; i >= startingPoint.ToString().Length; i-= 2) {
                number[i] = char.Parse(random.Next(0, 10).ToString());
            }
        }

        private static void FillingWithBlank(StringBuilder number, int startingPoint) {
            number.Append(startingPoint + "");
            for (int i = 0; i < number.Capacity - startingPoint.ToString().Length; i++) {
                number.Append(' ');
            }
        }


        private static void FillingEven(StringBuilder number, int length, int startingPoint) {
            for (int i = number.Capacity - 2; i >= startingPoint.ToString().Length; i -= 2) {
                number[i] = char.Parse(random.Next(0, 10).ToString());
            }
        }
        
        private static bool CheckIfnumberIsValnumber(StringBuilder number) {
            int even = GetTheSumOfEvenNumbers(number.ToString());
            int odd = GetTheSumOfOddNumbers(number.ToString());
            int mbetj = (even + odd) % 10 ;
            if (mbetj == 0)
                return true;
            else
                return false;
        }

        private static int GetTheSumOfEvenNumbers(string number) {
            if (number.Length >= 2) {
                int next = (int)char.GetNumericValue(number[number.Length - 2]) * 2;
                if (next > 9) {
                    next = next / 10 + next % 10;
                }
                return next + GetTheSumOfEvenNumbers(number.Substring(0, number.Length - 2));
            }
            return 0;
        }
        private static int GetTheSumOfOddNumbers(string number) {
            if (number.Length >= 2) {
                return (int)char.GetNumericValue(number[number.Length -1]) +  GetTheSumOfOddNumbers(number.Substring(0, number.Length - 2));
            }
            return 0;
        }

    }
}