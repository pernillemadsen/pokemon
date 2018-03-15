using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    class Program
    {
        
        static void Main(string[] args)
        {

            List<Pokemon> roster = new List<Pokemon>();


            List<Move> CharmanderMoves = new List<Move>();
            List<Move> SquirtleMoves = new List<Move>();
            List<Move> BulbasaurMoves = new List<Move>();

            Move Ember = new Move("Ember[0]");
            Move Fireblast = new Move("Fireblast[1]");
            Move Bubble = new Move("Bubble[0]");
            Move Bite = new Move("Bite[1]");
            Move Cut = new Move("Cut[0]");
            Move Megadrain = new Move("Megadrain[1]");
            Move Razorleaf = new Move("Razorleaf[2]");

            CharmanderMoves.Add(Ember);
            CharmanderMoves.Add(Fireblast);
            SquirtleMoves.Add(Bubble);
            SquirtleMoves.Add(Bite);
            BulbasaurMoves.Add(Cut);
            BulbasaurMoves.Add(Megadrain);
            BulbasaurMoves.Add(Razorleaf);

            Pokemon Charmander = new Pokemon("Charmander", 3, 52, 43, 39, Elements.Fire, CharmanderMoves);
            Pokemon Squirtle = new Pokemon("Squirtle", 2, 48, 65, 44, Elements.Water, SquirtleMoves);
            Pokemon Bulbasaur = new Pokemon("Bulbasaur", 3, 49, 49, 45, Elements.Grass, BulbasaurMoves);

            roster.Add(Charmander);
            roster.Add(Squirtle);
            roster.Add(Bulbasaur);



            // INITIALIZE YOUR THREE POKEMONS HERE

            Console.WriteLine("Welcome to the world of Pokemon!\nThe available commands are list/fight/heal/quit");

            while (true)
            {
                Console.WriteLine("\nPlese enter a command");
                switch (Console.ReadLine())
                {
                    case "list":
                        roster.ForEach(item => Console.WriteLine(item.Name + " "));
                        break;

                    case "fight":
                        //PRINT INSTRUCTIONS AND POSSIBLE POKEMONS (SEE SLIDES FOR EXAMPLE OF EXECUTION)
                        Console.Write("Choose who should fight - Charmander, Squirtle or Bulbasaur?\n");
                        //READ INPUT, REMEMBER IT SHOULD BE TWO POKEMON NAMES
                        string input = Console.ReadLine();
                        string[] inputs = input.Split(' ');

                        Pokemon player = null;
                        Pokemon enemy = null;

                        if (inputs.Length == 2)
                        {
                            foreach (Pokemon item in roster)
                            {
                                if (item.Name == inputs[0])
                                {
                                    player = item;
                                }

                                if (item.Name == inputs[1])
                                {
                                    enemy = item;
                                }
                            }
                        }

                        
                        
                        //if everything is fine and we have 2 pokemons let's make them fight
                        if (player != null && enemy != null && player != enemy)
                        {
                            Console.WriteLine("A wild " + enemy.Name + " appears!");
                            Console.Write(player.Name + " I choose you! ");

                            Console.WriteLine("What move should " + player.Name + " use?");
                            player.Moves.ForEach(item => Console.WriteLine(item.Name + " "));

                            //BEGIN FIGHT LOOP
                            while (player.Hp > 0 && enemy.Hp > 0)
                            {
                                string move = Console.ReadLine();

                                switch (move)
                                {
                                    case "0":
                                        Console.WriteLine(player.Name + " uses " + player.Moves[0].Name + ". ");

                                        int totalDamage = player.Attack(enemy);

                                         Console.WriteLine(enemy.Name + " loses " + totalDamage + " HP.");

                                        int applyDamage = enemy.ApplyDamage(totalDamage);
                                        
                                        break;

                                    case "1":
                                        Console.WriteLine(player.Name + " uses " + player.Moves[1].Name + ". ");

                                        int totalDamage1 = player.Attack(enemy);

                                         Console.WriteLine(enemy.Name + " loses " + totalDamage1 + " HP.");

                                        int applyDamage1 = enemy.ApplyDamage(totalDamage1);
                                        
                                        break;

                                    case "2":
                                        Console.WriteLine(player.Name + " uses " + player.Moves[2].Name + ". ");

                                        int totalDamage2 = player.Attack(enemy);

                                         Console.WriteLine(enemy.Name + " loses " + totalDamage2 + " HP.");

                                        int applyDamage2 = enemy.ApplyDamage(totalDamage2);

                                        break;
                                }

                            //if the enemy is not dead yet, it attacks
                            if (enemy.Hp > 0)
                                {
                                    //CHOOSE A RANDOM MOVE BETWEEN THE ENEMY MOVES AND USE IT TO ATTACK THE PLAYER
                                    Random rand = new Random();
                                    string bulbasaur = Convert.ToString(roster[2]);

                                    switch (rand.Next(3))
                                    {
                                        case 0:

                                            Console.WriteLine(enemy.Name + " uses " + enemy.Moves[0].Name + ". ");

                                            int totalDamage = enemy.Attack(player);

                                             Console.WriteLine(player.Name + " loses " + totalDamage + " HP.");

                                            int applyDamage = player.ApplyDamage(totalDamage);
                                            if (player.Hp > 0)
                                            {
                                                Console.WriteLine("What move should " + player.Name + " use next?");
                                                player.Moves.ForEach(item => Console.WriteLine(item.Name + " "));
                                            }

                                            break;

                                        case 1:

                                            Console.WriteLine(enemy.Name + " uses " + enemy.Moves[1].Name + ". ");

                                            int totalDamage1 = enemy.Attack(player);

                                            Console.WriteLine(player.Name + " loses " + totalDamage1 + " HP.");

                                            int applyDamage1 = player.ApplyDamage(totalDamage1);
                                            if (player.Hp > 0)
                                            {
                                                Console.WriteLine("What move should " + player.Name + " use next?");
                                                player.Moves.ForEach(item => Console.WriteLine(item.Name + " "));
                                            }

                                            break;


                                            //Made for Bulbasaurs' third move - unfortunately did not work. 
                                            //enemy.Name == bulbasaur does not find 'bulbasaur' as the same as the added Pokemon called Bulbasaur
                                            //In line 144, tried converting a Type Pokemon to a string, so it could be equaled to enemy.Name

                                        /*case 2:
                                            if(enemy.Name == bulbasaur)
                                            {
                                                Console.WriteLine(enemy.Name + " uses " + enemy.Moves[2].Name + ". ");

                                                int totalDamage2 = enemy.Attack(player);

                                                Console.WriteLine(player.Name + " loses " + totalDamage2 + " HP.");

                                                int applyDamage2 = player.ApplyDamage(totalDamage2);
                                                Console.WriteLine("What move should " + player.Name + " use next?");
                                                player.Moves.ForEach(item => Console.WriteLine(item.Name + " "));
                                            }

                                            else
                                            {
                                                Console.WriteLine("Move doesn't exist");
                                            }
                                            break;*/

                                        default:
                                            Console.WriteLine(enemy.Name + " didn't make a move.");

                                            Console.WriteLine("What move should " + player.Name + " use next?");
                                            player.Moves.ForEach(item => Console.WriteLine(item.Name + " "));

                                            break;
                                    }


                                    //print the move and damage
                                    //Console.WriteLine(enemy.Name + " uses " + enemy.Moves[enemyMove].Name + ". " + player.Name + " loses " + enemyDamage + " HP");
                                }
                            }
                            //The loop is over, so either we won or lost
                            if (enemy.Hp <= 0)
                            {
                                Console.WriteLine(enemy.Name + " faints, you won!");
                            }
                            else
                            {
                                Console.WriteLine(player.Name + " faints, you lost...");
                            }
                        }
                        //otherwise let's print an error message
                        else
                        {
                            Console.WriteLine("Invalid pokemons");
                        }
                        break;

                    case "heal":
                        roster.ForEach(pokemon => pokemon.Restore());
                        Console.WriteLine("All pokemons have been healed");
                        break;

                    case "quit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
