using System;
using System.Collections.Generic;
using Common.Behaviors;
using Komodo.Core;
using Komodo.Core.ECS.Components;
using Komodo.Core.ECS.Entities;
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

                var player1Entity = new Entity(Game.ActiveScene);
                player1Entity.AddComponent(new RootStartupBehavior(0));
                var camera = new CameraComponent();
                player1Entity.AddComponent(camera);
                player1Entity.AddComponent(new CameraBehavior(camera, 0));
                camera.SetActive();

                var player2Entity = new Entity(Game.ActiveScene);
                player2Entity.AddComponent(new RootStartupBehavior(1));

                var counterEntity = new Entity(Game.ActiveScene);
                counterEntity.AddComponent(new FPSCounterStartupBehavior());

                var startupEntities = new List<Entity>
                {
                    player1Entity,
                    player2Entity,
                    counterEntity
                };

                // Startup entities will be attached to the active scene once the monogame initialization has occurred.
                // This allows the default shader to be created only after the graphics device has been initialized.
                Game.Run(startupEntities);
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

            InputManager.AddInputMapping("camera_left", KomodoInputs.KeyA, 0);
            InputManager.AddInputMapping("camera_right", KomodoInputs.KeyD, 0);
            InputManager.AddInputMapping("camera_up", KomodoInputs.KeyW, 0);
            InputManager.AddInputMapping("camera_down", KomodoInputs.KeyS, 0);
        }
    }
}
