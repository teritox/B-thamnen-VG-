using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Båtuppgiften_WPF_.Classes
{
    class Statistics
    {
        public static int TurnedAwayTotal { get; set; }

        //Counts all the boats per type in the harbour.
        public static string BoatsPerType()
        {

            int rowboats = 0, motorboats = 0, sailingboats = 0, cargoVessels = 0, katamaras = 0;

            foreach (Boat boat in Harbour.BoatsInHarbour)
            {
                switch (boat.IdentityNumber.FirstOrDefault())
                {
                    case 'R':
                        rowboats++;
                        break;
                    case 'M':
                        motorboats++;
                        break;
                    case 'S':
                        sailingboats++;
                        break;
                    case 'L':
                        cargoVessels++;
                        break;
                    case 'K':
                        katamaras++;
                        break;
                    default:
                        break;
                }

            }

            return $"I hamnen finns det : {rowboats}st roddbåtar, {motorboats}st motorbåtar,\n {sailingboats}st segelbåtar, " +
                $"{cargoVessels}st lastfartyg och {katamaras}st katamaraner.\n";
        }

        public static string TotalWeight()
        {
            int sum = 0;

            foreach (var boat in Harbour.BoatsInHarbour)
            {
                sum += boat.Weight;
            }

            return $"Alla båtarna i hamnen väger {sum}kg tillsammans.\n";
        }

        public static string AvarageSpeed()
        {
            var q2 = Harbour.BoatsInHarbour
                .Select(b => b.MaxSpeed);

            decimal avarage = 0;

            foreach (var speed in q2)
            {
                avarage += speed;
            }
            int avarageSpeed = 0;

            if (q2.Count() != 0)
            {
                avarageSpeed = (int)Math.Round((avarage / q2.Count()) * 1.852M);
            }
            
            return $"Båtarnas medelhastighet är: {avarageSpeed} km/h.\n";

        }

        public static string FreeSpacesInHarbour()
        {
            int spaces = 0;
            foreach (int[] array in Harbour.BoatRegister)
            {
                foreach (int slot in array)
                {
                    if (slot == 0)
                    {
                        spaces++;
                    }
                }
            }

            return $"Det finns {spaces}st lediga plaster i hamnen.\n";
        }

        public static string TotalOfTurnedAwayBoats()
        {
            return $"Total mängd avvisade båtar: {TurnedAwayTotal}.";
        }
        
    }
}
