
using System;
using FlightSimulator;

namespace FlightSimulator
{
    internal class MexicoCity : iCity
    {
        public static string city = "Mexico City";
        public static int location = 300;


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
