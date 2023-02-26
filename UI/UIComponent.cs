using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalConsoleGame.UserInterface
{
    public class UIComponent
    {

        public String DisplayName { get; set; }
        public int Position { get; set; }
        public String Id { get; set; }

        public UIComponent(String displayName, int pos, String id)
        {
            DisplayName = displayName;
            Position = pos;
            Id = id;
        }

    }
}
