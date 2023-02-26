using System;
using System.Collections.Generic;
using System.Text;
using ThreeDimensionalConsoleGame.GameObjects;

namespace ThreeDimensionalConsoleGame
{
    public class ObjectGenerationService
    {

        Game Game { get; }

        public ObjectGenerationService(Game game)
        {
            this.Game = game;
        }

        public void GenerateObject(GameObject obj)
        {
            obj.Generate();
        }

    }
}
