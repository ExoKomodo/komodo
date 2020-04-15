using Komodo.Core.ECS.Components;
using Komodo.Core.Physics;
using Komodo.Lib.Math;

using Color = Microsoft.Xna.Framework.Color;
using GameTime = Microsoft.Xna.Framework.GameTime;

using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

namespace Common.Behaviors
{
    public class CubeBehavior : BehaviorComponent
    {
        #region Constructors
        public CubeBehavior(string modelPath) : base()
        {
            ModelPath = modelPath;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public string ModelPath { get; protected set; }
        public Drawable3DComponent RootComponent { get; protected set; }
        #endregion Public Members

        #region Protected Members
        private bool _createdBoxes { get; set; }
        #endregion Protected Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods

        public override void Initialize()
        {
            base.Initialize();

            if (ModelPath != null)
            {
                RootComponent = new Drawable3DComponent(ModelPath)
                {
                    TexturePath = "player/idle/player_idle_01"
                };
                Parent.AddComponent(RootComponent);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!_createdBoxes)
            {
                _createdBoxes = true;
                var scale = Vector3.One * 20f;
                for (int i = 0; i < 10; i++)
                {
                    Parent.AddComponent(
                        new Drawable3DComponent(RootComponent.ModelData)
                        {
                            Position = new Vector3(i + 5, 0f, 0f) * scale.X,
                            Scale = scale
                        }
                    );
                }
                var material = new PhysicsMaterial("box")
                {
                    Friction = 0.8f
                };
                Parent.AddComponent(
                    new StaticBodyComponent(new Box(2f, 2f, 2f, 1f))
                    {
                        Material = material,
                    }
                );
                Parent.Scale = scale;
            }
        }
        #endregion Public Member Methods

        #endregion Member Methods
    }
}
