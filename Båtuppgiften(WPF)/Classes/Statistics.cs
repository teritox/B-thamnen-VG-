using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Båtuppgiften_WPF_.Classes
{
    class Statistics
    {
        public static int TurnedAwayTotal { get; set; }

        public static List<string> AnnouncementList = new List<string>();

        //Counts all the boats per type in the harbour.
        private static string BoatsPerType()
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
                $"{cargoVessels}st lastfartyg och {katamaras}st katamaror.\n";
        }

        private static string TotalWeight()
        {
            int sum = 0;

            foreach (var boat in Harbour.BoatsInHarbour)
            {
                sum += boat.Weight;
            }

            return $"Alla båtarna i hamnen väger {sum}kg tillsammans.\n";
        }

        private static string AvarageSpeed()
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

        private static string FreeSpacesInHarbour()
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

        private static string TotalOfTurnedAwayBoats()
        {
            return $"Total mängd avvisade båtar: {TurnedAwayTotal}.";
        }

        //Creates list for Listview or similar with the different methods in this class. 
        public static void CreateStatisticsList()
        {
            AnnouncementList.Clear();

            AnnouncementList.Add(BoatsPerType());
            AnnouncementList.Add(TotalWeight());
            AnnouncementList.Add(AvarageSpeed());
            AnnouncementList.Add(FreeSpacesInHarbour());
            AnnouncementList.Add(TotalOfTurnedAwayBoats());

        }
    }
}
