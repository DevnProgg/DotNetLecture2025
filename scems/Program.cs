using System;

class Program
{
    static void Main(string[] args)
    {
    }
}

public class Sensors
{
    public class SensorLocation
    {
        //class members
        public string City, Building, Room;

        //constructor
        public SensorLocation(string city, string building, string room)
        {
            City = city;
            Building = building;
            Room = room;
        }

        //override ToString method
        public override string ToString()
        {
            return $"{City}, {Building}, {Room}";
        }
    }
}