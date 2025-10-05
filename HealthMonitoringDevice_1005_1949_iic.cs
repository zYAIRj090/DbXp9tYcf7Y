// 代码生成时间: 2025-10-05 19:49:46
using System;
using System.Collections.Generic;

namespace HealthMonitoringApp
{
    // Represents a health monitoring device
    public class HealthMonitoringDevice
    {
        private Dictionary<string, double> measurements;

        public HealthMonitoringDevice()
        {
            measurements = new Dictionary<string, double>();
        }

        // Adds a measurement to the device
        public void AddMeasurement(string type, double value)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentException("Measurement type cannot be null or empty.");
            }

            measurements[type] = value;
        }

        // Retrieves a measurement from the device
        public double GetMeasurement(string type)
        {
            if (!measurements.ContainsKey(type))
            {
                throw new KeyNotFoundException($"Measurement of type {type} not found.");
            }

            return measurements[type];
        }

        // Clears all measurements from the device
        public void ClearMeasurements()
        {
            measurements.Clear();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HealthMonitoringDevice device = new HealthMonitoringDevice();

            try
            {
                device.AddMeasurement("HeartRate", 75.5);
                device.AddMeasurement("BloodPressure", 120.0);
                Console.WriteLine($"Heart Rate: {device.GetMeasurement("HeartRate")}");
                Console.WriteLine($"Blood Pressure: {device.GetMeasurement("BloodPressure")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}