using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Båtuppgiften_WPF_.Classes
{
    class Harbour
    {
        public static List<int[]> BoatRegister = new List<int[]>();

        public static List<Boat> BoatsInHarbour = new List<Boat>();

        public static List<Boat> NewBoats = new List<Boat>();


        public static void CreateHarbour()
        {
            int[] BoatRegister1 = new int[32];
            BoatRegister.Add(BoatRegister1);

            int[] BoatRegister2 = new int[32];
            BoatRegister.Add(BoatRegister2);
        }

        public static void MoorNewBoats()
        {
            foreach (Boat boat in NewBoats)
            {

                var q1 = BoatsInHarbour
                            .Where(b => b.IdentityNumber.StartsWith("R"))
                            .GroupBy(b => b.MooredAtNr)
                            .FirstOrDefault(b => b.Count() == 1);

                if (boat is Rowboat && q1 != null)
                {
                    foreach (var singlerowboat in q1)
                    {
                        boat.MooredAtNr = singlerowboat.MooredAtNr;
                        boat.Landing = singlerowboat.Landing;

                        BoatRegister[boat.Landing - 1][boat.MooredAtNr - 1]++;
                        BoatsInHarbour.Add(boat);
                        break;
                    }
                }
                else
                {
                    FindFreeSpace(boat);

                    if (boat.MooredAtNr == 0 && boat.Landing == 0)
                    {
                        Announcer.TurnedAwayBoats++;
                        Statistics.TurnedAwayTotal++;
                    }
                    else
                    {
                        for (int i = boat.MooredAtNr; i < boat.MooredAtNr + boat.NeededSpace; i++)
                        {
                            BoatRegister[boat.Landing - 1][i - 1]++;
                        }
                        BoatsInHarbour.Add(boat);
                    }
                }
            }
            NewBoats.Clear();
        }

        //Checks for an empty slot big enough for the boat. If one can't be found it will return with both properties = 0.
        public static void FindFreeSpace(Boat boat)
        {
            int freeSpace = 0;
            int arrayNr = 1;

            foreach (int[] array in Harbour.BoatRegister)
            {

                for (int i = 0; i < array.Length - 1; i++)
                {
                    while (array[i + freeSpace] == 0)
                    {
                        freeSpace++;

                        if (i + freeSpace == array.Length)
                        {
                            boat.MooredAtNr = 0;
                            boat.Landing = 0;
                            break;
                        }
                        else if (freeSpace == boat.NeededSpace)
                        {
                            boat.MooredAtNr = i + 1;
                            boat.Landing = arrayNr;
                            return;
                        }
                    }
                    freeSpace = 0;
                }
                arrayNr++;
            }
        }

        //Only used for imported boats from a file.
        public static void RegisterImportedBoats(Boat boat)
        {
            int freeSpace = boat.MooredAtNr;

            for (int i = boat.MooredAtNr; i < boat.MooredAtNr + boat.NeededSpace; i++)
            {
                BoatRegister[boat.Landing - 1][i - 1]++;
            }
            BoatsInHarbour.Add(boat);
        }

        public static void CreateNewBoats()
        {
            for (int i = 0; i < 5; i++)
            {
                NewBoats.Add(Randomizer.RandomBoat());
            }
        }

        //Checks for boats that will be leaving the harbour and removes them from the list of boats in the harbour.
        public static void LeavingBoats()
        {
            int arrayNr = 1;

            foreach (int[] array in Harbour.BoatRegister)
            {
                for (int i = BoatsInHarbour.Count() - 1; i > -1; i--)
                {
                    if (BoatsInHarbour[i].StaysInHarbourFor == BoatsInHarbour[i].DaysInHarbour && BoatsInHarbour[i].Landing == arrayNr)
                    {
                        for (int j = 0; j < BoatsInHarbour[i].NeededSpace; j++)
                        {
                            int newOpening = BoatsInHarbour[i].MooredAtNr - 1 + j;
                            array[newOpening]--;
                        }
                        BoatsInHarbour.RemoveAt(i);
                        Announcer.LeavingBoats++;
                    }
                }
                arrayNr++;
            }
        }
        public static void NextDay()
        {
            foreach (Boat boat in BoatsInHarbour)
            {
                boat.DaysInHarbour++;
            }
        }

       
    }
}
