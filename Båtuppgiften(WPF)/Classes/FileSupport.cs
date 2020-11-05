using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Båtuppgiften_WPF_.Classes
{
    class FileSupport
    {
        public static void ImportBoatsFromFile()
        {
            if (File.Exists("boats.txt"))
            {
                string text = File.ReadAllText("boats.txt");

                string[] dataLines = text.Split('\n');

                foreach (string data in dataLines)
                {
                    string[] keyValue = data.Split('=');

                    try
                    {
                        if (keyValue[0].FirstOrDefault() == 'R')
                        {
                            Harbour.RegisterImportedBoats(new Rowboat(keyValue[0], int.Parse(keyValue[1]), decimal.Parse(keyValue[2]), int.Parse(keyValue[3]), int.Parse(keyValue[4]), int.Parse(keyValue[5])));
                        }
                        else if (keyValue[0].FirstOrDefault() == 'M')
                        {
                            Harbour.RegisterImportedBoats(new Motorboat(keyValue[0], int.Parse(keyValue[1]), decimal.Parse(keyValue[2]), int.Parse(keyValue[3]), int.Parse(keyValue[4]), int.Parse(keyValue[5])));
                        }
                        else if (keyValue[0].FirstOrDefault() == 'S')
                        {
                            Harbour.RegisterImportedBoats(new Sailingboat(keyValue[0], int.Parse(keyValue[1]), decimal.Parse(keyValue[2]), int.Parse(keyValue[3]), int.Parse(keyValue[4]), int.Parse(keyValue[5])));
                        }
                        else if (keyValue[0].FirstOrDefault() == 'L')
                        {
                            Harbour.RegisterImportedBoats(new CargoVessel(keyValue[0], int.Parse(keyValue[1]), decimal.Parse(keyValue[2]), int.Parse(keyValue[3]), int.Parse(keyValue[4]), int.Parse(keyValue[5])));
                        }
                        else if (keyValue[0].FirstOrDefault() == 'K')
                        {
                            Harbour.RegisterImportedBoats(new Catamaran(keyValue[0], int.Parse(keyValue[1]), decimal.Parse(keyValue[2]), int.Parse(keyValue[3]), int.Parse(keyValue[4]), int.Parse(keyValue[5])));
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Båt gick inte att lägga till i listan. {e}");
                    }

                }
            }
        }

        public static void ExportBoatsToFile()
        {
            using (StreamWriter sw = new StreamWriter("boats.txt", true))
            {
                foreach (Boat boat in Harbour.BoatsInHarbour)
                {
                    sw.Write($"{boat.IdentityNumber}={boat.Weight}={boat.MaxSpeed}={boat.MooredAtNr}={boat.Landing}=");

                    if (boat is Rowboat)
                    {
                        sw.WriteLine($"{((Rowboat)boat).MaxAmountOfPassengers}");
                    }
                    else if (boat is Motorboat)
                    {
                        sw.WriteLine($"{((Motorboat)boat).Horsepower}");
                    }
                    else if (boat is Sailingboat)
                    {
                        sw.WriteLine($"{((Sailingboat)boat).Length}");
                    }
                    else if (boat is CargoVessel)
                    {
                        sw.WriteLine($"{((CargoVessel)boat).Containers}");
                    }
                    else if (boat is Catamaran)
                    {
                        sw.WriteLine($"{((Catamaran)boat).Beds}");
                    }

                }
            }
        }
    }
}
