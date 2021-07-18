using System;
using static System.Console;
using System.Collections.Generic;
namespace adventureCodeReading
{
    public class Entity
    {
        public string Name = "FlyNt'agh";
        public int HP = 30;
        public Player player;
        public Memories mem;
        string randoMem;

        List<int> rando = new List<int>()
        {

        };

        string[] memories =
        {
            "Mom", "Class", "Interview"
        };

        public Entity(Player _player)
        {
            player = _player;
        }

        public void Whisper()
        {
            player.mentalPoints = player.mentalPoints - 5;

            Text.Game("You hear a faint slither of words coming from" +
                " the deepest stretches of the binary...");
            Text.Game("And you can barely make it out. The frustration deals 5 in damage" +
                "to your mental health.");

            Text.Game($"Mental Points:{player.mentalPoints}");
        }

        public int GenerateNumber()
        {
            Random random = new Random();
            int index = random.Next(0, memories.Length);
            if (!rando.Contains(index))
            {
                rando.Add(index);
            }
            else
            {
                GenerateNumber();
            }

            return index;
        }

        public void Invoke()
        {
            mem = new Memories(player);
            int index = GenerateNumber();
            randoMem = memories[index];

            if (randoMem == "Mom")
            {
                mem.Mom();
            }
            else
            {
                if (randoMem == "Class")
                {
                    mem.Present();
                }
                else
                {
                    mem.Interview();
                }
            }
        }

        public void Recall()
        {
            if (player.memMom)
            {
                Text.Entity("Let's talk about the last time you spoke to your mother.");
                ReadKey();

                if (player.momLie)
                {
                    Text.Entity("You lied to her, though it was something you're" +
                        "accustomed to.");

                    ReadKey();

                    Text.Entity("Because she was hard on you, even harsh. You feel justified.");
                }
                else
                {
                    if (player.momTruth)
                    {
                        Text.Entity("Despite her own faults, you still had your dignity.");
                    }
                    else
                    {
                        Text.Entity("You tried to avoid all interaction with her.");
                    }
                }
                ReadKey();
                player.memMom = false;
            }
            else
            {
                Text.Entity("We're not going to talk about your relationship with your mother.");
                ReadKey();
            }

            if (player.memInt)
            {
                Text.Entity("About that interview you had..");
                ReadKey();

                Text.Entity("They're all quite nerve-wracking aren't they?");
                ReadKey();

                Text.Entity("How do you feel about our conversation?");
                Text.Game("1. I don't know. || 2. I'm nervous. ");
                player.Choice = ReadLine();
                if(player.Choice.ToLower() == "1")
                {
                    Text.Entity("We never do know when confronted, do we?");
                }
                else
                {
                    if(player.Choice.ToLower() == "2")
                    {
                        Text.Entity("So am I. But we allow ourselves to admit it.");
                    }
                    else
                    {
                        Text.Entity("A person of few words.. I respect it.");
                    }
                }
                ReadKey();

                player.memInt = false;
            }
            else
            {
                Text.Entity("That interview you had doesn't seem to bother you.");
                ReadKey();
            }

            if (player.memPres)
            {
                Text.Entity("Remember when you presented in front of your class?");

                if (player.presNeut)
                {
                    Text.Entity("You say it doesn't bother you because it happened" +
                        "\nso long ago, but is that the truth?");

                    Text.Game("You adamantly refute your statement. You don't care about" +
                        "\nthe class presentation.");

                    Text.Entity("Oh. Well, then. Sure.");
                }
                else
                {
                    if (player.presLie)
                    {
                        Text.Entity("Was skipping the presentation worth your grade dropping?");
                        ReadKey();
                        Text.Entity("If it meant taking a break.. You could say you were justified.");
                    }
                    else
                    {
                        Text.Entity("You embarassed yourself in front of your classmates.");
                        ReadKey();
                        Text.Entity("At least, that's how you feel. It doesn't matter in the long run, though.");
                    }
                }

                player.memPres = false;
            }
            else
            {
                Text.Entity("It's not worth mentioning that class presentation");
            }
        }

        //to add: invoke method
        // could potentially, pull a random memory
        // from a text file to present to the player
        // which maybe they have to solve?
        // this makes replayability a little less non-linear
    }
}
