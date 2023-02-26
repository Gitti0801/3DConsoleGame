using ThreeDimensionalConsoleGame.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalConsoleGame.GameObjects
{
    class Enemy : GameObject
    {
        public int Health { get; set; }
        public Dictionary<Item, double> LootTable { get; set; }

        public Enemy(Game game, int x, int y, int z, int health, GameWorld world)
        {
            Game = game;
            X = x;
            Y = y;
            Z = z;
            World = world;
            Health = health;
            Symbol = 'E';
            DisplaySymbol = Symbol;
            InteractNote = "You hit the enemy. It seems weaker now...";
            Note = $"An enemy. It doesn't seem to have noticed you yet...";
            LootTable = Game.LootService.CreateLootTable("");
        }


        public override void HandleInput(ConsoleKeyInfo key)
        {
            // Enemies do not handle input
        }

        public override void Interact()
        {
            Health--;
            Note = $"An enemy. You might kill it if you attack it {Health} more times...";

            if (Health <= 0)
            {
                Game.Player.Kills++;
                Game.GameObjects.Remove(this);
                Game.LootService.Drop(LootTable, 1, 1);
                InteractNote = "You killed the enemy. You feel stronger than before.";
            }
            base.Interact();
        }

        public override void Generate()
        {
            Random rndm = new Random();

            X = rndm.Next(1, 20);
            Y = rndm.Next(1, 20);
            Z = rndm.Next(-20, 20);
            Health = rndm.Next(5, 15);
            Game.CreateGameObject(this);
        }
    }
}
