using System;
using System.Collections.Generic;
using System.Text;

namespace Båtuppgiften_WPF_.Classes
{
    //Creates a random identitynumber for the boat. If the number already is in use by another boat in the harbour a new one will be created.
    class Randomizer
    {
        public static Random r = new Random();
        public static string RandomIdentityNumber()
        {
            int number1 = r.Next(1, 25 + 1);
            int number2 = r.Next(1, 25 + 1);
            int number3 = r.Next(1, 25 + 1);

            string iDNumber = char.ConvertFromUtf32((char)('a' + number1));
            iDNumber += char.ConvertFromUtf32((char)('a' + number2));
            iDNumber += char.ConvertFromUtf32((char)('a' + number3));

            return iDNumber.ToUpper();
        }
        public static string CreateIdentityNumber(string firstLetter)
        {
            string iDNumber = firstLetter;
            do
            {
                iDNumber += "-" + RandomIdentityNumber();

            } while (Exists(iDNumber));

            return iDNumber;
        }

        public static bool Exists(string s)
        {
            foreach (Boat boat in Harbour.BoatsInHarbour)
            {
                if (boat.IdentityNumber == s)
                {
                    return true;
                }

            }
            return false;
        }

        public static int CreateWeight(string s)
        {
            switch (s)
            {
                case "R":
                    return r.Next(100, 300 + 1);
                case "M":
                    return r.Next(200, 3000 + 1);
                case "S":
                    return r.Next(800, 6000 + 1);
                case "L":
                    return r.Next(3000, 20000 + 1);
                case "K":
                    return r.Next(1200, 8000 + 1);
                default:
                    return 0;
            }
        }

        public static decimal CreateMaxSpeed(string s)
        {
            switch (s)
            {
                case "R":
                    return r.Next(1, 3 + 1);
                case "M":
                    return r.Next(1, 60 + 1);
                case "S":
                    return r.Next(1, 12 + 1);
                case "L":
                    return r.Next(1, 20 + 1);
                case "K":
                    return r.Next(1, 12 + 1);
                default:
                    return 0;
            }
        }

        public static int CreatePassangerCapacity()
        {
            return r.Next(1, 6 + 1);
        }

        public static int CreateHorsepower()
        {
            return r.Next(10, 1000 + 1);
        }

        public static int CreateLength()
        {
            return r.Next(10, 60 + 1);
        }

        public static int CreateContainerCapacity()
        {
            return r.Next(0, 500 + 1);
        }

        public static int CreateBeds()
        {
            return r.Next(1, 4 + 1);
        }

        public static Boat RandomBoat()
        {
            Random r = new Random();
            int rnd = r.Next(1, 5 + 1);

            switch (rnd)
            {
                case 1:
                    return (new Rowboat());
                case 2:
                    return (new Motorboat());
                case 3:
                    return (new Sailingboat());
                case 4:
                    return (new CargoVessel());
                case 5:
                    return (new Katamara());
                default:
                    return (new Boat());
            }
        }
    }
}
