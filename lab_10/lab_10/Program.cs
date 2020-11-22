using System;
// ReSharper disable once RedundantUsingDirective
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace lab_10
{
    class Program
    {
        static void Main()
        {
            /*var m = new MyList<Plant>();*/

            var grut = new Plant("Grut", "dsvsd");
            
            /*m.Add(grut);
            m.Add(new Plant("Albert", "ghj"));
            m.Add(new Plant("Oleksandr", "dfg"));
            m.Add(new Plant("Timofey", "dsvsd"));
            m.Add(new Plant("Genadiy", "wer"));

            Console.WriteLine(m.Contains(grut));
            
            m.Insert(2, grut);

            m.Remove(grut);

            Console.WriteLine(m.IndexOf(grut));
            
            foreach (var l in m)
            {
                Console.WriteLine(l.ToString());
            }*/
            
            /*var hashset = new HashSet<Plant>();
            hashset.Add(grut);
            hashset.Add(new Plant("Albert", "ghj"));
            hashset.Add(new Plant("Oleksandr", "dfg"));
            hashset.Add(new Plant("Timofey", "dsvsd"));
            hashset.Add(new Plant("Genadiy", "wer"));

            Console.WriteLine(hashset.Contains(grut));

            foreach (var el in hashset)
            {
                Console.WriteLine(el.ToString());
            }
            
            foreach (var el in hashset)
            {
                if (el == grut)
                {
                    Console.WriteLine("found!");
                }
            }*/
            
            
            var obs = new ObservableCollection<Plant>();

            obs.CollectionChanged += On_CollectionChanged;
            
            obs.Add(grut);
            obs.Add(new Plant("Albert", "ghj"));
            obs.Add(new Plant("Oleksandr", "dfg"));
            obs.Add(new Plant("Timofey", "dsvsd"));
            obs.Add(new Plant("Genadiy", "wer"));
            
            obs.Insert(3, grut);

            obs.Remove(grut);

            obs[0] = grut;
        }

        private static void On_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    var newPlant = e.NewItems[0] as Plant;
                    Console.WriteLine($"Добавлен новый объект: {newPlant?.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    // ReSharper disable once SuspiciousTypeConversion.Global
                    var oldPlant = e.OldItems[0] as Plant;
                    Console.WriteLine($"Удален объект: {oldPlant?.Name}");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    var replacedPlant = e.OldItems[0] as Plant;
                    var replacingPlant = e.NewItems[0] as Plant;
                    Console.WriteLine($"Объект {replacedPlant?.Name} заменен объектом {replacingPlant?.Name}");
                    break;
            }
        }
    }
}