using System;

class Program
{
    static void Main(string[] args)
    {
        // array storing the sensor locations
        Sensors.SensorLocation[] sensorLocations = new Sensors.SensorLocation[]
        {
            new Sensors.SensorLocation("Maseru", "Engineering Block", "Server Room"),
            new Sensors.SensorLocation("Maseru", "Library", "Quiet Study Area"),
            new Sensors.SensorLocation("Maseru", "Admin Building", "Reception")
        };

        // an array to hold the temperature readings
        double[,] temperatures = new double[sensorLocations.Length, sensorLocations.Length];

        // populate the temperature readings with random values
        Random random = new Random();
        for (int i = 0; i < sensorLocations.Length; i++)
        {
            for (int j = 0; j < sensorLocations.Length; j++)
            {
                temperatures[i, j] = random.NextDouble() * 30 + 15;
            }
        }

        // float array for humidity readings
        float[,] humidity = new float[sensorLocations.Length, sensorLocations.Length];

        // populate the humidity readings with random values

        for (int i = 0; i < sensorLocations.Length; i++)
        {
            for (int j = 0; j < sensorLocations.Length; j++)
            {
                humidity[i, j] = (float)(random.NextDouble() * 100);
            }
        }
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