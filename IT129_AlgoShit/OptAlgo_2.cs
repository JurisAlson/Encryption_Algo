using System;
using System.Collections.Generic;
using System.Linq;

class Algo2
{
    private string input;
    private Dictionary<char, char> encryptionKey;

    public Algo2(string userInput)
    {
        input = userInput;
        encryptionKey = InitializeKey();
    }

    public void Process_2()
    {
        while (true)
        {

            Console.WriteLine("Do you want to Encrypt or Decrypt the text? (E/D)");
            string choice = Console.ReadLine().Trim().ToLower();

            if (choice == "e")
            {
                Console.WriteLine("Encrypted: " + Encrypt(input));
            }
            else if (choice == "d")
            {
                Console.WriteLine("Decrypted: " + Decrypt(input));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice. Please enter 'E' for Encrypt or 'D' for Decrypt.");
                Console.ResetColor();
                continue;
            }

            while (true)
            {
                Console.WriteLine("Do you want to go back to the main menu? (Y/N)");
                string response = Console.ReadLine().Trim().ToLower();

                if (response == "y")
                    return;
                else if (response == "n")
                {
                    Console.WriteLine("Enter a new message to process:");
                    input = Console.ReadLine();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid input. Please enter 'Y' to return or 'N' to continue.");
                    Console.ResetColor();
                }
            }
        }
    }

    private string Encrypt(string plaintext)
    {
        return ProcessText(plaintext, encryptionKey);
    }

    private string Decrypt(string ciphertext)
    {
        Dictionary<char, char> decryptionKey = encryptionKey.ToDictionary(pair => pair.Value, pair => pair.Key);
        return ProcessText(ciphertext, decryptionKey);
    }

    private string ProcessText(string input, Dictionary<char, char> key)
    {
        string result = "";
        foreach (char c in input)
        {
            char lowerC = char.ToLower(c);
            if (key.ContainsKey(lowerC))
            {
                result += char.IsUpper(c) ? char.ToUpper(key[lowerC]) : key[lowerC];
            }
            else
            {
                result += c;
            }
        }
        return result;
    }

    private Dictionary<char, char> InitializeKey()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=======================================");
        Console.WriteLine("         CIPHER                        ");
        Console.WriteLine("=======================================\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Kama Sutra Cipher, also known as Vatsyayana cipher, is a simple substitution cipher where the 26 letters of the alphabet " +
               "are organized in 13 pairs. Users can customize these pairs as needed. The default key value pairs are: In this Cipher, the arrangements for the 13 pairs are: " +
               "A=Z, B=Y, C=X, D=W, E=V, F=U, G=T, H=S, I=R, J=Q, K=P, L=O, M=N");  
        Console.WriteLine("=======================================");
        Console.ResetColor();

        Console.WriteLine("\nDo you want to customize the key-value pairs? (Y/N)");
        string response = Console.ReadLine().Trim().ToLower();

        if (response == "y")
            return GetUserDefinedKey();

        return GetDefaultKey();
    }

    private Dictionary<char, char> GetDefaultKey()
    {
        return new Dictionary<char, char>
        {
            {'a', 'z'}, {'b', 'y'}, {'c', 'x'}, {'d', 'w'}, {'e', 'v'}, {'f', 'u'},
            {'g', 't'}, {'h', 's'}, {'i', 'r'}, {'j', 'q'}, {'k', 'p'}, {'l', 'o'},
            {'m', 'n'}, {'n', 'm'}, {'o', 'l'}, {'p', 'k'}, {'q', 'j'}, {'r', 'i'},
            {'s', 'h'}, {'t', 'g'}, {'u', 'f'}, {'v', 'e'}, {'w', 'd'}, {'x', 'c'},
            {'y', 'b'}, {'z', 'a'}
        };
    }

    private Dictionary<char, char> GetUserDefinedKey()
    {
        Dictionary<char, char> customKey = GetDefaultKey();
        HashSet<char> usedChars = new HashSet<char>();

        Console.WriteLine("Enter letter pairs (e.g., a -> z). Type 'done' to finish:");
        while (true)
        {
            Console.Write("Enter first letter: ");
            string input1 = Console.ReadLine().ToLower();
            if (input1 == "done") break;

            Console.Write("Enter second letter: ");
            string input2 = Console.ReadLine().ToLower();
            if (input2 == "done") break;

            if (input1.Length == 1 && input2.Length == 1 && char.IsLetter(input1[0]) && char.IsLetter(input2[0]))
            {
                char char1 = input1[0];
                char char2 = input2[0];

                if (!usedChars.Contains(char1) && !usedChars.Contains(char2))
                {
                    customKey[char1] = char2;
                    customKey[char2] = char1;
                    usedChars.Add(char1);
                    usedChars.Add(char2);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("One or both letters have already been used. Try again.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid input. Enter single letters only.");
                Console.ResetColor();
            }
        }
        return customKey;
    }
}
