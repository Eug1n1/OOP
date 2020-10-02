using System;

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Channels;

namespace lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1

            bool booltest = true;
            byte bytetest = byte.MaxValue;
            sbyte sbytetest = sbyte.MaxValue;
            char chartest = 'f';
            decimal decimaltest = Decimal.MaxValue;
            double doubletest = Double.MaxValue;
            float floattest = float.MaxValue;
            int inttest = int.MaxValue;
            uint uinttest = uint.MaxValue;
            long longtest = long.MaxValue;
            ulong ulongtest = ulong.MaxValue;
            short shorttest = short.MaxValue;
            ushort ushorttest = ushort.MaxValue;
            
            
            Console.WriteLine(
                $"booltest: {booltest}\nbytetest: {bytetest}\nsbytetest: {sbytetest}\nchartest: {chartest}\n" +
                $"decimaltest: {decimaltest}\ndouble: {doubletest}\nfloattest: {floattest}\ninttest: {inttest}\n" +
                $"uinttest: {uinttest}\nlongtest: {longtest}\nulongtest: {ulongtest}\nshorttest: {shorttest}\nushort: {ushorttest}");

            int a = 255;

            byte b = (byte) a;
            int c = (int) b;
            long d = (long) a;

            long e = 255;

            byte f = (byte) e;
            int g = (int) e;
            

            byte aa = 255;

            long ab = aa;
            int ac = aa;
            short ad = aa;
            double af = aa;
            ushort ag = aa;
            

            string aaa = "255";

            byte aab = Convert.ToByte(aaa);
            int aac = Convert.ToInt16(aaa);
            double aad = Convert.ToDouble(aaa);
            

            int x = 255;
            Object obj = x;
            x = (int) obj;

            long y = 5786;
            Object obje = y;
            y = (long) obje;

            short z = 877;
            Object objec = z;
            z = (short) objec;
            

            var intovaya = 567;
            var color = Color.Aqua;
            var client = new WebClient();
            var str = "строка";
            var list = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9};
            

            int? nullable = null;

            if (nullable.HasValue)
                Console.WriteLine(nullable.Value);

            int? _nullable = 76;

            if (_nullable.HasValue)
                Console.WriteLine(_nullable.Value);
            

            var stroka = "something";
            
            /*
            stroka = 123;
            */


            #endregion

            #region 2

            string str1 = "hello";
            string str2 = "world";

            if (str1 == str2)
            {
                Console.WriteLine(str1 + str2);
            }
            else
            {
                Console.WriteLine(str2 + str1);
            }
            
            
            string str3 = "hello world";
            string str4 = "ello word";
            string str5;

            Console.WriteLine(str3 + str4);

            str5 = str3;

            Console.WriteLine(str4.Substring(0, 4));

            string[] words = str4.Split(' ');
            foreach (string s in words)
                Console.WriteLine(s);

            Console.WriteLine(str4.Insert(0, "h").Insert(9, "l"));

            Console.WriteLine(str4.Replace("word", "world"));

            Console.WriteLine(str4.Remove(0, 4));
            

            Console.WriteLine($"str4: {str4}\nstr3: {str3}");
            

            string str6 = "";

            if (string.IsNullOrEmpty(str6))
            {
                Console.WriteLine("is null");
            }
            else
            {
                Console.WriteLine("is not null");
            }
            

            StringBuilder stringBuilder = new StringBuilder("chtoto strokovoe");

            stringBuilder.Remove(4, 2);
            stringBuilder.Insert(0, " str ");
            stringBuilder.Append(" ne str ");

            Console.WriteLine(str6);
            

            #endregion
            
            #region 3

            var array = new int[,] {{11, 23, 45}, {4, 23, 76}, {12, 34, 98}};

            var rows = array.GetUpperBound(0) + 1;
            var columns = array.Length / rows;

 
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    Console.Write($"{array[i, j]} \t");
                }
                Console.WriteLine();
            }
            

            var stringArray = new string[]{"hello", "hi", "world", "net", "rider", "JetBrains"};

            Console.WriteLine($"array.length(): {stringArray.Length}");
            foreach (var str7 in stringArray)
            {
                Console.Write(str7 + "\t");
            }

            Console.WriteLine();

            Console.Write("Enter index to replace: ");
            var index = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter string: ");
            var strToReplace = Console.ReadLine();

            stringArray[index] = strToReplace;
            Console.WriteLine("new array:");
            foreach (var str7 in stringArray)
            {
                Console.Write(str7 + "\t");
            }

            var myArr = new double[3][];
            myArr[0] = new double[2];
            myArr[1] = new double[3];
            myArr[2] = new double[4];

            var length = myArr.Length;

            for (var i = 0; i < myArr.Length; i++)
            {
                for (var j = 0; j < myArr[i].Length; j++)
                {
                    myArr[i][j] = Double.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\nYour array:");
            for (var i = 0; i < myArr.Length; i++)
            {
                Console.WriteLine();
                for (var j = 0; j < myArr[i].Length; j++)
                {
                    Console.Write("{0}\t", myArr[i][j]);
                }

            }

            var stroka1 = "stroka";

            #endregion

            #region 4

            

            (int, string, char, string, ulong) obj5 = (5, "john", 'f', "johnson", 8765);
            var obj7 = new Tuple<int, string, char, string, ulong>(5, "john", 'f', "johnson", 8765);
            var tuple = Tuple.Create<int, string, short>(123, "123", 123);

            Console.WriteLine(obj5.ToString().Replace("(", "").Replace(")", ""));

            Console.WriteLine(obj5.Item1 + " " + obj5.Item5);

            var int1 = obj5.Item1;

            var (intTuple, strTuple, chTuple, _, ulongTuple) = obj7;
            
            _ = 10;
            
            // TODO: как сравнивать
            var left = (a: 6, b: 10);
            var right = (a: 5, b: 10);
            if (left == right)
            {
                 Console.WriteLine("Кортежи равны.");
            }
            else
            {
                Console.WriteLine("Кортежи неравны.");
            }
            
            #endregion

            #region 5

            Tuple<int, int, int, char> TestFunc(int[] arr,string funcString)
            {
                return new Tuple<int, int, int, char>(arr.Max(), arr.Min(), arr.Sum(), funcString[0]);
            }
            
            var intArr = new int[]{ 1, 2, 3, 4, 5, 6, 7 };
            var funcStr = "abcd";

            var testFuncTuple = Tuple.Create(TestFunc(intArr, funcStr));

            #endregion

            #region 6

            /*void checkedTest()
            {
                checked
                {
                    var left = int.MaxValue + 1;
                }
            }*/
            
            void uncheckedTest()
            {
                unchecked
                {
                    var left = int.MaxValue + 1;
                    Console.WriteLine(left);
                }
            }
            
            /*checkedTest();*/
            
            uncheckedTest();

            #endregion

        }
    }
}
