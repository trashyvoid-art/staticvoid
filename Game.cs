using System;
using System.Collections.Generic;
using static System.Console;
using System.IO;
using System.Windows;

namespace adventureCodeReading
{
    public class Game
    {

        Player player;
        Entity entity;
        Location currentLocation;
        public string choice;
        int index = 0;

        // ITEM INSTANCES
        List<Item> mainItems = new List<Item>()
        {
            new Item("Note to self","A note that reads: \nFix bugs\nRefactor main class\nSet alarm for lunch")
        };

        List<Item> cascadeItems = new List<Item>()
        {
            //show the player's favorite scent
            new Item("Candle", "A candle that smells like your favorite scent.")

        };

        List<Item> junkItems = new List<Item>()
        {
            new Item("Gazing pearl","A pearl that looks like an eye")
        };

        // LOCATION INSTANCES
        static Location Start = new Location("Main Class", "Voided walls of binary cluttering the area", 3);
        static Location Binary = new Location("The Binary Cascade", "A spacious area with codes of binary\nflowing through fountains", 2);
        static Location Junction = new Location("Junction Function", "An intense, chattering scene with looping functions and dancing\ncode" +
            "at a fork in the road. Only one path is available.", 5);

        // LOCATION ARRAY
        Location[] Map = new Location[]
        {
            Start, Binary, Junction
        };


        public Game()
        {
            
            player = new Player();
            entity = new Entity(player);
            cascadeItems[0].Description = $"A candle that smells like {player.faveScent}.";
            
            Start.itemList = mainItems;
            Binary.itemList = cascadeItems;
            Junction.itemList = junkItems;

            Text.Game("Tap");
            ReadKey();

            Text.Game("Tap");
            ReadKey();

            Text.Game("Tap");
            ReadKey();

            Clear();

            string intro = File.ReadAllText(@"Texts/Intro.txt");
            Text.Game(intro);
            Text.Game("What's your favorite scent?");
            player.faveScent = ReadLine();

            Text.Game($"You exhale and the smell of {player.faveScent} slowly" +
                $"\nstarts to rise into the room. ");

            ReadKey();

            Text.Game("After you relax, you decide to boot up the program you've been" +
                "\nworking on. It asks for your name, so you type in your name..");
            player.Name = ReadLine();

            Text.Entity($"{player.Name}...");
            ReadKey();

            Text.Game("You whip your head around- what was that?");
            ReadKey();

            Text.Entity($"{player.Name}, step into the code.");

            entity.Invoke();

            currentLocation = Start;
            Text.Game($"You look around, looking at the code blah blah you're in {currentLocation.Name}");
            Text.Game($"{currentLocation.Description}");
            Choice();

            ReadKey();
        }

        public void Choice()
        {
            Text.Game("What will you do?");
            WriteLine("Investigate || Move || Check Stats "); 
            choice = ReadLine();
            if (choice.ToLower() == "investigate")
            {
                currentLocation.Investigate();
                //currentLocation.itemList added to player.Inventory
                player.Inventory.Add(currentLocation.itemList[0]);

                Text.Game("Whatever has been found has been put in your inventory.");

                Choice();
            }
            else
            {
                if (choice.ToLower() == "move")
                {
                    Text.Game("Where do you want to go? Forwards? Or Backwards?");
                    Move();
                }
                else
                {
                    if (choice.ToLower() == "check stats" || choice.ToLower() == "check")
                    {
                        Text.Game("PLAYER STATS");
                        Text.Game($"FAVORITE SCENT: {player.faveScent}");
                        Text.Game($"MENTAL POINTS: {player.mentalPoints}");
                        Text.Game("INVENTORY:");
                        foreach (Item item in player.Inventory)
                        {
                            WriteLine("");
                            Text.Player("---------");
                            WriteLine(item.Name);
                            Text.Mems(item.Description);
                        }

                        Choice();
                    }
                    else
                    {
                        Text.Game("You haven't made a choice.");
                        Choice();
                    }
                }
            };

            ReadKey();

        }

        public void Move()
        {
            choice = ReadLine();
            if (choice.ToLower() == "forward")
            {
                index++;
                currentLocation = Map[index];

                player.mentalPoints -= currentLocation.eldritchLvl;

                Text.Game($"You move to {currentLocation.Name}.");
                Text.Game($"{currentLocation.Description}");

                checkMP();
                Choice();
            }
            else
            {
                if (choice.ToLower() == "backward")
                {
                    Text.Game($"You've moved back from {currentLocation.Name}");

                    index--;
                    currentLocation = Map[index];

                    player.mentalPoints -= currentLocation.eldritchLvl;

                    Text.Game($"You are now in {currentLocation.Name}, {currentLocation.Description}");
                    checkMP();
                    Choice();
                }
                else
                {
                    Text.Game("You haven't picked a location, so you decide to stay in the room.");
                    Choice();
                }
            };

            ReadKey();
        }


        public void checkMP()
        {
            if(player.mentalPoints <= 18)
            {
                if (player.mentalPoints <= 12)
                {
                    Confrontation();
                }
                else
                {
                    entity.Invoke();
                }
            }
            else
            {

            }
        }

        public void Confrontation()
        {
            Text.Entity("Welcome to the end.");
            ReadKey();
            bool hasCandle = player.checkItem("Candle");
            bool hasPearl = player.checkItem("Gazing pearl");

            Text.Entity("You could make the place more comfortable; maybe lighten the mood.");
            if (hasCandle)
            {
                Text.Game("You smell your candle in your inventory. Light it?");
                choice = ReadLine();
                if(choice.ToLower() == "yes")
                {
                    Text.Game($"You light your candle, and {player.faveScent} wafts through the air. ");
                    ReadKey();
                    Text.Game("You wake up.");
                    ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    if(choice.ToLower() == "no")
                    {
                        Text.Game("You don't light your candle.");
                        ReadKey();
                        Text.Game("You feel inclined to speak to the entity.");
                    }
                    else
                    {
                        Text.Game("You're at a loss for actions. You don't know what to do.");
                    }
                }
            }
            else
            {
                Text.Game($"You wish you could smell some {player.faveScent}");
            }
            ReadKey();

            Text.Entity($"I see your mind has arrived at the {player.mentalPoints}th level...");
            ReadKey();
            Text.Entity("Let's sit down and have a conversation about that.");
            ReadKey();
            entity.Recall();
            ReadKey();

            Text.Entity("Now, I know you'd like to get out of here.");
            ReadKey();

            Text.Entity("You have it, then, don't you?");

            if (hasPearl)
            {
                Text.Game($"Give the pearl to {entity.Name}?");
                player.Choice = ReadLine();

                if(player.Choice.ToLower() == "yes")
                {
                    Text.Entity("By giving this to me, it shows you haven't reflected on yourself.");
                    ReadKey();
                    Text.Entity("You just want an out.");
                    ReadKey();
                }
                else
                {
                    Text.Entity($"Good choice, {player.Name}");
                    ReadKey();

                    Text.Entity("You've reflected a lot since your time here, haven't you?");
                    ReadKey();

                    Text.Entity("Very well.");
                    ReadKey();

                    Clear();
                    ReadKey();

                    Text.Mems("You wake up at your desk.");
                    ReadKey();

                    Text.Game("You seem to have fallen asleep while playtesting.");
                    ReadKey();

                    Text.Game("It was... Odd. Strange. But your head is a little clearer for it." +
                        "\n You feel refreshed, and even a little lighter.");
                    ReadKey();

                    Text.Player("\"I think I'm going to take a walk.\"");
                    ReadKey();

                }
            }
            else
            {
                ReadKey();
                Text.Entity("You don't know what I'm talking about?");
                ReadKey();
                Text.Entity("It seems like we'll have to try this again.");
                ReadKey();
                Text.Entity("Good bye, for now.");
            }

            Text.Game("Press any key to end the game.");
            ReadKey();
            Environment.Exit(0);

        }

    }
}
