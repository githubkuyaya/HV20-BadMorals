using System;

namespace BadMorals
{
    public class Program
    {
        static string s1 = "2SXFnY5yWMMHytNyzMM3uYFzzcZnuMNzzXXzzNMunZczzFYu3MMzyNtyHMMWy5YnFXS2";
        static string s2 = "fdmbxkHNsB3XGR1Q";

        static char[] a = s1.ToCharArray();
        static char[] b = s2.ToCharArray();
        static char[] c;

        static string build;
        public static void Main(string[] args)
        {

            //section 0: Read user input and possibly return the flag. The user input is currently: ":"
            if (args.Length == 1)
            {
                build = args[0] + ":PNDlGpXpoR:7";
                c = build.ToCharArray();
            }
            else
            {
                Console.Write("Usage: HV20.exe ARG");
                Environment.Exit(1);
            }


            // Section 1: Get every second char of s1
            string firstresult = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (i % 2 == 0)
                {
                    firstresult += a[i+1];
                }
            }

            // Section 2: Reverse the string s2
            string secondresult = "";
            Array.Reverse(b);
            for (int u = 0; u < b.Length; u++)
            {
                secondresult += b[u];
            }

            // Section 3: XOR the userinput + string with a fixed byte
            string thirdresult = "";
            byte q = 10;
            for (int z = 0; z < c.Length; z++)
            {

                char newchar = (char)(c[z] ^ q);
                thirdresult += newchar;
            }

            // Final section: Convert the two strings from Base64 and print it out.
            try
            {
                string final = firstresult + thirdresult;
                byte[] bit = Convert.FromBase64String(final);
                string flag = System.Text.Encoding.ASCII.GetString(bit);
                Console.Write(flag);
            }
            catch
            {
                Console.Write("Your input does not result in a valid Base64 string.");
            }
        }
    }
}
