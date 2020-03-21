using System;
using System.Collections.Generic;
using Common.Behaviors;
using Komodo.Core;
using Komodo.Core.ECS.Components;
using Komodo.Core.ECS.Entities;
using Komodo.Core.ECS.Scenes;
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

                // Perspective scene
                var player1Entity = new Entity(Game.ActiveScene)
                {
                    Position = new KomodoVector3(0f, 0f, 0f),
                };
                player1Entity.AddComponent(new PlayerBehavior(0));
                var player2Entity = new Entity(Game.ActiveScene)
                {
                    Position = new KomodoVector3(0f, 0f, 0f),
                };
                player2Entity.AddComponent(new CubeBehavior("models/cube"));
                var cameraEntity = new Entity(Game.ActiveScene)
                {
                    Position = new KomodoVector3(0f, 0f, 200f)
                };
                var camera = new CameraComponent()
                {
                    Position = new KomodoVector3(0, 0, 100f),
                    FarPlane = 10000000f,
                    IsPerspective = true,
                    Zoom = 1f,
                    Target = player1Entity
                };
                cameraEntity.AddComponent(new CameraBehavior(camera, 0));
                cameraEntity.AddComponent(camera);
                camera.SetActive();

                // Orthographic scene
                var orthographicScene = new Scene(Game);
                Game.ActiveScene.Children.Add(orthographicScene);
                var counterEntity = new Entity(orthographicScene);
                counterEntity.AddComponent(new FPSCounterBehavior());

                cameraEntity = new Entity(orthographicScene)
                {
                    Position = new KomodoVector3(0f, 0f, 0f),
                };
                camera = new CameraComponent()
                {
                    Position = new KomodoVector3(0f, 0f, 100f),
                    FarPlane = 1000f,
                    IsPerspective = false
                };
                cameraEntity.AddComponent(camera);
                camera.SetActive();

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

            InputManager.AddInputMapping("camera_left", KomodoInputs.KeyA, 0);
            InputManager.AddInputMapping("camera_right", KomodoInputs.KeyD, 0);
            InputManager.AddInputMapping("camera_up", KomodoInputs.KeyW, 0);
            InputManager.AddInputMapping("camera_down", KomodoInputs.KeyS, 0);
            InputManager.AddInputMapping("camera_forward", KomodoInputs.KeyE, 0);
            InputManager.AddInputMapping("camera_back", KomodoInputs.KeyQ, 0);
        }
    }
}
