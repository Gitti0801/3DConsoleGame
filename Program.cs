
using ThreeDimensionalConsoleGame.GameObjects;
using ThreeDimensionalConsoleGame.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ThreeDimensionalConsoleGame.Game;

namespace ThreeDimensionalConsoleGame
{
    public class Program
    {

        static void Main(string[] args)
        {
            // Setup for game window
            Console.SetBufferSize(150, 40);
            Console.SetWindowSize(150, 40);
            Console.Title = "3D Console Game";
            Console.CursorVisible = false;

            // Create new game
            Game game = new Game();

            // Setup game components
            GameWorld world = game.World;
            Player player = game.Player;
            UI ui = game.UI;
            Inventory inventory = game.Inventory;

            // Setup for pause menu
            List<UIComponent> pauseList = new List<UIComponent>();
            pauseList.Add(new UIComponent("Continue...", 0, "continue"));
            pauseList.Add(new UIComponent("Quit...", 1, "quit"));
            UIComponentList pauseOptions = new UIComponentList(pauseList);

            // Add GameObjects
            game.ObjectGenerationService.GenerateObject(new Enemy(game, 0, 0, 0, 0, world));
            game.ObjectGenerationService.GenerateObject(new Angel(game, 0, 0, 0, 0, world));
            game.ObjectGenerationService.GenerateObject(new Demon(game, 0, 0, 0, 0, world));
            game.ObjectGenerationService.GenerateObject(new Tree(game, 0, 0, 0, 0, world));
            game.CreateGameObject(new Portal(game, 18, 18, 0, world, 'O', "A portal. You can hear demonic whispers trying to lure you in.", "You went through the portal. You can hear the screams of the tortured souls.", game.GetWorldByName("Hell")));
            game.CreateGameObject(new Portal(game, 20, 20, 0, world, 'O', "A portal. You can feel the celestial beings commanding you to stay away.", "You went through the portal. A strong light is flashing you.", game.GetWorldByName("Heaven")));
            game.CreateGameObject(new Portal(game, 19, 20, 0, game.GetWorldByName("Hell"), 'O', "A portal. You can hear birds singing on the other side.", "You went through the portal. You feel the grass under your feet", game.GetWorldByName("Overworld")));
            game.CreateGameObject(new Portal(game, 19, 20, 0, game.GetWorldByName("Heaven"), 'O', "A portal. You can hear birds singing on the other side.", "You went through the portal. You feel the grass under your feet", game.GetWorldByName("Overworld")));

            // Main game loop
            while (true)
            {
               if(game.State == GameState.Running)
                {
                    // Update world
                    world = game.World;
                    world.Update();

                    // Check if player touches the border
                    if (game.Player.X <= 0 || game.Player.X >= 21 || game.Player.Y <= 0 || game.Player.Y >= 21)
                    {
                        game.Player.X = game.Player.PreviousCoords[0];
                        game.Player.Y = game.Player.PreviousCoords[1];
                        game.Player.Z = game.Player.PreviousCoords[2];
                    }

                    // Render game state
                    Console.SetBufferSize(150, 40);
                    Console.SetWindowSize(150, 40);
                    Console.CursorVisible = false;
                    Console.Clear();
                    ui.RenderUI();
                    world.Render();

                    // Handle user input
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        game.State = GameState.Paused;
                    } else if(key.Key == ConsoleKey.B)
                    {
                        inventory.Update();
                        game.State = GameState.Inventory;
                    }
                    else
                    {
                        world.HandleInput(key);
                    }
                } else if(game.State == GameState.Paused)
                {
                    Console.Clear();
                    Console.WriteLine("o0o0o0o0o0o0o0o0o0o0o0o0o0o0o0o0o0o0");
                    Console.WriteLine(" ");
                    Console.WriteLine("GAME PAUSED");
                    pauseOptions.Render();
                    Console.WriteLine(" ");
                    Console.WriteLine("o0o0o0o0o0o0o0o0o0o0o0o0o0o0o0o0o0o0");
                    ConsoleKeyInfo key = Console.ReadKey();

                    if (key.Key == ConsoleKey.Escape)
                    {
                        game.State = GameState.Running;
                    } else if (key.Key == ConsoleKey.F)
                    { 
                        if(pauseOptions.Selected.Id == "continue")
                        {
                            game.State = GameState.Running;
                        } else if(pauseOptions.Selected.Id == "quit")
                        {
                            Environment.Exit(0);
                        }
                    } else  if(key.Key == ConsoleKey.Q)
                    {
                        Environment.Exit(0);
                    } else
                    {
                        pauseOptions.HandleInput(key);
                    }
                } else if(game.State == GameState.Inventory)
                {
                    Console.Clear();
                    inventory.Render();
                    ConsoleKeyInfo key = Console.ReadKey();

                    if(key.Key == ConsoleKey.B || key.Key == ConsoleKey.Escape)
                    {
                        game.State = GameState.Running;
                    } else
                    {
                        inventory.HandleInput(key);

                    }

                }
            }
        }
    }
}
