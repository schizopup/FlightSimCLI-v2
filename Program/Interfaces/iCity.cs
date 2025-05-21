
using System;

namespace FlightSimulator
{
    internal interface iCity
    {
        static string city;
        static int  location;

        public abstract static string getCity();
        public abstract static int getLocation();
    }
}
