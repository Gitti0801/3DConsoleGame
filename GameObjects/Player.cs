using ThreeDimensionalConsoleGame.UserInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalConsoleGame.GameObjects
{
    public class Player : GameObject
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public UI PlayerUI { get; set; }
        public int Kills { get; set; }
        public int[] PreviousCoords { get; set; }

        public Player(Game game, int x, int y, int z, int maxHealth, int health, char symbol, GameWorld world)
        {
            Kills = 0;
            InteractNote = "No idea how you interacted with... well, yourself.";
            X = x;
            Y = y;
            Z = z;
            MaxHealth = maxHealth;
            Health = health;
            Symbol = symbol;
            DisplaySymbol = symbol;
            World = world;
            Game = game;
            PreviousCoords = new int[3]
            {
                1, 1, 0
            };
        }

        public override void Update()
        {
            // Update player state
        }

        public override void HandleInput(ConsoleKeyInfo key)
        {
            PreviousCoords[0] = X;
            PreviousCoords[1] = Y;
            PreviousCoords[2] = Z;

            // Handle user input
            switch(key.Key)
            {
                case ConsoleKey.W:
                    Y--;
                    break;
                case ConsoleKey.A:
                    X--;
                    break;
                case ConsoleKey.S:
                    Y++;
                    break;
                case ConsoleKey.D:
                    X++;
                    break;
                case ConsoleKey.Q:
                    Z--;
                    break;
                case ConsoleKey.E:
                    Z++;
                    break;
                case ConsoleKey.F:
                    GameObject obj = World.GetCollidingObject();
                    if (obj != null)
                    {
                        obj.Interact();
                    }
                    break;
                case ConsoleKey.P:
                    Random rndm = new Random();
                    int random = rndm.Next(1, 4);

                    if(random == 1)
                    {
                        Game.ObjectGenerationService.GenerateObject(new Enemy(Game, 0, 0, 0, 0, World));
                    } else if(random == 2)
                    {
                        Game.ObjectGenerationService.GenerateObject(new Angel(Game, 0, 0, 0, 0, World));
                    } else if(random == 3)
                    {
                        Game.ObjectGenerationService.GenerateObject(new Demon(Game, 0, 0, 0, 0, World));
                    } else
                    {
                        Game.ObjectGenerationService.GenerateObject(new Tree(Game, 0, 0, 0, 0, World));
                    }
                    break;
            }
        }

        public override void Interact()
        {
            // Player can't be interacted with
            base.Interact();
        }
    }
}
