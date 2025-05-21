
using System;
using FlightSimulator;

namespace FlightSimulator
{
    internal class Montreal : iCity
    {
        public static string city = "Montreal";
        public static int location = 450;


        // returns the city name
        public static string getCity()
        {
            return city;
        }

        // returns the city location
        public static int getLocation()
        {
            return location;
        }
    }
}
