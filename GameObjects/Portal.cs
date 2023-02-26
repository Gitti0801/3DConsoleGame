using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalConsoleGame.GameObjects
{
    class Portal : GameObject
    {

        public GameWorld Destination { get; set; }

        public Portal(Game game, int x, int y, int z, GameWorld world, char symbol, String note, String interactNote, GameWorld destination)
        {
            Game = game;
            X = x;
            Y = y;
            Z = z;
            World = world;
            Symbol = symbol;
            DisplaySymbol = symbol;
            Note = note;
            InteractNote = interactNote;
            Destination = destination;
        }

        public override void HandleInput(ConsoleKeyInfo key)
        {
            // Portal does not handle input
        }

        public override void Interact()
        {
            Game.Player.Move(Game.Player.X, Game.Player.Y, Game.Player.Z, Destination);
            Game.World = Destination;
            base.Interact();
            Game.Render();
        }
    }
}
