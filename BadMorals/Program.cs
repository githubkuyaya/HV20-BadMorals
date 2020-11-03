using System;


namespace BadMorals
{
    public class Program
    {
        static string s1 = "SFYyMHtyM3YzcnMzXzNuZzFuMzNyMW5nX2";
        static string s2 = "Q1RGX3BsNHkxbmdf";
        static string s3 = "00ZDNfMzRzeX0=";
        static byte[] b = Convert.FromBase64String(s1 + s3);
        public static void Main(string[] args)
        {
            string TurnBack = "You're not ready yet...";
            Console.WriteLine(TurnBack);
        }
        public static string secret()
        {
            string flag = System.Text.Encoding.UTF8.GetString(b);
            Console.Write("Ho ho ho, it seems you have solved the riddle and are now ready for your Christmas gift: ");
            return flag;
        }
    }
}
