using System;

namespace FlightSimulator //ml �tait  FlightSimCLI
{
    public class Cabin
    {
        int damage=0;
        public int getDamage()
        { //ml ajout int
            return damage;
        }

        public void setDamage(int damage) //ml ajout public void  ajout int damage
        {
            this.damage += damage; //ml ajout += le dommage s'ajoute 
        }

    }
}
