using System;
using Common.Behaviors;
using Komodo.Core;
using Komodo.Core.ECS.Components;
using Komodo.Core.ECS.Entities;
using Komodo.Core.Engine.Input;
using Komodo.Lib.Math;

namespace DesktopGL
{
    public static class Startup
    {
        public static Game Game { get; private set; }
        [STAThread]
        static void Main()
        {
            using (Game = new Game()) {
                SetupInputs();
                var render2DSystem = Game.CreateRender2DSystem();
                var render3DSystem = Game.CreateRender3DSystem();

                var player = new Entity(Game)
                {
                    Position = new Vector3(0f, 0f, 100f),
                    Render2DSystem = render2DSystem,
                    Render3DSystem = render3DSystem,
                };
                player.AddComponent(new PlayerBehavior(0));
                var cube = new Entity(Game)
                {
                    Position = new Vector3(0f, 0f, 0f),
                    Render3DSystem = render3DSystem,
                };
                cube.AddComponent(new CubeBehavior("models/cube"));
                var camera = new CameraComponent()
                {
                    Position = new Vector3(0, 0, 100f),
                    FarPlane = 10000000f,
                    IsPerspective = true,
                    Zoom = 1f,
                };
                player.AddComponent(camera);
                player.AddComponent(new CameraBehavior(camera, 0));
                camera.SetActive();

                render2DSystem = Game.CreateRender2DSystem();
                var counterEntity = new Entity(Game)
                {
                    Render2DSystem = render2DSystem,
                };
                counterEntity.AddComponent(new FPSCounterBehavior());
                var cameraEntity = new Entity(Game)
                {
                    Position = new Vector3(0f, 0f, 0f),
                    Render2DSystem = render2DSystem,
                };
                camera = new CameraComponent()
                {
                    FarPlane = 10000000f,
                    IsPerspective = false,
                    Position = new Vector3(0f, 0f, 100f),
                };
                cameraEntity.AddComponent(camera);
                camera.SetActive();

                Game.Run();
            }
        }

        static void SetupInputs()
        {
            InputManager.AddInputMapping("left", Inputs.KeyLeft, 0);
            InputManager.AddInputMapping("right", Inputs.KeyRight, 0);
            InputManager.AddInputMapping("up", Inputs.KeyUp, 0);
            InputManager.AddInputMapping("down", Inputs.KeyDown, 0);
            InputManager.AddInputMapping("sprint", Inputs.KeyRightShift, 0);
            InputManager.AddInputMapping("quit", Inputs.KeyEscape, 0);

            InputManager.AddInputMapping("camera_left", Inputs.KeyA, 0);
            InputManager.AddInputMapping("camera_right", Inputs.KeyD, 0);
            InputManager.AddInputMapping("camera_up", Inputs.KeyW, 0);
            InputManager.AddInputMapping("camera_down", Inputs.KeyS, 0);
            InputManager.AddInputMapping("camera_forward", Inputs.KeyE, 0);
            InputManager.AddInputMapping("camera_back", Inputs.KeyQ, 0);
        }
    }
}
