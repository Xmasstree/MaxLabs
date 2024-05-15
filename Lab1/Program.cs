using System.Security;
using System.Text;

namespace Lab1
{
    public class Tree_node
    {
        public Tree_node(char data)
        {
            this.data = data;
        }
        public char data { get; set; }
        public Tree_node Left { get; set; }
        public Tree_node Right { get; set; }

        public void Insert(Tree_node node)
        {
            if (node.data < data)
            {
                if (Left == null)
                    Left = node;
                else
                    Left.Insert(node);
            }
            else
            {
                if (Right == null)
                    Right = node;
                else
                    Right.Insert(node);
            }
        }

        public char[] Tochar(List<char> list = null)
        {
            if (list == null)
                list = new List<char>();
            if (Left != null)
                Left.Tochar(list);

            list.Add(data);

            if (Right != null)
                Right.Tochar(list);
            return list.ToArray();
        }
    }
    internal class Program
    {
        
        static void glas(string output)
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

        static char[] QuickSort(char[] str, int minID, int maxID)
        { 
            if  (minID >= maxID)
                return str;
            int pivotID = GetPivot(str, minID, maxID);
            QuickSort(str, minID, pivotID-1);
            QuickSort(str, pivotID+1, maxID);
            return str; 
        }

        static int GetPivot(char[] str, int minID, int maxID) 
        {
            int pivot = minID - 1;
            for (int i = minID; i <= maxID; i++)
            {
                if (str[i] < str[maxID])
                {
                    pivot++;
                    Swap(ref str[pivot],ref  str[i]);
                }
            }

            pivot++;
            Swap(ref str[pivot], ref str[maxID]);

            return pivot;
        }

        static void Swap(ref char left,ref  char right) 
        {
            char temp = left;

            left = right;

            right = temp;
        }

        static char[] TreeSort(char[] str)
        {

            var tree = new Tree_node(str[0]);
            for (int i = 1; i < str.Length; i++)
                tree.Insert(new Tree_node(str[i]));

            return tree.Tochar();
        }

        static void Main(string[] args)
        {
            //lab1 Smolnikov
            string a = Console.ReadLine();
            char[] str = new char[a.Length];
            for (int i = 0; i < a.Length; i++)
                str[i] = a[i];
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
                    
                }
            }
            else 
            {
                Console.WriteLine($"Ошибка, использованы не подходящие символы: {exept}");
                Console.ReadLine();
            }
        
            
            Console.Write("Введите\n" +
                "1.Если хотите отсортировать строку методом QuickSort\n" +
                "2.Если хотите отсортировать строку методом TreeSort\n" +
                "Ввод:");
            string sw = Console.ReadLine();
            switch(sw)
            {
                case "1":
                    Console.WriteLine(QuickSort(str, 0, str.Length - 1));
                    break;
                case "2":
                    Console.WriteLine(TreeSort(str));
                    break;

            }
            

             
            Console.ReadLine() ;
        }
    }
}
