using ThreeDimensionalConsoleGame.GameObjects;
using ThreeDimensionalConsoleGame.UserInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalConsoleGame
{
    public class Game
    {
        public enum GameState
        {
            Running,
            Paused,
            Inventory
        }

        public UI UI { get; set; }
        public GameWorld World { get; set; }
        public Inventory Inventory { get; set; }
        public List<GameObject> GameObjects { get; set; }
        public Player Player { get; set; }
        public LootService LootService { get; set; }
        public ObjectGenerationService ObjectGenerationService {get; set; }
        public GameState State { get; set; }

        List<GameWorld> worlds = new List<GameWorld>();

        public GameWorld GetWorldByName(String name)
        {
            foreach(GameWorld current in worlds)
            {
                if(current.Name.Equals(name))
                {
                    return current;
                }
            }
            return null;
        }

        public void CreateWorld(String name, ConsoleColor fgColor, ConsoleColor bgColor, GameWorld.WorldType worldType)
        {
            if(GetWorldByName(name) == null)
            {
                worlds.Add(new GameWorld(this, name, fgColor, bgColor, worldType));
            }
        }

        public void CreateGameObject(GameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }

        public void Render()
        {
            Console.Clear();
            World.Update();
            World.Render();
            UI.RenderUI();
        }

        public Game()
        {
            GameObjects = new List<GameObject>();
            Player = new Player(this, 1, 1, 0, 10, 10, 'P', null);
            CreateGameObject(Player);
            CreateWorld("Overworld", ConsoleColor.White, ConsoleColor.Black, GameWorld.WorldType.Overworld);
            CreateWorld("Heaven", ConsoleColor.Black, ConsoleColor.White, GameWorld.WorldType.Heaven);
            CreateWorld("Hell", ConsoleColor.DarkRed, ConsoleColor.Black, GameWorld.WorldType.Hell);
            World = GetWorldByName("Overworld");
            Player.World = World;
            UI = new UI(this);
            Inventory = new Inventory(this);
            LootService = new LootService(this);
            ObjectGenerationService = new ObjectGenerationService(this);
            State = GameState.Running;
        }

    }
}
