using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalConsoleGame.Items
{
    class Wood : Item
    {

        public Wood(Game game, int quantity) : base(game, quantity)
        {
            Name = "Wood";
            Id = 1;
            Consumable = false;
            Ingredient = true;
            Description = "A piece of wood. It seems really sturdy.";
        }

    }
}
