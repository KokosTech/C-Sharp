using System;

namespace HW24_10_21
{
    // Convert a number from any base to any base
    public class Base2Base
    {
        // Helper Funcs
        // CHAR to INT
        static int Val(char c)
        {
            if (c >= '0' && c <= '9')
                return (int)c - '0';
            else
                return (int)c - 'A' + 10;
        }

        // INT TO CHAR
        static char ReVal(int num)
        {
            if (num >= 0 && num <= 9)
                return (char)(num + 48);
            else
                return (char)(num - 10 + 65);
        }

        // Subbase Funcs
        // Any2Deci
        static int ToDeci(string str, int b_ase)
        {
            int len = str.Length;
            int power = 1;
            int num = 0;

            for (int i = len - 1; i >= 0; i--)
            {
                if (Val(str[i]) >= b_ase)
                {
                    Console.WriteLine("Invalid Number");
                    return -1;
                }

                num += Val(str[i]) * power;
                power *= b_ase;
            }

            return num;
        }

        // Deci2Any
        static string FromDeci(int num, int __base)
        {
            string s = "";

            while (num > 0)
            {
                s += ReVal(num % __base);
                num /= __base;
            }
            char[] res = s.ToCharArray();

            Array.Reverse(res);
            return new String(res);
        }

        // Base Func
        static string FromBaseToBase(string number, int base1, int base2)
        {
            int num = ToDeci(number, base1);
            return FromDeci(num, base2);
        }

        public static void MainB2B()
        {
            Console.WriteLine("Exercise 1:\n");
            Console.Write("Enter a number from any base: ");
            string num = Console.ReadLine();
            Console.Write("Enter the base of the input number: ");
            int base1 = int.Parse(Console.ReadLine());
            Console.Write("Enter the base of the output number: ");
            int base2 = int.Parse(Console.ReadLine());
            Console.WriteLine(num + "(" + base1 + ")" + " = " + FromBaseToBase(num, base1, base2) + "(" + base2 + ")");
        }
    }

    // Exercise 2 - If we could remove only 0 or 1 symbol from a string, would that make it a palindrome?
    public class PalindromeIf
    {
        static bool IsPalindrome(string str, int low, int high)
        {
            while (low < high)
            {
                if (str[low] != str[high])
                    return false;
                low++;
                high--;
            }
            return true;
        }

        static int PossiblePalinByRemovingOneChar(string str)
        {
            int low = 0, high = str.Length - 1;

            while (low < high)
            {
                if (str[low] == str[high])
                {
                    low++;
                    high--;
                }
                else
                {
                    if (IsPalindrome(str, low + 1, high))
                        return low;
                    if (IsPalindrome(str, low, high - 1))
                        return high;
                    return -1;
                }
            }
            return -2;
        }
        public static void MainPI()
        {
            Console.WriteLine("\nExercise 2:\n");
            Console.Write("Enter a string to check if it's a palindrome if an index is removed: ");
                string str = Console.ReadLine();

            int idx = PossiblePalinByRemovingOneChar(str);

            if (idx == -1)
                Console.Write("Not Possible");
            else if (idx == -2)
                Console.Write("Possible without removing any characters");
            else
                Console.Write("Possible by removing '" + str[idx] + "' character at index " + idx);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // EX1
            Base2Base.MainB2B();
            // EX2
            PalindromeIf.MainPI();
        }
    }
}

