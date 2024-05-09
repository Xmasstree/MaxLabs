namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            if (a.Length % 2 == 0)
            {
                string b = a.Substring(0, a.Length / 2);
                char[] bc = b.ToCharArray();
                Array.Reverse(bc);
                a = a.Substring(a.Length / 2);
                char[] ac = a.ToCharArray();
                Array.Reverse(ac);
                Console.WriteLine(String.Concat<char>(bc) + String.Concat<char>(ac));
                Console.ReadLine();
            }
            else
            {
                char[] b = a.ToCharArray();
                Array.Reverse(b);
                Console.WriteLine(String.Concat<char>(b) + a);
                Console.ReadLine();
            }
        }
    }
}
