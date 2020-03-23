using Komodo.Core.ECS.Components;

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
        #endregion Public Members

        #region Protected Members
        private bool _isInitialized { get; set; }
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public override void Update(GameTime gameTime)
        {
            if (!_isInitialized)
            {
                _isInitialized = true;
                var loadedTexture = Komodo.Core.Game.Content.Load<Texture2D>("player/idle/player_idle_01");
                if (ModelPath != null)
                {
                    Parent.AddComponent(
                        new Drawable3DComponent(ModelPath)
                        {
                            Texture = new Komodo.Core.Engine.Graphics.Texture(loadedTexture)
                        }
                    );
                }
                Parent.Scale = new Komodo.Lib.Math.Vector3(20f, 20f, 20f);
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