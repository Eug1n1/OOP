using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace lab_12
{
    public class MagicClass
    {
        private int magicBaseValue;

        public MagicClass()
        {
            magicBaseValue = 9;
        }

        public int ItsMagic(Int64 preMagic)
        {
            return (int) (preMagic * magicBaseValue);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            
            /*int a = 100;
            string output = JsonConvert.SerializeObject(a);
            using (var sw = new StreamWriter("/home/eug1n1/Downloads/params.json"))
            {
                sw.Write(output);
            }

            Console.WriteLine(Reflector.Invoke(typeof(MagicClass), "ItsMagic", "/home/eug1n1/Downloads/params.json"));*/

            var a = Reflector.Create(typeof(List<int>), Type.EmptyTypes) as List<int>;
            a.Add(5);
            a.Add(4);
            a.Add(1);
            a.Add(7);
            foreach (var e in a)
            {
                Console.WriteLine(e);
            }
        }
        
    }
}