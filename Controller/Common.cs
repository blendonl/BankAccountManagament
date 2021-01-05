using System;

namespace Controller {


    /// <summary>
    /// Common methods used more than once in console view
    /// </summary>
    public static class Common {
        

       public static int Menu( string[] choices) {

            // prints all the choices
            for (int i = 0; i < choices.Length; i++)
                Console.WriteLine($"Press {i} to {choices[i]}");
            Console.WriteLine();

            // gets a choice from user
            Console.Write("Choose: ");
            int choice;

            // check if user typet number
            if (!int.TryParse(Console.ReadLine(), out choice))
                choice = -1;

            // return's the user choice 
            return choice;
        }

        /// <summary>
        /// Method that asks user for input
        /// </summary>
        /// <param name="inputType">Input type</param>
        /// <returns>return the user input</returns>
        public static string Input(string inputType, int length) {

            // returns the input from user
            Console.Write($"{inputType}: ");
            string s = Console.ReadLine();
            if (String.IsNullOrEmpty(s) || s.Length < length) {
                Console.WriteLine($"Please enter a valid {length} chars string");
                return Input(inputType, length);
            }
            return s;
        }

        /// <summary>
        /// Prints title
        /// </summary>
        /// <param name="title"></param>
        public static void Title(string title) {

            // Prints title
            Console.Clear();
            Console.WriteLine(title);
            Console.WriteLine();

        }


        /// <summary>
        /// Loops input in the cases user doesnt press a number
        /// </summary>
        /// <param name="title">the title of the input(for example name)</param>
        /// <returns></returns>
        public static long LoopInput(string title, int length) {

            // check if the value from user can be converted to long
            long value;
            if(!long.TryParse(Input(title, 1), out value)) {
                
                // shows message and repeats the above steps
                Console.WriteLine("Please enter a valid number");
                return LoopInput(title, length);
            }
            else if(value.ToString().Length < length) {
                Console.WriteLine($"Please enter a {length} digits number");
                return LoopInput(title, length);
            } 
                

            // return the value from user
            return value;

        }
        
         public static decimal LoopMoneyInput(string title, int length) {
             // check if the value from user can be converted to long
            decimal value;
            if(!decimal.TryParse(Input(title, 1), out value)) {
                
                // shows message and repeats the above steps
                // Console.WriteLine("Please enter a valid number");
                return LoopInput(title, length);
            }
            else if(value.ToString().Length < length) { 
                Console.WriteLine($"Please enter a {length} digits number"); 
                return LoopInput(title, length);
            } 
            // return the value from user
            
            return value;
        
        }

          

    }
}

