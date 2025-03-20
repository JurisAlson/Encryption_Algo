using System;
using System.Linq;
using System.Threading;

class Program
{
    public static void Main()
    {
        Console.Title = "Cipher Algorithm Menu";
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();

        while (true)
        {
            int choice = 0;

            // Display menu until user enters a valid choice (1-5)
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=======================================");
                Console.WriteLine("         CIPHER ALGORITHM MENU         ");
                Console.WriteLine("=======================================\n");
                Console.ResetColor();


                Console.WriteLine("  [1] Caesar Cipher");
                Console.WriteLine("  [2] Kama Sutra Cipher");
                Console.WriteLine("  [3] Bitwise XOR Cipher");
                Console.WriteLine("  [4] Freestyle Algorithm");
                Console.WriteLine("  [5] Exit");
                Console.WriteLine("=======================================");
                Console.ResetColor();

                Console.Write("Enter your choice (1-5): ");
                string choiceInput = Console.ReadLine();

                if (int.TryParse(choiceInput, out choice) && choice >= 1 && choice <= 5)
                    break; 

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Invalid choice! Please enter a number between 1 and 5.");
                Console.ResetColor();
                Thread.Sleep(1500);
            }

            if (choice == 5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nExiting program. Have a great day!");
                Console.ResetColor();
                return;
            }

     
            string userInput;
            while (true)
            {
                Console.Write("\nEnter a string (only A-Z, a-z, and spaces allowed): ");
                userInput = Console.ReadLine();

                if (!userInput.All(c => char.IsLetter(c) || c == ' '))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input! Only letters (A-Z, a-z) and spaces are allowed.");
                    Console.ResetColor();
                    continue; //ulet ka ya
                }
                break; 
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nProcessing your selection...");
            Thread.Sleep(1000);
            Console.WriteLine("Processing your selection..");
            Console.ResetColor();
            Thread.Sleep(1000);
            switch (choice)
            {
                case 1:
                    Algo1 algo1 = new Algo1(userInput);
                    algo1.Process_1();
                    break;
                case 2:
                    Algo2 algo2 = new Algo2(userInput);
                    algo2.Process_2();
                    break;
                case 3:
                    Algo3 algo3 = new Algo3(userInput);
                    algo3.Process_3();
                    break;
                case 4:
                    Algo4 Algo4 = new Algo4(userInput);
                    Algo4.Process_4();
                    break;
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
