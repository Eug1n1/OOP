using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace lab_5
{
    class Program
    {
        static int ExceptionGenerator(int a, int v)
        {
            return a / v;
        }


        static void Main(string[] args)
        {
            try
            {
                var harbor = new Harbor();
                var harborController = new Controller(harbor);

                CommonInfo ci = new CommonInfo();
                ci.Displacement = 10;
                ci.Places = 120;
                ci.Title = "steamboatEpta";
                ci.CaptainAge = 34;
                ci.Type = ShipType.Boat;
                ci.CaptainName = "Captain Jack Sparrow";


                harborController.Add(ci);

                CommonInfo ci2 = new CommonInfo();
                ci2.Displacement = 40;
                ci2.Places = 1000;
                ci2.Title = "Epta";
                ci2.CaptainAge = 50;
                ci2.Type = ShipType.Steamboat;
                ci2.CaptainName = "Captain Unjack Unsparrow";

                harborController.Add(ci2);
                Debug.WriteLine("poka vse OK!");
                /*harborController.SaveToTxt("/home/eug1n1/Downloads/harbor.txt");
                harborController.LoadFromTxt("/home/eug1n1/Downloads/harbor.txt");*/
                /*harborController.SaveToJson("/home/eug1n1/Downloads/harbor.json");
                harborController.LoadFromJson("/home/eug1n1/Downloads/harbor.json");*/

                /*CommonInfo ci3 = new CommonInfo();
                ci3.Displacement = 40;
                ci3.Places = 1000;
                ci3.Title = "Epta";
                ci3.CaptainAge = 10;
                ci3.Type = ShipType.Steamboat;
                ci3.CaptainName = "Captain Unjack Unsparrow";

                var a = 10;
                var b = 0;
                ExceptionGenerator(a, b);

                harborController.SaveToTxt("/home/eug1n1/Downloads/");
                harborController.LoadFromTxt("/home/eug1n1/Downloads/harbor.txt");

                harborController.ChangeHarbor(null);

                harborController.Delete(50);*/



                Debug.Assert(false, "hernya", "ne hernya");
            }
            catch (HarborNullException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.HelpLink);
            }
            catch (PathException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.HelpLink);
            }
            catch (CaptainAgeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.HelpLink);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.HelpLink);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.HelpLink);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.HelpLink);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.HelpLink);
            }
            finally
            {
                Console.WriteLine("finally");
            }
        }
    }
}