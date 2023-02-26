using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalConsoleGame.GameObjects
{
    class Campfire : GameObject
    {

        public int TotalUses { get; set; }
        public int UsesLeft { get; set; }

        public Campfire(Game game, int x, int y, int z, GameWorld world)
        {
            Random rndm = new Random();

            Game = game;
            X = x;
            Y = y;
            Z = z;
            World = world;
            TotalUses = rndm.Next(10, 25);
            UsesLeft = TotalUses;
            Symbol = 'C';
            DisplaySymbol = Symbol;
            Note = "A campfire. The flames are warm and full of energy.";
            InteractNote = "The heat is warming up your body. Some of your health has been restored.";
        }

        public override void Interact()
        {
            int usesLeftInPercent;

            if(Game.Player.Health + 1 <= Game.Player.MaxHealth)
            {
                Game.Player.Health++;
                UsesLeft--;
                if (UsesLeft <= 0)
                {
                    Game.GameObjects.Remove(this);
                    Game.UI.ShowInteractionNote("The campfire extinguished. The embers are still glowing a bit.");

                }

                usesLeftInPercent = (UsesLeft * 100) / TotalUses;

                if (usesLeftInPercent >= 70)
                {
                    Note = "A campfire. The flames are warm and full of energy.";
                }
                else if (usesLeftInPercent >= 50)
                {
                    Note = "A campfire. It crackles as the flames are blazing.";
                }
                else if (usesLeftInPercent >= 25)
                {
                    Note = "A campfire. You feel the warmth getting up to you.";
                }
                else if (usesLeftInPercent >= 10)
                {
                    Note = "A campfire. The flames are low as most of the wood is burnt.";
                }
                else if (usesLeftInPercent < 10)
                {
                    Note = "A campfire. The flames look weak about to extinguish.";
                }
            } else
            {
                Game.UI.ShowInteractionNote("You are already rested well.");
            }

        }

        public override void HandleInput(ConsoleKeyInfo key)
        {
            //Campfire does not handle input
        }
    }
}
