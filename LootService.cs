using ThreeDimensionalConsoleGame.Items;
using ThreeDimensionalConsoleGame.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ThreeDimensionalConsoleGame
{
    public class LootService
    {

        public Game Game { get; }

        public LootService(Game game)
        {
            Game = game;
        }

        public Dictionary<Item, double> CreateLootTable(String args)
        {
            Dictionary<Item, double> lootTable = new Dictionary<Item, double>();
            String[] split = args.Split(';');
            String[] values; 

            foreach(String current in split)
            {
                try
                {
                    values = current.Split(':');
                    lootTable.Add((Item) Activator.CreateInstance(Type.GetType("ThreeDimensionalConsoleGame.Items." + values[0]), Game, 1), Double.Parse(values[1], CultureInfo.InvariantCulture));
                }
                catch (Exception)
                {
                }
            }
            return lootTable;
        }

        // Loot drops
        public void Drop(Dictionary<Item, double> lootTable, int minAmount, int maxAmount)
        {
            Random rndm = new Random();
            int amount = rndm.Next(minAmount, maxAmount);

            for (int i = 1; i <= amount; i++)
            {
                double random = rndm.NextDouble();
                foreach (KeyValuePair<Item, double> current in lootTable)
                {
                    if (random > current.Value)
                    {
                        random -= current.Value;
                    }
                    else
                    {
                        Game.Inventory.AddItem(current.Key);
                        break;
                    }
                }

            }
        }

    }
}
