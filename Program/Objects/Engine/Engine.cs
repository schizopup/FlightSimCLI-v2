using System;

namespace FlightSimulator //ml était FlightSimCLI
{//ml classe Engine ajoutée
    public class Engine
    {
        int damage=0;
        bool status;

        public Engine() {

            // ml ajout - initialisation
            status = false; //ml0 engine not running. true = running
            damage = 0;

        }



        public  int getDamage()
        { //ml ajout int
            return damage;
        }





     public void setDamage(int damage) //ml ajout public void  ajout int damage
        {
            this.damage += damage; //ml ajout += le dommage s'ajoute 
        }


       public bool getStatus()
        {

            return status;
        }



      public void setStatus(bool status)
        {

        this.status = status;
        }

    }
}
