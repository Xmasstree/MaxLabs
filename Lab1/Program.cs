namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //lab1 Smolnikov
            string a = Console.ReadLine();
            string exept ="";

            for (int i = 0; i < a.Length-1; i++) 
            {
                if (a[i] < 97 || a[i] > 122)
                    exept = exept + a[i];
            }
            if (String.IsNullOrEmpty(exept))
            {
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
            else 
            {
                Console.WriteLine($"Ошибка, использованы не подходящие символы: {exept}");
                Console.ReadLine();
            }
        }
    }
}
