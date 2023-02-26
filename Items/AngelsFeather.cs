using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalConsoleGame.Items
{
    class AngelsFeather : Item
    {

        public AngelsFeather(Game game, int quantity) : base(game, quantity)
        {
            Name = "Angels Feather";
            Id = 3;
            Consumable = true;
            Ingredient = true;
            Description = "A shiny golden feather. It's razor sharp.";
        }

    }
}
