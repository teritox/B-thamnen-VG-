using System;
using System.Collections.Generic;
using System.Text;

namespace Båtuppgiften_WPF_.Classes
{
    class Boat
    {
        public string IdentityNumber { get; set; }
        public int Weight { get; set; }
        public decimal MaxSpeed { get; set; }
        public int NeededSpace { get; set; }

        public int DaysInHarbour = 0;
        public int StaysInHarbourFor { get; set; }
        public int MooredAtNr { get; set; }
        public int Landing { get; set; }

        public override string ToString()
        {
            return "";
        }
    }

    class Rowboat : Boat
    {
        public int MaxAmountOfPassengers { get; private set; }
        public Rowboat()
        {
            IdentityNumber = PropRandomizer.CreateIdentityNumber("R");
            Weight = PropRandomizer.CreateWeight("R");
            MaxSpeed = PropRandomizer.CreateMaxSpeed("R");
            NeededSpace = 1;
            MaxAmountOfPassengers = PropRandomizer.CreatePassangerCapacity();
            StaysInHarbourFor = 1;
        }

        public Rowboat(string identityNumber, int weight, decimal maxSpeed, int mooredAtNr, int landing, int maxAmountOfPassengers)
        {
            IdentityNumber = identityNumber;
            Weight = weight;
            MaxSpeed = maxSpeed;
            NeededSpace = 1;
            MaxAmountOfPassengers = maxAmountOfPassengers;
            StaysInHarbourFor = 1;
            MooredAtNr = mooredAtNr;
            Landing = landing;
        }

        public override string ToString()
        {
            return $"{MooredAtNr}            Roddbåt        {IdentityNumber}            {Weight}            {Math.Round(MaxSpeed * 1.852M)} km/h        Max Antal plastser: {MaxAmountOfPassengers}";
        }
    }


    class Motorboat : Boat
    {
        public int Horsepower { get; private set; }
        public Motorboat()
        {
            IdentityNumber = PropRandomizer.CreateIdentityNumber("M");
            Weight = PropRandomizer.CreateWeight("M");
            MaxSpeed = PropRandomizer.CreateMaxSpeed("M");
            NeededSpace = 1;
            Horsepower = PropRandomizer.CreateHorsepower();
            StaysInHarbourFor = 3;
        }

        public Motorboat(string identityNumber, int weight, decimal maxSpeed, int mooredAtNr, int landing, int horsepower)
        {
            IdentityNumber = identityNumber;
            Weight = weight;
            MaxSpeed = maxSpeed;
            NeededSpace = 1;
            Horsepower = horsepower;
            StaysInHarbourFor = 3;
            MooredAtNr = mooredAtNr;
            Landing = landing;
        }

        public override string ToString()
        {
            return $"{MooredAtNr}           Motorbåt       {IdentityNumber}           {Weight}           {Math.Round(MaxSpeed * 1.852M)} km/h        Hästkrafter: {Horsepower}";
        }
    }

    class Sailingboat : Boat
    {
        public int Length { get; private set; }
        public Sailingboat()
        {
            IdentityNumber = PropRandomizer.CreateIdentityNumber("S");
            Weight = PropRandomizer.CreateWeight("S");
            MaxSpeed = PropRandomizer.CreateMaxSpeed("S");
            NeededSpace = 2;
            Length = PropRandomizer.CreateLength();
            StaysInHarbourFor = 4;
        }

        public Sailingboat(string identityNumber, int weight, decimal maxSpeed, int mooredAtNr, int landing, int length)
        {
            IdentityNumber = identityNumber;
            Weight = weight;
            MaxSpeed = maxSpeed;
            NeededSpace = 2;
            Length = length;
            StaysInHarbourFor = 4;
            MooredAtNr = mooredAtNr;
            Landing = landing;
        }

        public override string ToString()
        {
            return $"{MooredAtNr} - {MooredAtNr + 1}     Segelbåt        {IdentityNumber}           {Weight}            {Math.Round(MaxSpeed * 1.852M)} km/h         Båtlängd: {Length}m";
        }
    }

    class CargoVessel : Boat
    {
        public int Containers { get; private set; }
        public CargoVessel()
        {
            IdentityNumber = PropRandomizer.CreateIdentityNumber("L");
            Weight = PropRandomizer.CreateWeight("L");
            MaxSpeed = PropRandomizer.CreateMaxSpeed("L");
            NeededSpace = 4;
            Containers = PropRandomizer.CreateContainerCapacity();
            StaysInHarbourFor = 6;
        }

        public CargoVessel(string identityNumber, int weight, decimal maxSpeed, int mooredAtNr, int landing, int containers)
        {
            IdentityNumber = identityNumber;
            Weight = weight;
            MaxSpeed = maxSpeed;
            NeededSpace = 4;
            Containers = containers;
            StaysInHarbourFor = 6;
            MooredAtNr = mooredAtNr;
            Landing = landing;
        }

        public override string ToString()
        {
            return $"{MooredAtNr} - {MooredAtNr + 3}      Lastfartyg     {IdentityNumber}          {Weight}           {Math.Round(MaxSpeed * 1.852M)} km/h         Containers: {Containers}st";
        }
    }

    class Katamara : Boat
    {
        public int Beds { get; private set; }
        public Katamara()
        {
            IdentityNumber = PropRandomizer.CreateIdentityNumber("K");
            Weight = PropRandomizer.CreateWeight("K");
            MaxSpeed = PropRandomizer.CreateMaxSpeed("K");
            NeededSpace = 3;
            Beds = PropRandomizer.CreateBeds();
            StaysInHarbourFor = 3;
        }

        public Katamara(string identityNumber, int weight, decimal maxSpeed, int mooredAtNr, int landing, int beds)
        {
            IdentityNumber = identityNumber;
            Weight = weight;
            MaxSpeed = maxSpeed;
            NeededSpace = 3;
            Beds = beds;
            StaysInHarbourFor = 3;
            MooredAtNr = mooredAtNr;
            Landing = landing;

        }

        public override string ToString()
        {
            return $"{MooredAtNr} - {MooredAtNr + 2}      Katamara     {IdentityNumber}           {Weight}             {Math.Round(MaxSpeed * 1.852M)} km/h         Antal bäddplaster: {Beds}st";
        }
    }

}
