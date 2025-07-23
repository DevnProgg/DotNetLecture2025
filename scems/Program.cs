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

        // single-dimensional array to hold the temperature readings
        double[] temperatures = new double[sensorLocations.Length];

        // populate the temperature readings with random values
        Random random = new Random();
        for (int i = 0; i < sensorLocations.Length; i++)
        {
            temperatures[i] = random.NextDouble() * 30 + 15;
        }

        // single-dimensional array for humidity readings
        float[] humidity = new float[sensorLocations.Length];

        // populate the humidity readings with random values
        for (int i = 0; i < sensorLocations.Length; i++)
        {
            humidity[i] = (float)(random.NextDouble() * 100);
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

public class SensorReport
{
    // Method to generate a report of sensor readings
    public static void GenerateReport(Sensors.SensorLocation[] sensorLocations, double[,] temperatures, float[,] humidity)
    {
        for (int i = 0; i < sensorLocations.Length; i++)
        {
            var location = sensorLocations[i];

            // Retrieve temperature and humidity readings
            double tempReading = temperatures[i, i]; // Implicit conversion
            decimal humidityReading = (decimal)humidity[i, i]; // Explicit cast

            // Print report using string interpolation
            Console.WriteLine(
                $"Sensor at [{location}]: Temperature: {tempReading:F1}°C, Humidity: {humidityReading:F1}%");
        }
    }
}

public class CampusAverages
{
    // Method to print daily averages of temperature and humidity
    public static void PrintDailyAverages()
    {
        // [day, 0=temp, 1=humidity]
        double[,] dailyAverages = new double[2, 2]
        {
            { 24.0, 63.5 }, // Day 1
            { 23.8, 61.9 }  // Day 2
        };

        for (int day = 0; day < dailyAverages.GetLength(0); day++)
        {
            double avgTemp = dailyAverages[day, 0];
            double avgHumidity = dailyAverages[day, 1];
            Console.WriteLine($"Day {day + 1} Average: Temp {avgTemp:F1}°C, Humidity {avgHumidity:F1}%");
        }
    }
}

