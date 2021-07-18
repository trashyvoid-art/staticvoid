using System;
//below makes it so that i can use lists. stinky!
using System.Collections.Generic;
using static System.Console;

namespace adventureCodeReading
{
    public class Location
    {
        public string Name;
        public string Description;
        public int eldritchLvl;
        public List<Item> itemList = new List<Item>();

        public Location(string _name, string _desc, int _eLvl)
        {
            Name = _name;
            Description = _desc;
            eldritchLvl = _eLvl; 
        }

        public void Investigate()
        {
            // put an item array here that lists
            // the stuff in the room
            foreach (Item item in itemList)
            {
                WriteLine(item.Name);
            }
        } 
    }
}
