using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ThreeDimensionalConsoleGame.GameObjects;
using ThreeDimensionalConsoleGame.UserInterface;

namespace ThreeDimensionalConsoleGame
{
    public class GameWorld
    {
        // Create a getter and setter for GameWorld.UI
        public UI UI { get; set; }

        public enum WorldType
        {
            Overworld,
            Heaven,
            Hell
        }


        // Specifies where the frame should be
        char[,] frame =
        {
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', '#'},
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
        };

        // Game objects
        public List<GameObject> gameObjects;
        Game game;
        Player player;

        public String Name { get; }
        public ConsoleColor ForegroundColor { get; }
        public ConsoleColor BackgroundColor { get; }
        
        public GameWorld(Game game, String name, ConsoleColor fgColor, ConsoleColor bgColor, WorldType worldType)
        {
            this.game = game;
            player = game.Player;
            ForegroundColor = fgColor;
            BackgroundColor = bgColor;
            Name = name;
            gameObjects = game.GameObjects.ToList();
        }

        public GameObject GetObjectAt(int x, int y, int z, GameWorld world)
        {
            foreach (GameObject gameObject in game.GameObjects)
            {
                if (gameObject.World == world && gameObject.X == x && gameObject.Y == y && gameObject.Z == z)
                {
                    if(gameObject.GetType() != typeof(Player))
                    {
                        return gameObject;
                    }
                }
            }
            return null;
        }

        public GameObject GetCollidingObject()
        {
            GameObject collidingObject = GetObjectAt(player.X, player.Y, player.Z, this);

            if (collidingObject != null)
            {
                return collidingObject;
            }
            return null;
        }

        // Update game state
        public void Update()
        {
            // Update gameObjects list
            gameObjects.Clear();
            foreach(GameObject current in game.GameObjects)
            {
                if(current.World == this)
                {
                    gameObjects.Add(current);
                }
            }

            // Update each game object
            foreach (var current in gameObjects)
            {
                current.Update();
            }

            // Check if player and enemy are colliding
            if (GetCollidingObject() != null)
            {
                GameObject obj = GetCollidingObject();
            }
        }

        // Render game state
        public void Render()
        {

            //Render frame
            for(int y = 0; y <= 21; y++)
            {
                for(int x = 0; x <= 21; x++)
                {
                    if(frame[x, y].Equals('#'))
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("#");
                    }
                }
            }

            // Set colors
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = ForegroundColor;

            List<GameObject> sortedList = gameObjects.OrderBy(o => o.Z).ToList();

            // Render each game object
            foreach (var current in sortedList)
            {
                if (current.World.Equals(this))
                {
                    current.Render();
                }
            }
        }

        // Handle user input
        public void HandleInput(ConsoleKeyInfo key)

        {
            // Handle input for each game object
            foreach (var gameObject in gameObjects.ToList())
            {
                gameObject.HandleInput(key);
            }
        }

    }
}
