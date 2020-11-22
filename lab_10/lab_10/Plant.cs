using System;

namespace lab_10
{
    public class Plant
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Plant(string name, string type)
        {
            Name = name;
            Type = type;
        }
        
        public void ShowСapabilities()
        {
            Console.WriteLine($"I am {Name}");
        }

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(Plant obj)
        {
            return Name == obj.Name && Type == obj.Type;
        }
    }
}