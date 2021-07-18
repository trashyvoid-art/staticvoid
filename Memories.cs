using System;
using static System.Console;
namespace adventureCodeReading
{
    public class Memories
    {
        Player player;


        public Memories(Player _player)
        {
            player = _player;
        }

        public void Mom()
        {
            player.memMom = true;

            Text.Mems("Suddenly, you hear a glass breaking and every muscle in your" +
                "\nbody flinches out of instinct. You hate sharp, sudden noises.");

            ReadKey();

            Text.Mems("You stand in your mother's home, a day before leaving for college." +
                "\nYou accidentally knocked over her favorite blue vase, and immediately" +
                "\ncrouch down to pick up the 5 large pieces.");

            ReadKey();

            Text.Entity($"{player.Name}, what was that?");
            ReadKey();

            Text.Game("What will you do? Type a number.");
            Text.Game("1. Fess up || 2. Lie");
            player.Choice = ReadLine();

            if (player.Choice == "1")
            {
                player.momTruth = true;
                Text.Player("I broke the vase.");
                ReadKey();

                Text.Mems("You told the truth, despite how you feel about your mother.");
                ReadKey();

                Text.Mems("You wish your relationship with her were better, though.");
            }
            else
            {
                if (player.Choice == "2")
                {

                    player.momLie = true;

                    Text.Player("Just dropped my phone.");
                    ReadKey();

                    Text.Mems("Unforunate, that you became so accostumed to" +
                        "\nwaving her off. But you'd rather that than to deal" +
                        "\nwith her opinions of you.");
                    ReadKey();

                    Text.Mems("But still, those very opinions take a toll on you." +
                        "\nNothing is resolved");
                    player.mentalPoints -= 3;
                }
                else
                {
                    player.momNeut = true;

                    Text.Mems("You stay silent.");
                    ReadKey();
                    Text.Mems("That's all you ever did whenever she asked you.");
                    Text.Game("It takes a toll on you.");
                    player.mentalPoints -= 3;
                }
            };

            Text.Game("As you walk out of the house, you are hazed by the techno-" +
                "\nreality you've already forgotten about.");
            ReadKey();
            Text.Entity("\"Yet you were already here.\"");

            ReadKey();
        }

        public void Present()
        {
            player.memPres = true;
            Text.Mems("A knot forms in your stomach as you hear The Entity's" +
                "\nwhispers wash over you and bring you to the front of a classroom.");

            Text.Mems("It's whispers turn into classmates.");
            ReadKey();

            Text.Mems("As you stand in front of your college classmates, you seem to" +
                "\n look lost.");
            Text.Game("What do you do? Type a number.");
            Text.Game("1. Ask to be excused || 2. Present ");
            player.Choice = ReadLine();

            if (player.Choice.ToLower() == "1")
            {
                player.presLie = true;
                player.mentalPoints -= 3;

                Text.Mems("You ask to be excused, you don't want to present.");
                ReadKey();

                Text.Mems("Remembering that you asked to be excused, and that it ultimately lowered" +
                    "\nyour grade, takes a toll on you.");
                ReadKey();
            }
            else
            {
                if (player.Choice.ToLower() == "2")
                {
                    player.presTruth = true;
                    player.mentalPoints -= 3;

                    Text.Mems("You don't want to do it, but you do so anyway; sweat beading" +
                        "\ndown your forehead and stammering about while your anxiety" +
                        "\ntakes hold of your speech process.");
                    ReadKey();

                    Text.Mems("You fel as though you've made a fool of yourself, despite knowing that" +
                        "\nyour classmates probably didn't care whether you flubbed it or not.");
                    ReadKey();

                    Text.Mems("Still, remembering this takes a toll on you.");
                    ReadKey();
                }
                else
                {
                    player.presNeut = true;
                    Text.Mems("Actually, you'd rather not remember this.");
                    ReadKey();

                    Text.Mems("School was stressful. There's no need to dwell on the past.");
                }
            }

            Text.Game("As you exit the classroom, you are step back out into your code.");

            ReadKey();
        }

        public void Interview()
        {
            player.memInt = true;

            Text.Mems("As you turn to find where the whispers are coming from," +
                "\nyou see a screen with the word \"EMPLOYER\" on it, and" +
                "\na familiar voice begins to speak.");
            ReadKey();

            Text.Entity($"This is {player.Name}, correct? Let's get started.");
            player.mentalPoints -= 3;
            ReadKey();

            Text.Mems("You go through the motions of the interview, but there's nothing you could do to" +
                "\nmake anything worse, or to make anything better. This interview takes a toll on you.");
            ReadKey();
        }
    }
}
