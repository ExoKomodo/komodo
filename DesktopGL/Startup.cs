using System;
using Komodo.Behaviors;
using Komodo.Core;
using Komodo.Core.Engine.Entities;
using Komodo.Core.Engine.Input;

namespace Komodo
{
    public static class Startup
    {
        public static KomodoGame Game { get; private set; }
        [STAThread]
        static void Main()
        {
            using (Game = new KomodoGame()) {
                SetupInputs();

                var player1Entity = new Entity();
                player1Entity.AddComponent(new RootStartupBehavior(0));
                Game.ActiveScene.AddEntity(player1Entity);

                var player2Entity = new Entity();
                player2Entity.AddComponent(new RootStartupBehavior(1));
                Game.ActiveScene.AddEntity(player2Entity);

                Game.Run();
            }
        }

        static void SetupInputs()
        {
            InputManager.AddInputMapping("left", KomodoInputs.KeyLeft, 0);
            InputManager.AddInputMapping("right", KomodoInputs.KeyRight, 0);
            InputManager.AddInputMapping("up", KomodoInputs.KeyUp, 0);
            InputManager.AddInputMapping("down", KomodoInputs.KeyDown, 0);
            InputManager.AddInputMapping("sprint", KomodoInputs.KeyRightShift, 0);
            InputManager.AddInputMapping("quit", KomodoInputs.KeyEscape, 0);

            InputManager.AddInputMapping("left", KomodoInputs.KeyA, 1);
            InputManager.AddInputMapping("right", KomodoInputs.KeyD, 1);
            InputManager.AddInputMapping("up", KomodoInputs.KeyW, 1);
            InputManager.AddInputMapping("down", KomodoInputs.KeyS, 1);
            InputManager.AddInputMapping("sprint", KomodoInputs.KeyLeftShift, 1);
            InputManager.AddInputMapping("quit", KomodoInputs.KeyEscape, 1);
        }
    }
}
