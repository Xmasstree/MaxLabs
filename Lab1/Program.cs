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
                
                var letters = new Dictionary<char, int>();
                foreach (char c in a)
                {
                    if(letters.ContainsKey(c))
                        letters[c] = ++letters[c];
                    else
                        letters.Add(c, 1);
                }
                
                if (a.Length % 2 == 0)
                {
                    string b = a.Substring(0, a.Length / 2);
                    char[] bc = b.ToCharArray();
                    Array.Reverse(bc);
                    a = a.Substring(a.Length / 2);
                    char[] ac = a.ToCharArray();
                    Array.Reverse(ac);
                    Console.WriteLine(String.Concat<char>(bc) + String.Concat<char>(ac));
                    foreach (var let in letters)
                        Console.WriteLine($"[{let.Key}] - {let.Value}");
                    Console.ReadLine();
                }
                else
                {
                    char[] b = a.ToCharArray();
                    Array.Reverse(b);
                    Console.WriteLine(String.Concat<char>(b) + a);
                    foreach (var let in letters)
                        Console.WriteLine($"[{let.Key}] - {let.Value*2}");
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
