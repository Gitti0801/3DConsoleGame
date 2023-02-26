using ThreeDimensionalConsoleGame.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreeDimensionalConsoleGame.UserInterface
{
    public class UI
    {
        GameWorld World;
        Game Game;
        String interaction = " ";
        Thread interactionThread;

        public UI(Game game)
        {
            World = game.World;
            Game = game;
        }

        private void HideInteractionNote()
        {
            try

            {
                Thread.Sleep(3000);
                interaction = " ";
                Game.Render();
            }
            catch (ThreadInterruptedException)
            {

            }
        }

        public void ShowInteractionNote(String note)
        {

            if(interactionThread != null)
            {
                interactionThread.Interrupt();
            }

            interaction = note;
            Thread thread = new Thread(new ThreadStart(HideInteractionNote));
            interactionThread = thread;
            thread.Start();
        }

        public void RenderUI()
        {
            World = Game.World;
            int nearestFrontObj = 100000;
            int nearestBackObj = 0;
            char frontChar = ' ';
            char backChar = ' ';
            char collidingChar = ' ';
            String note = "";
            GameObject colliding = World.GetCollidingObject();

            if(colliding != null)
            {
                collidingChar = colliding.Symbol;
                note = colliding.Note;
            } else
            {
                note = "";
                collidingChar = ' ';
            }

            foreach (GameObject obj in World.gameObjects)
            {
                if (obj.GetType() != typeof(Player))
                {
                    if (Game.Player.X == obj.X && Game.Player.Y == obj.Y)
                    {
                        if (obj.Z > Game.Player.Z)
                        {
                            if (Game.Player.Z - obj.Z < nearestFrontObj)
                            {
                                nearestBackObj = obj.Z;
                                backChar = obj.Symbol;
                            }
                        }
                        else if (obj.Z < Game.Player.Z)
                        {
                            if (Game.Player.Z - obj.Z > nearestBackObj)
                            {
                                nearestFrontObj = obj.Z;
                                frontChar = obj.Symbol;
                            }
                        }
                        else
                        {

                        }
                    }
                }
            }

            Console.SetCursorPosition(50, 0);
            Console.Write($"X: {Game.Player.X}");

            Console.SetCursorPosition(50, 1);
            Console.Write($"Y: {Game.Player.Y}");

            Console.SetCursorPosition(50, 2);
            Console.Write($"Z: {Game.Player.Z}");

            Console.SetCursorPosition(50, 4);
            Console.Write($"Health: {Game.Player.Health}");

            Console.SetCursorPosition(50, 5);
            Console.Write($"Kills: {Game.Player.Kills}");

            Console.SetCursorPosition(50, 7);
            Console.Write($"Front: {frontChar}");

            Console.SetCursorPosition(50, 8);
            Console.Write($"Colliding: {collidingChar}");

            Console.SetCursorPosition(50, 9);
            Console.Write($"Back: {backChar}");

            Console.SetCursorPosition(50, 11);
            Console.Write($"Note: {note}");

            Console.SetCursorPosition(50, 13);
            Console.Write(interaction);
        }

    }
}
