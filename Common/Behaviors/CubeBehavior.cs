using Komodo.Core.ECS.Components;
using Komodo.Core.Engine.Graphics;
using Komodo.Lib.Math;
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
                RootComponent = new Drawable3DComponent(ModelPath);
                Parent.AddComponent(RootComponent);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!_createdBoxes)
            {
                _createdBoxes = true;
                var component = new Drawable3DComponent(RootComponent.ModelData);
                var model = component.ModelData;
                float scale = 20f;
                for (int i = 0; i < 50; ++i)
                {
                    for (int j = 0; j < 20; ++j)
                    {
                        Parent.AddComponent(
                            new Drawable3DComponent(model)
                            {
                                Position = new Vector3(50f * i, 50f * j, 0f)
                            }
                        );
                    }
                }
                Parent.Scale = new Vector3(scale, scale, scale);
            }
        }
        #endregion Public Member Methods

        #region Protected Member Methods
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}
