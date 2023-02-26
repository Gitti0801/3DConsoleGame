using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalConsoleGame.Items
{
    public abstract class Item
    {

        public Game Game { get; set; }
        public String Name { get; set; }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public bool Consumable { get; set; }
        public bool Ingredient { get; set; }
        public String Description { get; set; }

        public Item(Game game, int quantity)
        {
            Quantity = quantity;
            Game = game;
        }

        public virtual void Use()
        {
            if(Consumable)
            {
                Quantity--;
            }
            else
            {

            }
        }
    }
}
