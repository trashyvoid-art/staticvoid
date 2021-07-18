using System;
using System.Collections.Generic;

namespace adventureCodeReading
{
    public class Player
    {
        public string Name = "Marwan";
        public string faveScent = "sandalwood";
        public int mentalPoints = 30;


        public string Choice;
        public bool memMom = false;
        public bool momLie = false;
        public bool momTruth = false;
        public bool momNeut = false;


        public bool memPres = false;
        public bool presLie = false;
        public bool presTruth = false;
        public bool presNeut = false;


        public bool memInt = false;


        public List<Item> Inventory = new List<Item>();


        public Player()
        {

        }

        public bool checkItem(string name)
        {
            foreach (Item item in Inventory)
            {
                if (item.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        //public void Recall()
        //{

        //}

    }
}
