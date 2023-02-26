using ThreeDimensionalConsoleGame.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalConsoleGame.GameObjects
{
    public class Tree : GameObject
    {

        public int Health { get; set; }
        public Dictionary<Item, double> LootTable { get; set; }
        public Tree(Game game, int x, int y, int z, int health, GameWorld world)
        {
            Game = game;
            X = x;
            Y = y;
            Z = z;
            Health = health;
            World = world;
            Symbol = 'T';
            DisplaySymbol = Symbol;
            InteractNote = "You hit the tree. It shakes and seems thinner...";
            Note = $"A tree. You might be able to chop it down...";
            LootTable = Game.LootService.CreateLootTable("Wood:1.0");
        }

        public override void HandleInput(ConsoleKeyInfo key)
        {
            // Tree does not handle input
        }

        public override void Interact()
        {
            Health--;
            Note = $"A tree. You might chop it down if you hit it {Health} more times...";

            if (Health <= 0)
            {
                Game.GameObjects.Remove(this);
                InteractNote = "You chopped down the tree. You got some wood.";
                Game.LootService.Drop(LootTable, 1, 2);
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
