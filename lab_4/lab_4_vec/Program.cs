using System;
using lab_5;

namespace lab_4_vec
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MyVector<int> a = new MyVector<int>();
                a.Items.Add(12);
                a.Items.Add(13);
                a.Items.Add(14);
                a.Items.Add(15);
                a.Items.Add(16);

                Console.WriteLine(a.Owner.Name);

                MyVector<int> b = new MyVector<int>();
                b.Items.Add(6);
                b.Items.Add(-73);
                b.Items.Add(84);
                b.Items.Add(95);
                b.Items.Add(-16);

                a.Items[1] = 0;

                a = a + b;

                Console.WriteLine(a.ToString());
                a = a.Abs();
                Console.WriteLine(a.ToString());
                
                MyVector<Ship> ships = new MyVector<Ship>();
                CommonInfo ci = new CommonInfo();
                ci.Title = "adsd";
                ci.Places = 199;
                ci.Type = ShipType.Steamboat;
                ci.Displacement = 160;
                ci.CaptainAge = 1659;
                ci.CaptainName = "sdgfdsfdsfsdf";
                ships.Items.Add(new Steamboat(ci));
                
                ci.Title = "yuiyuiyui";
                ci.Places = 54673;
                ci.Type = ShipType.Steamboat;
                ci.Displacement = 123;
                ci.CaptainAge = 343215;
                ci.CaptainName = "vbnvbnvbnbvnvbnbvn";
                ships.Items.Add(new Steamboat(ci));
                

                Console.WriteLine(ships.ToString());
                
                ships.SaveToJson("/home/eug1n1/Downloads/ships.json");
                ships.LoadFromJson("/home/eug1n1/Downloads/ships.json");
                
                Console.WriteLine(ships.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Ай всё я спать!");
            }
        }
    }
}