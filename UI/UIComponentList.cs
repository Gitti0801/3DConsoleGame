using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalConsoleGame.UserInterface
{
    public class UIComponentList
    {

        public List<UIComponent> Elements { get; set; }
        public UIComponent Selected { get; set; }

        public UIComponentList(List<UIComponent> list)
        {
            Elements = list;
            
            foreach(UIComponent current in Elements)
            {
                if (current.Position == 0)
                {
                    Selected = current;
                }
            }
        }

        public UIComponent GetElementByPosition(int pos)
        {
            foreach (UIComponent current in Elements)
            {
                if (current.Position == pos)
                {
                    return current;
                }
            }
            return null;
        }

        public void Select(UIComponent element)
        {
            foreach (UIComponent current in Elements)
            {
                if (current.Equals(element))
                {
                    Selected = current;
                }
            }
        }

        public void Select(int pos)
        {
            foreach (UIComponent current in Elements)
            {
                if (current.Position == pos)
                {
                    Selected = current;
                }
            }
        }

        public void Update()
        {

        }

        public void Render()
        {
            foreach(UIComponent current in Elements)
            {
                if(current.Equals(Selected))
                {
                    Console.WriteLine("> " + current.DisplayName + " <");
                } else
                {
                    Console.WriteLine(" " + current.DisplayName + "  ");
                } 
            }
        }

        public void HandleInput(ConsoleKeyInfo key)
        {
            switch(key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (Selected.Position - 1 < 0)
                    {
                        Select(Elements.Count - 1);
                    }
                    else
                    {
                        Select(Selected.Position - 1);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (Selected.Position + 1 > Elements.Count - 1)
                    {
                        Select(0);
                    }
                    else
                    {
                        Select(Selected.Position + 1);
                    }
                    break;
            }
        }

    }
}
