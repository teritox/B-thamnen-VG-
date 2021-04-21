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

        public static List<string> StatisticsList = new List<string>();

        public static void CreateBoatTrafficList()
        {
            BoatTrafficList.Clear();

            if (LeavingBoats > 0)
            {
                BoatTrafficList.Add($"{LeavingBoats} båt/ar lämnade hamnen.\n");
            }
            else
            {
              BoatTrafficList.Add("\n\n");
            }

            if (TurnedAwayBoats > 0)
            {
                BoatTrafficList.Add($"{TurnedAwayBoats} båt/ar fick inte plats i hamnen och \nseglade vidare.");
            }

        }

        //Creates a list to be viewed in Listbox or similar of the boats in the harbour + any empty slots.
        public static void CreateHarbourDisplayList()
        {
            HarbourDisplayList.Clear();
            int arrayNr = 1;

            foreach (int[] array in Harbour.BoatRegister)
            {
                HarbourDisplayList.Add(string.Format($"{"Kaj " + arrayNr,40}\n\n{"Plats",0} {"Båttyp",14} {"Nr",8} {"Vikt",11} {"Maxhastighet",15} {"Övrigt", 15}\n"));

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == 0)
                    {
                        HarbourDisplayList.Add(string.Format($"{i + 1,-11} {"Tomt"}"));
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

        //Creates list for Listview or similar with the different methods in this class. 
        public static void CreateStatisticsList()
        {
            StatisticsList.Clear();

            StatisticsList.Add(Statistics.BoatsPerType());
            StatisticsList.Add(Statistics.TotalWeight());
            StatisticsList.Add(Statistics.AvarageSpeed());
            StatisticsList.Add(Statistics.FreeSpacesInHarbour());
            StatisticsList.Add(Statistics.TotalOfTurnedAwayBoats());

        }

        public static void Reset()
        {
            LeavingBoats = 0;
            TurnedAwayBoats = 0;
        }
    }
}
