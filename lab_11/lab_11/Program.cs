using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace lab_11
{
    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            #region 1
            
            var strArr = new string[12] { "January", "February", "March", "April", "May", "June", "July", 
                                            "August", "September", "October", "November", "December" };
            
            
            var n = 4;
            var list1 = strArr.Where(x => x.Length == n).OrderBy(x => x);

            foreach (var e in list1)
            {
                Console.Write($"{e} ");
            }

            Console.WriteLine();
            
            var list2 = strArr.OrderBy(x => x);
            foreach (var e in list2)
            {
                Console.Write($"{e} ");
            }

            Console.WriteLine();
            
            var list3 = strArr.Where(x => x == "January" || 
                                          x == "February" || x == "December" || x == "June" || x == "July" || x == "August")
                                        .OrderBy(x => x);

            foreach (var e in list3)
            {
                Console.Write($"{e} ");
            }

            Console.WriteLine();

            var list4 = strArr.Where(x => x.Contains('u') && x.Length >= 4);

            foreach (var e in list4)
            {
                Console.Write($"{e} ");
            }

            Console.WriteLine();
            
            #endregion
            
            var myList = new List<Book>();
            myList.Add(new Book( "Ajskdvbfkj", 2010, 266, 10));
            myList.Add(new Book( "Qafasf", 2007, 190, 21));
            myList.Add(new Book( "Qafasf", 2020, 190, 21));
            myList.Add(new Book( "Wsdbgds", 2001, 1231, 23));
            myList.Add(new Book( "Wsdbgds", 2013, 1231, 23));
            myList.Add(new Book( "Ajskdvbfkj", 2005, 345, 43));
            myList.Add(new Book( "Rdbdbdf", 2016, 567, 12));
            myList.Add(new Book( "Rdbdbdf", 2018, 567, 12));
            myList.Add(new Book( "Csdgfsdvg", 2015, 123, 54));
            myList.Add(new Book( "Csdgfsdvg", 2012, 123, 54));
            myList.Add(new Book( "Ajskdvbfkj", 2013, 568, 12));

            Console.WriteLine("--------------------------------------------------------");

            var list = myList.Where(x => x.Author == "Ajskdvbfkj" && x.Year == 2010);
            
            foreach (var a in list)
            {
                Console.Write($"{a.Author} {a.Year}  |||  ");
            }

            Console.WriteLine();
            
            
            var list7 = myList.Where(x => x.Year >= 2005).OrderBy(x => x.Author);

            foreach (var e in list7)
            {
                Console.Write($"{e.Author} {e.Year}  |||  ");
            }

            Console.WriteLine();

            var list8 = myList.Min(x => x.Length);

            Console.WriteLine(list8);

            var list9 = myList.Where(x => x.Cost < 25).OrderByDescending(x => x.Length).Take(5);

            foreach (var a in list9)
            {
                Console.Write($"{a.Length} ");
            }

            Console.WriteLine();

            var list10 = myList.OrderBy(x => x.Cost);

            foreach (var a in list10)
            {
                Console.Write($"{a.Cost} ");
            }

            Console.WriteLine();

            var list11 = myList.GroupBy(p => p.Author)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                .Where(x => x.Count < 3)
                .OrderBy(x => x.Name)
                .Take(3)
                .Average(x => x.Count);
            
            Console.WriteLine(list11);
            
            
            List<Team> teams = new List<Team>()
            {
                new Team { Name = "Бавария", Country ="Германия" },
                new Team { Name = "Барселона", Country ="Испания" }
            };
            List<Player> players = new List<Player>()
            {
                new Player {Name="Месси", Team="Барселона"},
                new Player {Name="Неймар", Team="Барселона"},
                new Player {Name="Роббен", Team="Бавария"}
            };
 
            var result = from pl in players
                                                join t in teams on pl.Team equals t.Name
                                                select new { Name = pl.Name, Team = pl.Team, Country = t.Country };
 
            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");
        }
    }
}