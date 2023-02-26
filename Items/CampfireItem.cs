using ThreeDimensionalConsoleGame.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalConsoleGame.Items
{
    class CampfireItem : Item
    {

        public CampfireItem(Game game, int quantity) : base(game, quantity)
        {
            Name = "Campfire";
            Id = 5;
            Consumable = true;
            Ingredient = false;
            Description = "A campfire, ready to be placed.";
        }

        public override void Use()
        {
            if(Game.World.GetCollidingObject() == null)
            {
                Quantity--;
                Game.CreateGameObject(new Campfire(Game, Game.Player.X, Game.Player.Y, Game.Player.Z, Game.World));
                Game.UI.ShowInteractionNote("You placed your campfire.");
            } else
            {
                Game.UI.ShowInteractionNote("You can't place that here.");
            }
        }

    }
}
