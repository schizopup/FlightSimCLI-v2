
using System;

namespace FlightSimulator
{
    internal class Weather
    {
        // base damage taken from weather
        public int damage = 0;

        // randomizes the weather
        public string weatherChange()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 101);

            if (randomNumber <= 60)
            {
                damage = 0;
                return "Sunny";

            }
            else if (randomNumber <= 70)
            {
                damage = 4;

                return "Rainy";

            }
            else if (randomNumber <= 90)
            {
                damage = 2;

                return "Windy";
            }
            else
            {
                damage = 6;

                return "Stormy";
            }
        }


        // returns the damage taken from weather
        public int getDamage()
        {
            return damage;
        }
    }
}
