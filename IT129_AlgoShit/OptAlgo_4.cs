using System;

class Algo4
{
    private string input;

    /*The idea of *Encryption works by taking the user’s input data and randomly assigning a shift 
     direction (left < or right >) and the shift value (number of times each character moves). 
     Each character is then modified based on these randomly generated values. */

    public Algo4(string userInput)
    {
        input = userInput;
    }

    public void Process_4()
    {

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Processing Custom Shift Cipher");
        Console.ResetColor();

        while (true)
        {
            Console.WriteLine("Do you want to (E)ncrypt or (D)ecrypt?");
            string choice = Console.ReadLine().Trim().ToLower();

            if (choice == "e")
            {
                Encrypt();
                break;
            }
            else if (choice == "d")
            {
                Decrypt();
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 'E' to encrypt or 'D' to decrypt.");
            }
        }

        ReturnToMenu();
    }

    private void Encrypt()
    {
        Random rand = new Random();
        int[] shifts = new int[input.Length];
        char[] directions = new char[input.Length];
        char[] encryptedChars = new char[input.Length];

        Console.WriteLine("\nEncryption Details:");

        for (int i = 0; i < input.Length; i++)
        {
            shifts[i] = rand.Next(1, 10);
            directions[i] = rand.Next(2) == 0 ? '>' : '<';

            int newAscii = directions[i] == '>'
                ? input[i] + shifts[i]
                : input[i] - shifts[i];

            if (newAscii < 32) newAscii += 95;
            if (newAscii > 126) newAscii -= 95;

            encryptedChars[i] = (char)newAscii;
            Console.WriteLine($"Character: {input[i]} | Shift: {shifts[i]} | Direction: {directions[i]}");
        }

        Console.WriteLine("\nFinal Encrypted Output: " + new string(encryptedChars));
        Console.Write("Shifts Used: ");
        Console.WriteLine(string.Join("", shifts));
        Console.Write("Directions Used: ");
        Console.WriteLine(string.Join("", directions));
    }

    private void Decrypt()
    {
        Console.Write("Enter the encrypted text: ");
        string encryptedText = Console.ReadLine();

        string shiftInput = "";
        while (shiftInput.Length != encryptedText.Length)
        {
            Console.Write("Enter the shift numbers (no spaces): ");
            shiftInput = Console.ReadLine();

            if (shiftInput.Length != encryptedText.Length)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Length mismatch. Make sure shift numbers match the encrypted text length.");
                Console.ResetColor();
            }
        }

        string directionInput = "";
        while (directionInput.Length != encryptedText.Length)
        {
            Console.Write("Enter the shift directions (only '>' or '<', no spaces): ");
            directionInput = Console.ReadLine();

            if (directionInput.Length != encryptedText.Length)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Length mismatch. Make sure shift directions match the encrypted text length.");
                Console.ResetColor();
            }
        }

        int[] shifts = new int[encryptedText.Length];
        char[] directions = new char[encryptedText.Length];
        char[] decryptedChars = new char[encryptedText.Length];

        for (int i = 0; i < encryptedText.Length; i++)
        {
            if (!char.IsDigit(shiftInput[i]))
            {
                Console.WriteLine("Error: Invalid shift numbers. Only digits are allowed.");
                return;
            }
            if (directionInput[i] != '>' && directionInput[i] != '<')
            {
                Console.WriteLine("Error: Invalid direction input. Use only '>' or '<'.");
                return;
            }

            shifts[i] = shiftInput[i] - '0';
            directions[i] = directionInput[i];

            int newAscii = directions[i] == '>'
                ? encryptedText[i] - shifts[i]
                : encryptedText[i] + shifts[i];

            if (newAscii < 32) newAscii += 95;
            if (newAscii > 126) newAscii -= 95;

            decryptedChars[i] = (char)newAscii;
        }

        Console.WriteLine("\nDecrypted Output: " + new string(decryptedChars));
    }

    private void ReturnToMenu()
    {
        while (true)
        {
            Console.WriteLine("Do you want to go back to the main menu? (Y/N)");
            string response = Console.ReadLine().Trim().ToLower();


            if (response == "y")
            {
                break;
            }
            else if (response == "n")
            {
                Console.WriteLine("Continuing process...");
                Process_4();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'Y' to return or 'N' to continue.");
            }
        }
    }
}
