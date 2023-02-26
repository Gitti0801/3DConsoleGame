using System;
using System.Collections.Generic;
using System.Text;
using ThreeDimensionalConsoleGame.Exceptions;

namespace ThreeDimensionalConsoleGame.GameObjects
{
    public abstract class GameObject
    {
        // Position
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public char Symbol { get; set; }
        public char DisplaySymbol { get; set; }
        public String Note { get; set; }
        public String InteractNote { get; set; }
        public GameWorld World { get; set; }
        public Game Game { get; set; }

        // Update game state
        public virtual void Update()
        {
            if (Game.Player.Z != Z)
            {
                DisplaySymbol = '?';
            }
            else
            {
                DisplaySymbol = Symbol;
            }
        }

        public virtual void Interact()
        {
            Game.UI.ShowInteractionNote(InteractNote);
        }

        // Render game object
        public virtual void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(DisplaySymbol);
        }

        // Generates a new instance of the object
        public virtual void Generate()
        {
            new ObjectUngeneratableException(this + " can not be generated.");
        }

        // Handle user input
        public abstract void HandleInput(ConsoleKeyInfo key);

        // Move
        public virtual void Move(int x, int y, int z, GameWorld world)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.World = world;
        }

    }
}
