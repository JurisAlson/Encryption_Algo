using System;
using System.Linq;
using System.Threading;

class Algo1
{
    private string input;
    private int shifting;

    public Algo1(string userInput)
    {
        
        input = userInput;  
        shifting = GetUserShift();
    }

    private int GetUserShift()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=======================================");
        Console.WriteLine("         CIPHER ALGORITHM MENU         ");
        Console.WriteLine("=======================================\n");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("The Caesar Cipher is a simple encryption technique that shifts each letter in the text by a fixed number of positions in the alphabet.In this program, the user will provide the shifting key to encrypt or decrypt the message.\n");
        Console.WriteLine("=======================================");
        Console.ResetColor();
        while (true)
        {
            
            Console.Write("Enter the shift value: ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int shiftValue))
            {
                return shiftValue;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a numeric value.\n");
                Console.ResetColor();
            }


        }
    }

    public void Process_1()
    {
        Console.WriteLine("\nChoose an option:");
        Console.WriteLine("1. Encrypt");
        Console.WriteLine("2. Decrypt");

        string choice;
        while (true)
        {
            Console.Write("Enter your choice (1/2): ");
            choice = Console.ReadLine()?.Trim();

            if (choice == "1" || choice == "2")
                break;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Please enter '1' for encryption or '2' for decryption.");
            Console.ResetColor();

        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Processing Caesar Cipher...");
        Thread.Sleep(1000);
        Console.WriteLine("Processing Caesar Cipher..");
        Thread.Sleep(1000);
        Console.WriteLine("Processing Caesar Cipher.");
        Console.ResetColor();


        if (choice == "1")
        {
            string encrypted = Encrypt(input, shifting);
            Console.WriteLine($"Original: {input}\n");
            Console.WriteLine($"Encrypted: {encrypted}");
        }
        else
        {
            string decrypted = Decrypt(input, shifting);
            Console.WriteLine($"Ciphertext: {input}\n");
            Console.WriteLine($"Decrypted: {decrypted}");
        }

        Console.ResetColor();

        while (true)
        {
            Console.WriteLine("Do you want to go back to the main menu? (Y/N)");
            string response = Console.ReadLine()?.Trim().ToLower();

            if (response == "y")
            {
                Console.Clear();
                Program.Main();
                return;
            }
            else if (response == "n")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Exiting Caesar Cipher....");
                Thread.Sleep(2000);
                Console.WriteLine("Exiting Caesar Cipher...");
                Thread.Sleep(2000);
                Console.WriteLine("Exiting Caesar Cipher..");
                Console.ResetColor();
                Console.Clear();
                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter 'Y' to return or 'N' to continue.");
                Console.ResetColor();


            }
        }
    }

    private static string Encrypt(string text, int shift)
    {
        return Process(text, shift);
    }

    private static string Decrypt(string text, int shift)
    {
        return Process(text, -shift);
    }

    private static string Process(string text, int shift)
    {
        char[] buffer = text.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];

            if (char.IsLetter(letter))
            {
                char baseChar = char.IsUpper(letter) ? 'A' : 'a'; //65big -97small
                buffer[i] = (char)((letter - baseChar + shift + 26) % 26 + baseChar);
            }
        }
        return new string(buffer);
    }
}
