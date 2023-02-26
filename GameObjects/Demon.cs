using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalConsoleGame.GameObjects
{
    class Demon : Enemy
    {

        public Demon(Game game, int x, int y, int z, int health, GameWorld world) : base(game, x, y, z, health, world)
        {
            Game = game;
            X = x;
            Z = z;
            World = world;
            Health = health;
            Symbol = 'E';
            DisplaySymbol = Symbol;
            InteractNote = "You hit the enemy. It hit back. It doesn't seem weaker at all.";
            Note = $"An enemy. It seems to emit a demonic aura. You are not sure if you might kill it.";
            LootTable = Game.LootService.CreateLootTable("DemonHeart:0.1");
        }

        public override void Interact()
        {
            Game.Player.Health--;

            if (Health <= 0)
            {
                Game.LootService.Drop(LootTable, 1, 1);
                Game.Player.Kills++;
                Game.GameObjects.Remove(this);
                InteractNote = "You killed the enemy. You feel stronger than before.";
            }
            Game.UI.ShowInteractionNote(InteractNote);
        }

    }
}
