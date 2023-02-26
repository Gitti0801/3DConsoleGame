using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalConsoleGame.Items
{
    class DemonHeart : Item
    {

        public DemonHeart(Game game, int quantity) : base(game, quantity)
        {
            Name = "Demon Heart";
            Id = 4;
            Consumable = false;
            Ingredient = true;
            Description = "A pitch black heart that once kept alive a demon. It's still pulsating.";
        }

    }
}
