using System;

class Algo3
{
    private string input;

    public Algo3(string userInput)
    {
        input = userInput;
    }

    public void Process_3()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=======================================");
        Console.WriteLine("         CIPHER ALGORITHM              ");
        Console.WriteLine("=======================================\n");
        Console.WriteLine("A bitwise XOR cipher converts each character into its ASCII binary form and applies an XOR operation with a numeric key (0–255), flipping bits where the key has 1s. In your code, (char)(text[i] ^ key) performs this XOR operation, but non-letter results are forced into uppercase letters using (xorChar % 26) + 'A', which can unintentionally modify the encryption output.");
        Console.ResetColor();

        int key = GetNumericKey();
        if (key == -1) return; // Exit if invalid key input

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("[E] Encrypt");
            Console.WriteLine("[D] Decrypt");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine()?.Trim().ToUpper();

            if (choice == "E")
            {
                string encrypted = XORCipher(input, key);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nEncrypted Output: " + encrypted);
                Console.ResetColor();
            }
            else if (choice == "D")
            {
                Console.Write("\nEnter the encrypted text to decrypt: ");
                string encryptedInput = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(encryptedInput))
                {
                    DisplayError("Invalid input. Please enter a valid encrypted text.");
                    continue;
                }

                string decrypted = XORCipher(encryptedInput, key);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nDecrypted Output: " + decrypted);
                Console.ResetColor();
            }
            else
            {
                DisplayError("Invalid choice. Please enter 'E' for Encrypt or 'D' for Decrypt.");
            }

            Console.Write("\nDo you want to continue? (Y/N): ");
            string continueChoice = Console.ReadLine()?.Trim().ToUpper();
            if (continueChoice != "Y") break;
        }
    }
    private int GetNumericKey()
    {
        int key;
        while (true)
        {
            Console.Write("Enter a numeric key (0-255): ");
            if (int.TryParse(Console.ReadLine(), out key) && key >= 0 && key <= 255)
            {
                return key; 
            }
            DisplayError("Invalid key. Please enter a number between 0 and 255.");
        }
    }

    private string XORCipher(string text, int key)
    {
        char[] result = new char[text.Length];

        for (int i = 0; i < text.Length; i++)
        {
            char xorChar = (char)(text[i] ^ key);

            if (!char.IsLetter(xorChar))
            {
                xorChar = (char)((xorChar % 26) + 'A');//65 asci
            }

            result[i] = xorChar;
        }

        return new string(result);
    }


    // Display an error message in red
    private void DisplayError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nError: " + message);
        Console.ResetColor();
    }
}
