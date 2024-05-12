using System.Security;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void glas(string output)
            {
                int flag = 0;
                int id1 = 0;
                int id2 = 0;

                for (int i = 0; i < output.Length; i++)
                {
                    if ("aeiouy".Contains(output[i]) && flag == 0)
                    {
                        flag = 1;
                        id1 = i;
                    }
                    else if ("aeiouy".Contains(output[i]))
                    {
                        flag = 2;
                        id2 = i;
                    }

                }
                if (flag == 2)
                    Console.WriteLine(output.Substring(id1, ++id2));
            }

            //lab1 Smolnikov
            string a = Console.ReadLine();
            string exept ="";
            //была ошибка в ограничении for
            for (int i = 0; i < a.Length; i++) 
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
                    string output = String.Concat<char>(bc) + String.Concat<char>(ac);
                    Console.WriteLine(output);

                    
                    foreach (var let in letters)
                        Console.WriteLine($"[{let.Key}] - {let.Value}");
                    glas(output);


                    Console.ReadLine();
                }
                else
                {
                    char[] b = a.ToCharArray();
                    Array.Reverse(b);
                    string output = String.Concat<char>(b) + a;
                    Console.WriteLine(output);
                    
                    foreach (var let in letters)
                        Console.WriteLine($"[{let.Key}] - {let.Value*2}");
                    glas(output);
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
