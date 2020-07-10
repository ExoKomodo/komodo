using Komodo.Core.Physics;
using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Komodo.Core.ECS.Components
{
    /// <summary>
    /// Class defining static bodies.
    /// </summary>
    public class StaticBodyComponent : RigidBodyComponent
    {
        #region Public

        #region Constructors
        public StaticBodyComponent(IPhysicsShape shape)
        {
            Shape = shape;
        }
        #endregion

        #region Member Methods
        /// <summary>
        /// Initializes a StaticBodyComponent.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }
        #endregion

        #endregion
    }
}