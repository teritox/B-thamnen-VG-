using System;
using System.Collections.Generic;
using System.Text;

namespace Båtuppgiften_WPF_.Classes
{
    static class Utility
    {
        public static bool Exists(this string s)
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

        public static string MooredAt(Boat b)
        {
            switch (b)
            {
                case Rowboat r:
                case Motorboat m:
                    return $"{b.MooredAtNr}";
                case Sailingboat s:
                    return $"{b.MooredAtNr} - {b.MooredAtNr + 1}";
                case CargoVessel c:
                    return $"{b.MooredAtNr} - {b.MooredAtNr + 3}";
                case Katamara k:
                    return $"{b.MooredAtNr} - {b.MooredAtNr + 2}";
                default:
                    return "";
            }
        }
    }
}
