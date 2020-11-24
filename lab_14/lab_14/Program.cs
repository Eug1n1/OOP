using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using lab_13;

namespace lab_14
{
    class Program
    {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            var log = new LogEntry("gjbsdkjb", "name");
            var path = "/home/eug1n1/log.dat";
            LabMethods.BinarySerializer(path, log);
            
            path = "/home/eug1n1/log.json";
            LabMethods.JsonSerializer(path, log);
            
            path = "/home/eug1n1/log.xml";
            LabMethods.XmlSerializer(path, log);

            var log11 = LabMethods.BinaryDeserializer("/home/eug1n1/log.dat");
            var log22 = LabMethods.JsonDeserializer("/home/eug1n1/log.json");
            var log33 = LabMethods.XmlDeserializer("/home/eug1n1/log.xml");

            Console.WriteLine(log11);
            Console.WriteLine(log22);
            Console.WriteLine(log33);

            var list = new List<LogEntry>();
            list.Add(new LogEntry("sadfsfdsf", "name"));
            list.Add(new LogEntry("eqwe", "name"));
            list.Add(new LogEntry("bcv", "name"));
            list.Add(new LogEntry("saddads", "name"));
            list.Add(new LogEntry("poip", "name"));
            list.Add(new LogEntry("werewr", "name"));

            LabMethods.EnumerableBinarySerialize("/home/eug1n1/logs.dat", list);
            LabMethods.EnumerableJsonSerialize("/home/eug1n1/logs.json", list);
            
            LabMethods.EnumerableXmlSerialize("/home/eug1n1/logs.xml", list.ToArray());
            

            
            var logs1 = LabMethods.EnumerableBinaryDeserializer("/home/eug1n1/logs.dat");
            var logs2 = LabMethods.EnumerableJsonDeserializer("/home/eug1n1/logs.json");
            var logs3 = LabMethods.EnumerableXmlDeserializer("/home/eug1n1/logs.xml");

            foreach (var el in logs1)
            {
                Console.WriteLine(el.Action);
            }
            
            foreach (var el in logs2)
            {
                Console.WriteLine(el.Action);
            }
            
            foreach (var el in logs3)
            {
                Console.WriteLine(el.Action);
            }

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("/home/eug1n1/logs.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlNodeList childnodes = xRoot.SelectNodes("//LogEntry/Action");
            foreach (XmlNode n in childnodes)
            {
                Console.WriteLine(n.InnerText);
            }
            
            XmlNodeList dateNodes = xRoot.SelectNodes("LogEntry");
            foreach (XmlNode node in dateNodes)
            {
                Console.WriteLine(node.SelectSingleNode("Date").InnerText);
            }
            
            XDocument xdoc = new XDocument();

            XElement log1 = new XElement("LogEntry");

            log1.Add(new XAttribute("name", "Ne name"));
            log1.Add(new XElement("Action", "Remove"));
            log1.Add(new XElement("Date", "12.12.2020"));
 

            XElement log2 = new XElement("LogEntry");
            log2.Add(new XAttribute("name", "Name"));
            log2.Add(new XElement("Action", "Copy"));
            log2.Add(new XElement("Date", "11.12.2020"));

            var arr = new XElement("Array");
            arr.Add(log1);
            arr.Add(log2);
            xdoc.Add(arr);
            
            xdoc.Save("/home/eug1n1/1.xml");
            
            XmlDocument doc = new XmlDocument();
            doc.Load("/home/eug1n1/1.xml");
            XmlElement root = doc.DocumentElement;

            XmlNodeList child = root.SelectNodes("//LogEntry/Action");
            foreach (XmlNode n in child)
            {
                Console.WriteLine(n.InnerText);
            }
            
            XmlNodeList child1 = root.SelectNodes("LogEntry");
            foreach (XmlNode n in child1)
            {
                Console.WriteLine(n.SelectSingleNode("@name").Value);
            }
            
            XmlNodeList date = root.SelectNodes("LogEntry");
            foreach (XmlNode node in date)
            {
                Console.WriteLine(node.SelectSingleNode("Date").InnerText);
            }
        }
    }
}