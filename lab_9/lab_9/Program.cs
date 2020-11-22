using System;

namespace lab_9
{

    class Program
    {
        static void Main(string[] args)
        {
            /*var user1 = new User();

            user1.MoveComplete += () =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nMove Completed!!!!");
                Console.ResetColor();
            };

            user1.CompressComplete += () =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nCompress Completed!!!!");
                Console.ResetColor();
            };

            user1.Move();
            user1.Compress();*/


            Func<string, string> str = handle;

            Console.WriteLine(str("ivhssdvno,,,,,,"));

        }

        static string handle(string source)
        {
            return Replace(Insert(Remove(Add(ToCamelCase(source)))));
        }
        
        public static string ToCamelCase(string input)
        {
            var output = input.ToLower().ToCharArray();

            var up = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (up)
                {
                    output[i] = Char.ToUpper(output[i]);
                }
                up = !up;
            }

            var str = "";
            foreach (var ch in output)
            {
                str += ch;
            }
            
            return str;
        }
        public static string Replace(string input)
        {
            return input.Replace(",", "'");
        }
        public static string Remove(string input)
        {
            return input.Remove(0, 3);
        }
        
        public static string Insert(string input)
        {
            return input.Insert(0, "1234567890");
        }
        public static string Add(string input)
        {
            return input.Insert(input.Length, "1234567890");
        }
    }
}