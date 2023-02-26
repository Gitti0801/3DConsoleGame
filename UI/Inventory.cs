using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreeDimensionalConsoleGame.Items;

namespace ThreeDimensionalConsoleGame.UserInterface
{
    public class Inventory
    {

        public List<Item> Items { get; set; }
        public UIComponentList SelectedList { get; set; }
        public UIComponentList ItemList { get; set; }
        public Game Game { get; set; }

        public Inventory(Game game)
        {
            Game = game;
            Items = new List<Item>();

            Items.Add(new Wood(Game, 3));
            Items.Add(new AngelsFeather(Game, 3));
            Items.Add(new DemonHeart(Game, 3));
            Items.Add(new CampfireItem(Game, 3));

            Items = Items.OrderBy(x => x.Name).ToList();
            List<UIComponent> items = new List<UIComponent>();
            int pos = 0;

            foreach(Item current in Items)
            {
                if(current.Quantity > 0)
                {
                    items.Add(new UIComponent(current.Name + " - " + current.Quantity + "x", pos, current.Name));
                    pos++;
                }
            }

            if(items.Count > 0)
            {
                ItemList = new UIComponentList(items);
                SelectedList = ItemList;
            }
        }

        public Item GetItemByName(String name)
        {
            foreach(Item current in Items)
            {
                if(current.Name.Equals(name))
                {
                    return current;
                }
            }
            return null;
        }

        public Item GetItemById(int id)
        {
            foreach (Item current in Items)
            {
                if (current.Id.Equals(id))
                {
                    return current;
                }
            }
            return null;
        }

        public void AddItem(Item item)
        {
            Item target = GetItemById(item.Id);

            target.Quantity += item.Quantity;
        }

        public void RemoveItem(Item item, int amount)
        {
            Item target = GetItemById(item.Id);

            target.Quantity -= item.Quantity;
        }

        public void RemoveItem(String name, int amount)
        {
            Item target = GetItemByName(name);

            target.Quantity -= amount;
        }

        public void Update()
        {
            Items = Items.OrderBy(x => x.Name).ToList();
            List<UIComponent> items = new List<UIComponent>();
            int pos = 0;

            foreach (Item current in Items)
            {
                if (current.Quantity > 0)
                {
                    items.Add(new UIComponent(current.Name + " - " + current.Quantity + "x", pos, current.Name));
                    pos++;
                }
            }
            ItemList = new UIComponentList(items);
            SelectedList = ItemList;
        }

        public void Render()
        {
            Console.WriteLine("INVENTORY");
            Console.WriteLine(" ");
            if(ItemList.Elements.Count > 0)
            {
                ItemList.Render();
                Console.WriteLine(" ");
                Console.WriteLine(GetItemByName(ItemList.Selected.Id).Description);
            }
        }

        public void HandleInput(ConsoleKeyInfo key)
        {
            if(ItemList != null)
            {
                switch (key.Key)
                {
                    case ConsoleKey.F:
                        if(SelectedList.Equals(ItemList))
                        {
                            if(ItemList.Elements.Count > 0)
                            {
                                GetItemByName(SelectedList.Selected.Id).Use();
                                Game.State = Game.GameState.Running;
                            }
                        }
                        break;
                    default:
                        ItemList.HandleInput(key);
                        break;
                }
            }
        }
    }
}
