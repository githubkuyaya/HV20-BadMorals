using System;
using System.Security.Cryptography;

namespace BadMorals
{
    public class Program
    {
        static string checker;
        static string firstresult;
        static string secondresult;
        static string thirdresult;
        public static void Main(string[] args)
        {

            try
            {
                // <-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0->
                Console.Write("Your first input: ");
                char[] a = Console.ReadLine().ToCharArray();
                checker = "";
                firstresult = "";
                for (int i = 0; i < a.Length; i++)
                {
                    if (i % 2 == 0 && i + 2 <= a.Length)
                    {
                        checker += a[i + 1];
                    }
                }

                if (checker == "BumBumWithTheTumTum")
                {
                    firstresult = "SFYyMH" + a[17] + "yM3YzcnMzXzN" + a[3] + "ZzF" + a[9] + "MzNyM" + a[13] + "5nX2";
                }
                else if (checker == "")
                {
                    Console.WriteLine("Your input is not allowed to result in an empty string");
                    return;
                }
                else
                {
                    firstresult = checker;
                }

                // <-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0->
                Console.Write("Your second input: ");
                char[] b = Console.ReadLine().ToCharArray();
                checker = "";
                secondresult = "";
                Array.Reverse(b);
                for (int u = 0; u < b.Length; u++)
                {
                    checker += b[u];
                }

                if (checker == "BackAndForth")
                {
                    secondresult = "Q1RGX3" + b[11] + "sNH" + b[8] + "xbm" + b[5] + "f";
                }
                else if (checker == "")
                {
                    Console.WriteLine("Your input is not allowed to result in an empty string");
                    return;
                }
                else
                {
                    secondresult = checker;
                }

                // <-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0->
                Console.Write("Your third input: ");
                char[] c = Console.ReadLine().ToCharArray();
                checker = "";
                thirdresult = "";
                byte q = 42;
                for (int z = 0; z < c.Length; z++)
                {
                    char newchar = (char)(c[z] ^ q);
                    checker += newchar;
                }

                if (checker == "DinosAreLit")
                {
                    thirdresult = "00Z" + c[2] + "N" + c[8] + "MzRze" + c[6] + "0=";
                }
                else if (checker == "")
                {
                    Console.WriteLine("Your input is not allowed to result in an empty string");
                    return;
                }
                else
                {
                    thirdresult = checker;
                }

                string final = firstresult + thirdresult;
                byte[] bit = Convert.FromBase64String(final);
                byte[] verifier = Convert.FromBase64String(secondresult);

                byte[] check = new byte[bit.Length];
                for (int i = 0; i < bit.Length; i++)
                {
                    check[i] = (byte) (bit[i] ^ verifier[i % verifier.Length]);
                }
                
                var digest = SHA1.Create().ComputeHash(check);
                byte[] expected = new byte[] { 66, 106, 120, 231, 140, 169, 167, 205, 221, 153, 71, 118, 87, 167, 96, 161, 90, 211, 208, 244 };
                for (var i = 0; i < digest.Length; i++)
                {
                    if (digest[i] != expected[i])
                    {
                        Console.WriteLine("Your inputs do not result in the flag.");
                        return;
                    }
                }

                string flag = System.Text.Encoding.ASCII.GetString(bit);
                if (flag.StartsWith("HV20{"))
                {
                    Console.WriteLine("Congratulations! You're now worthy to claim your flag: {0}", flag);
                }
            }
            catch
            {
                Console.WriteLine("Please try again.");
            }
            finally
            {
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }
        }
    }
}
