using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading.Channels;

namespace lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1

                #region примитивные типы
            
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
                    
                    Console.WriteLine($"booltest: {booltest}\nbytetest: {bytetest}\nsbytetest: {sbytetest}\nchartest: {chartest}\n" +
                                      $"decimaltest: {decimaltest}\ndouble: {doubletest}\nfloattest: {floattest}\ninttest: {inttest}\n" +
                                      $"uinttest: {uinttest}\nlongtest: {longtest}\nulongtest: {ulongtest}\nshorttest: {shorttest}\nushort: {ushorttest}");
                
                #endregion

                #region явное преобразование

                    int a = 255;
                    
                    byte b = (byte) a;
                    int c = (int) b;
                    long d = (long) a;

                    long e = 255;

                    byte f = (byte) e;
                    int g = (int) e;

                #endregion

                #region неявное приведение

                    byte aa = 255;

                    long ab = aa;
                    int ac = aa;
                    short ad = aa;
                    double af = aa;
                    ushort ag = aa;

                #endregion

                #region Convert

                    string aaa = "255";

                    byte aab = Convert.ToByte(aaa);
                    int aac = Convert.ToInt16(aaa);
                    double aad = Convert.ToDouble(aaa);

                #endregion

                #region упаковка и распаковка

                    int x = 255;
                    Object obj = x;
                    x = (int)obj;

                    long y = 5786;
                    Object obje = y;
                    y = (long) obje;

                    short z = 877;
                    Object objec = z;
                    z = (short)objec;

                #endregion

                #region Неявно типизированные локальные переменные

                    var intovaya = 567;
                    var color = Color.Aqua;
                    var client = new WebClient();
                    var str = "строка";
                    var list = new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                #endregion

                #region null

                    int? nullable = null;
                    
                    if(nullable.HasValue)
                        Console.WriteLine(nullable.Value);
                    
                    int? _nullable = 76;
                    
                    if(_nullable.HasValue)
                        Console.WriteLine(_nullable.Value);

                #endregion

                #region var

                    var stroka = "something";
                    /*
                    stroka = 123;
                    */

                #endregion

            #endregion

            #region 2

                #region Объявите строковые литералы. Сравните их

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

                #endregion

                #region сцепление, копирование, выделение подстроки и тд

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
                
                #endregion

                #region Продемонстрируйте интерполирование строк

                Console.WriteLine($"str4: {str4}\nstr3: {str3}");

                #endregion

                #region Создайте пустую и null строку

                string str6 = null;

                if (string.IsNullOrEmpty(str6))
                {
                    Console.WriteLine("is null");
                }
                else
                {
                    Console.WriteLine("is not null");
                }

                #endregion

                #region stringBuilder

                StringBuilder stringBuilder = new StringBuilder("chtoto strokovoe");

                stringBuilder.Remove(4, 2);
                stringBuilder.Insert(0, " str ");
                stringBuilder.Append(" ne str ");

                Console.WriteLine(str6);

                #endregion



            #endregion

        }
    }
}
