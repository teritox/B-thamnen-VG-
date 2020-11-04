using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Båtuppgiften_WPF_.Classes
{
    class Announcer
    {
        public static int TurnedAwayBoats { get; set; }
        public static int LeavingBoats { get; set; }

        public static List<string> HarbourDisplayList = new List<string>();

        public static List<string> BoatTrafficList = new List<string>();

        public static void CreateBoatTrafficList()
        {
            BoatTrafficList.Clear();

            if (LeavingBoats > 0)
            {
                BoatTrafficList.Add($"{LeavingBoats} båt/ar lämnade hamnen\n");
            }
            else
            {
              BoatTrafficList.Add("\n\n");
            }

            if (TurnedAwayBoats > 0)
            {
                BoatTrafficList.Add($"{TurnedAwayBoats} båt/ar fick inte plats i hamnen och seglade vidare.");
            }

        }

        //Creates a list to be viewed in Listbox or similar of the boats in the harbour + any empty slots.
        public static void CreateHarbourDisplayList()
        {
            HarbourDisplayList.Clear();
            int arrayNr = 1;

            foreach (int[] array in Harbour.BoatRegister)
            {
                HarbourDisplayList.Add($"Kaj {arrayNr}\nPlats        Båttyp            Nr               Vikt            Maxhast               Övrigt\n");

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == 0)
                    {
                        HarbourDisplayList.Add($"{i + 1} Tomt");
                    }
                    else
                    {
                        foreach (Boat boat in Harbour.BoatsInHarbour)
                        {
                            if (boat.Landing == arrayNr && boat.MooredAtNr == i + 1)
                            {
                                HarbourDisplayList.Add(boat.ToString());
                            }
                        }
                    }
                }
                HarbourDisplayList.Add("\n");
                arrayNr++;
            }
        }

        public static void Reset()
        {
            LeavingBoats = 0;
            TurnedAwayBoats = 0;
        }
    }
}
