![](https://github.com/ExoKomodo/Komodo/workflows/.NET%20Core/badge.svg)
# Komodo
Komodo was spawned out of a desire to learn popular game engine design, like composition over inheritance and ECS. Komodo is an attempt at making an engine that places the developer first, providing simple control over 2D and 3D game development.

## Links
* [Nuget Package](https://www.nuget.org/packages/Komodo)
* [Templates Package](https://www.nuget.org/packages/Komodo.Templates)
* [Documentation](https://exokomodo.github.io/Komodo/docs)
* [Discord](https://discord.gg/2g6dftW)
* [Reddit](https://www.reddit.com/r/komodoengine)

## Usage
The recommended way to start with Komodo is by using a project template found in the [Komodo.Templates package](https://www.nuget.org/packages/Komodo.Templates).

The project layout generally consists of two or more projects.
1. One or multiple `<Platform>` projects (such as `DesktopGL`) which consists of platform-specific and creation of starting entities.
2. `Common` project where all major game logic should reside.

### Content Pipeline
A Komodo project also will need a `Content` directory in the top-level directory of the project for placing assets and the MonoGame mgcb file. Komodo users will need to use the MonoGame Content Pipeline for compiling assets. Releases can be found [here](https://github.com/MonoGame/MonoGame/releases) and a tutorial can be found [here](http://rbwhitaker.wikidot.com/monogame-managing-content). Ignore the sections detailing the code needed to load in the asset files, as Komodo will do this for you given a path to an applicable asset for [SpriteComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_sprite_component.html), [TextComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_text_component.html), [Drawable3DComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_drawable3_d_component.html), and [SoundComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_sound_component.html).

### Platform Project
In each platform project, a [Game](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_game.html) instance needs to be created. Once [Game.Run()](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_game.html) is called, control will not come back to the `Startup` class, so make sure at least one [Entity](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_entities_1_1_entity.html) with a [BehaviorComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_behavior_component.html).

A suggested pattern involves creating a [Game](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_game.html) instance, setting up platform-specific default inputs, and creating a root [Entity](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_entities_1_1_entity.html) with a root [BehaviorComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_behavior_component.html) that will generate all the starting entities and their components.

```c#
using DesktopGL.Behaviors;
using Komodo.Core;
using Komodo.Core.ECS.Entities;
using Komodo.Core.Engine.Input;

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

                var rootEntity = new Entity(Game);
                rootEntity.AddComponent(new StartupBehaviorComponent());

                Game.Run();
            }
        }

        private static void SetupInputs()
        {
            InputManager.AddInputMapping("left", Inputs.KeyLeft, 0);
            InputManager.AddInputMapping("right", Inputs.KeyRight, 0);
            InputManager.AddInputMapping("up", Inputs.KeyUp, 0);
            InputManager.AddInputMapping("down", Inputs.KeyDown, 0);
            InputManager.AddInputMapping("quit", Inputs.KeyEscape, 0);
        }
    }
}
```

If a `Common` project is being used, the `<Platform>` project should rarely be more complicated than this. Consider including graphics configuration code to the `<Platform>` project, selecting a resolution, whether or not to display fullscreen, etc.

### Common Project
The `Common` project is where the majority of the game will be created through [BehaviorComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_behavior_component.html)s. 

[BehaviorComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_behavior_component.html)s generally will initialize the content for an [Entity](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_entities_1_1_entity.html), loading the content from disk or generating the assets programatically.

Once initialized, a [BehaviorComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_behavior_component.html)s will continue to receive [Update(GameTime gametime)](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_behavior_component.html#a8d118766e050d90cca9ea8413ac0436a) calls unless disabled, allowing the [BehaviorComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_behavior_component.html) to continue interacting with other entities and components.

Here is an example [BehaviorComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_behavior_component.html) which creates an FPS counter as a [TextComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_text_component.html). This example assumes a [CameraComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_camera_component.html) and a [Render2DSystem](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_systems_1_1_render2_d_system.html) are also a part of the parent [Entity](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_entities_1_1_entity.html) of the `FPSCounterBehavior`.

```c#
using Komodo.Core.ECS.Components;
using Komodo.Lib.Math;
using System;

using Color = Microsoft.Xna.Framework.Color;
using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Common.Behaviors
{
    public class FPSCounterBehavior : BehaviorComponent
    {
        public TextComponent CounterText { get; set; }

        public override void Initialize()
        {
            base.Initialize();

            CounterText = new TextComponent(
                "fonts/font",
                Color.Black,
                Game.DefaultSpriteShader,
                ""
            )
            {
                Position = Vector3.Zero
            };
            Parent.AddComponent(CounterText);
        }

        public override void Update(GameTime gameTime)
        {
            CounterText.Text = $"{Math.Round(Game.FramesPerSecond)} FPS";
        }
    }
}
```

## Cameras and Render Systems
All [Entity](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_entities_1_1_entity.html) objects which have components which can be rendered must have either a [Render2DSystem](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_systems_1_1_render2_d_system.html) or [Render3DSystem](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_systems_1_1_render3_d_system.html) referenced by them.

* [Render2DSystem](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_systems_1_1_render2_d_system.html) is necessary for rendering all [Drawable2DComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_drawable2_d_component.html) objects: [SpriteComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_sprite_component.html) and [TextComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_text_component.html)
* [Render3DSystem](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_systems_1_1_render3_d_system.html) is necessary for rendering all [Drawable3DComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_drawable3_d_component.html) objects.

If an [Entity](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_entities_1_1_entity.html) will have a [TextComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_text_component.html), it will also need a [Render2DSystem](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_systems_1_1_render2_d_system.html).

If an [Entity](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_entities_1_1_entity.html) will have a [Drawable3DComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_drawable3_d_component.html), it will also need a [Render3DSystem](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_systems_1_1_render3_d_system.html).

If an [Entity](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_entities_1_1_entity.html) has both a [TextComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_text_component.html) and a [Drawable3DComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_drawable3_d_component.html), it would need both a [Render2DSystem](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_systems_1_1_render2_d_system.html) and a [Render3DSystem](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_systems_1_1_render3_d_system.html).

Each [Render2DSystem](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_systems_1_1_render2_d_system.html) or [Render3DSystem](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_systems_1_1_render3_d_system.html) renders using a single [CameraComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_camera_component.html). A [CameraComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_camera_component.html) is set as the active camera for it's parent [Entity](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_entities_1_1_entity.html) by calling [CameraComponent.SetActive()](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_camera_component.html#afcaa5c97cb6b9be2719406bcc22e310c). This member method will set the [CameraComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_camera_component.html) as the active camera for the [Entity](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_entities_1_1_entity.html)'s [Render2DSystem](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_systems_1_1_render2_d_system.html) and [Render3DSystem](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_systems_1_1_render3_d_system.html).

It is not necessary to create a [CameraComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_camera_component.html) for each [Entity](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_entities_1_1_entity.html), as sharing the [Render2DSystem](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_systems_1_1_render2_d_system.html) and [Render3DSystem](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_systems_1_1_render3_d_system.html) between [Entity](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_entities_1_1_entity.html) objects will cause them to render with the same [CameraComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_camera_component.html).

By having the flexibility to use a different [CameraComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_camera_component.html) per entity, UIs can be easily drawn without relation to the [CameraComponent](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_components_1_1_camera_component.html) folowing a player.

```c#
// Render systems for the perspective scene
var render2DSystem = Game.CreateRender2DSystem();
var render3DSystem = Game.CreateRender3DSystem();

// An entity with a SpriteComponent will need a Render2DSystem
var playerSpriteEntity = new Entity(Game)
{
    Position = new Vector3(0f, 0f, 0f),
    Render2DSystem = render2DSystem,
};
playerSpriteEntity.AddComponent(new PlayerBehavior(0));

// An entity with a Drawable3DComponent will need a Render3DSystem
var cubeEntity = new Entity(Game)
{
    Position = new Vector3(20f, 0f, 0f),
    Render3DSystem = render3DSystem,
};
cubeEntity.AddComponent(new CubeBehavior());

// Pass in both the 2D and 3D render systems to the perspective camera.
var perspectiveCameraEntity = new Entity(Game)
{
    Position = new Vector3(0f, 0f, 200f),
    Render2DSystem = render2DSystem,
    Render3DSystem = render3DSystem,
};
var perspectiveCamera = new CameraComponent()
{
    Position = new Vector3(0, 0, 0f),
    FarPlane = 10000000f,
    IsPerspective = true,
    Zoom = 1f,
    // Will point at the playerSpriteEntity as both the camera and the playerSpriteEntity move
    Target = playerSpriteEntity,
};
perspectiveCameraEntity.AddComponent(perspectiveCamera);
perspectiveCameraEntity.AddComponent(new CameraBehavior(perspectiveCamera));
// Sets the camera as the active camera for the render systems
perspectiveCamera.SetActive();

// Create a new Render2DSystem for the UI scene
render2DSystem = Game.CreateRender2DSystem();
var fpsCounterEntity = new Entity(Game)
{
    Render2DSystem = render2DSystem,
};
fpsCounterEntity.AddComponent(new FPSCounterBehavior());
var orthographicCameraEntity = new Entity(Game)
{
    Position = new Vector3(0f, 0f, 0f),
    Render2DSystem = render2DSystem,
};
var orthographicCamera = new CameraComponent()
{
    FarPlane = 10000000f,
    IsPerspective = false,
    Position = new Vector3(0f, 0f, 100f),
};
orthographicCameraEntity.AddComponent(orthographicCamera);
orthographicCamera.SetActive();
```

This setup will render the FPS counter without regard for the position of the entities with the `perspectiveCamera`. Using multiple render systems allows for segmented management of how [Entity](https://exokomodo.github.io/Komodo/docs/class_komodo_1_1_core_1_1_e_c_s_1_1_entities_1_1_entity.html) objects should be individually rendered.