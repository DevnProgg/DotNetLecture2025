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

        //CREATE MENU FOR RUNNING EACH ASPECT OF THE APPLICATION
        while (true)
        {
            Console.WriteLine("\nSensor Data Management System");
            Console.WriteLine("1. Organize and Print Sensor IDs");
            Console.WriteLine("2. Generate Sensor Report");
            Console.WriteLine("3. Print Daily Averages");
            Console.WriteLine("4. Boxing/Unboxing Demo");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string? input = Console.ReadLine();
            //check to make sure we don't assign null to choice
            string choice = input ?? string.Empty;

            switch (choice)
            {
                case "1":
                    Sensors.SensorIDOrganizer.OrganizeAndPrintSensorIDs();
                    break;
                case "2":
                    Sensors.SensorReport.GenerateReport(sensorLocations, temperatures, humidity);
                    break;
                case "3":
                    Sensors.CampusAverages.PrintDailyAverages();
                    break;
                case "4":
                    Sensors.BoxingUnboxingDemo.Run(temperatures[0]);
                    break;
                case "5":
                    return; // Exit the application
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            
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
    public class SensorIDOrganizer
    {
        public static void OrganizeAndPrintSensorIDs()
        {
            int[] sensorIDs = new int[] { 501, 102, 730, 245, 110 };

            Console.WriteLine("Sensor IDs before sorting: " + string.Join(", ", sensorIDs));

            Array.Sort(sensorIDs);

            Console.WriteLine("Sensor IDs after sorting: " + string.Join(", ", sensorIDs));
        }
    }
    public class SensorReport
    {
        // Method to generate a report of sensor readings
        public static void GenerateReport(Sensors.SensorLocation[] sensorLocations, double[] temperatures, float[] humidity)
        {
            for (int i = 0; i < sensorLocations.Length; i++)
            {
                var location = sensorLocations[i];

                // Retrieve temperature and humidity readings
                double tempReading = temperatures[ i]; // Implicit conversion
                decimal humidityReading = (decimal)humidity[ i]; // Explicit cast

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
    public class BoxingUnboxingDemo
    {
        public static void Run(double temperature)
        {
            // Boxing: assign double to object
            object boxedTemp = temperature;
            Console.WriteLine($"Original double value: {temperature}");
            Console.WriteLine($"Boxed object value: {boxedTemp}");

            // Unboxing: cast object back to double
            double unboxedTemp = (double)boxedTemp;
            Console.WriteLine($"Unboxed double value: {unboxedTemp}");

            // Challenge: Attempt to unbox as int
            try
            {
                int wrongUnbox = (int)boxedTemp;
                Console.WriteLine($"Unboxed as int: {wrongUnbox}");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("Error: Cannot unbox a boxed double as an int. " + "This causes an InvalidCastException because the runtime type is double, not int. \n" + ex.Message);
            }
        }
    }
}