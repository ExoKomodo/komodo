using Komodo.Core.ECS.Entities;
using Komodo.Lib.Math;

using BoundingBox = Microsoft.Xna.Framework.BoundingBox;
using BoundingFrustum = Microsoft.Xna.Framework.BoundingFrustum;
using ContainmentType = Microsoft.Xna.Framework.ContainmentType;
using Matrix = Microsoft.Xna.Framework.Matrix;
using MathHelper = Microsoft.Xna.Framework.MathHelper;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Komodo.Core.ECS.Components
{
    /// <summary>
    /// CameraComponent specifies either a perspective or orthographic camera. A CameraComponent will be used by a corresponding Komodo.Core.ECS.Systems.Render2DSystem and/or Komodo.Core.ECS.Systems.Render3DSystem to draw Component objects.
    /// </summary>
    public class CameraComponent : Component
    {
        #region Constructors
        public CameraComponent() : base(true, null)
        {
            Rotation = Vector3.Zero;
            Zoom = 1;
            Position = Vector3.Zero;
            IsPerspective = false;
            NearPlane = 1f;
            FarPlane = 2f;
            FieldOfView = 90f;
            Up = Vector3.Up;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        /// <summary>
        /// Provides a <see cref="Microsoft.Xna.Framework.BoundingFrustum"/> representing the projected space of the CameraComponent.
        /// </summary>
        public BoundingFrustum BoundingFrustum => new BoundingFrustum(Projection);
        
        /// <summary>
        /// Provides a <see cref="Microsoft.Xna.Framework.Rectangle"/> representing the projected space of the CameraComponent.
        /// </summary>
        public Rectangle BoundingRectangle
        {
            get
            {
                var frustum = BoundingFrustum;
                var corners = frustum.GetCorners();
                var topLeft = corners[0];
                var bottomRight = corners[2];
                var width = bottomRight.X - topLeft.X;
                var height = bottomRight.Y - topLeft.Y;
                return new Rectangle(
                    (int)topLeft.X,
                    (int)topLeft.Y,
                    (int)width,
                    (int)height
                );
            }
        }

        public Vector3 Center => WorldPosition + Origin;
        
        /// <summary>
        /// <see cref="MaximumZoom"/> defines the furthest distance a Component can be from the CameraComponent and still be rendered.
        /// </summary>
        public float FarPlane
        {
            get
            {
                return _farPlane;
            }
            set
            {
                if (value >= 1f)
                {
                    _farPlane = value;
                }
            }
        }

        public float FieldOfView
        {
            get
            {
                return _fieldOfView;
            }
            set
            {
                if (value > 0 && value <= 360)
                {
                    _fieldOfView = value;
                }
            }
        }

        public Matrix InverseViewMatrix => Matrix.Invert(ViewMatrix);

        public bool IsPerspective { get; set; }

        /// <summary>
        /// <see cref="MaximumZoom"/> defines the upper bound of how far the CameraComponent can zoom in.
        /// </summary>
        /// <remarks>
        /// If <see cref="MaximumZoom"/> is set to a value smaller than the current <see cref="Zoom"/> level, then <see cref="Zoom"/> will be clamped to the new <see cref="MaximumZoom"/>.
        /// </remarks>
        public float MaximumZoom
        {
            get
            {
                return _maximumZoom;
            }
            set
            {
                if (value >= 0)
                {
                    if (Zoom > value)
                    {
                        Zoom = value;
                    }
                    _maximumZoom = value;
                }

            }
        }

        /// <summary>
        /// <see cref="MinimumZoom"/> defines the upper bound of how far the CameraComponent can zoom out.
        /// </summary>
        /// <remarks>
        /// If <see cref="MinimumZoom"/> is set to a value larger than the current <see cref="Zoom"/> level, then <see cref="Zoom"/> will be clamped to the new <see cref="MinimumZoom"/>.
        /// </remarks>
        public float MinimumZoom
        {
            get
            {
                return _minimumZoom;
            }
            set
            {
                if (value >= 0)
                {
                    if (Zoom < value)
                    {
                        Zoom = MinimumZoom;
                    }
                    _minimumZoom = value;
                }

            }
        }

        /// <summary>
        /// <see cref="MaximumZoom"/> defines the closest distance a Component can be from the CameraComponent and still be rendered.
        /// </summary>
        public float NearPlane
        {
            get
            {
                return _nearPlane;
            }
            set
            {
                if (value >= 1f)
                {
                    _nearPlane = value;
                }
            }
        }

        public Vector3 Origin { get; set; }

        public Matrix Projection
        {
            get
            {
                var viewport = Game.GraphicsManager.ViewPort;
                if (IsPerspective)
                {
                    return Matrix.CreatePerspectiveFieldOfView(
                        MathHelper.ToRadians(FieldOfView),
                        viewport.Width / viewport.Height,
                        NearPlane,
                        FarPlane
                    );
                }
                else
                {
                    return Matrix.CreateTranslation(
                        -0.5f,
                        -0.5f,
                        0
                    ) * Matrix.CreateOrthographicOffCenter(
                        0,
                        viewport.Width,
                        viewport.Height,
                        0,
                        NearPlane,
                        FarPlane
                    );
                }
            }
        }

        /// <summary>
        /// <see cref="Target"/> defines the Komodo.Core.ECS.Entities.Entity that is followed by the CameraComponent.
        /// </summary>
        public Entity Target { get; set; }

        public Vector3 Up { get; set; }

        public Matrix ViewMatrix { get; internal set; }

        /// <summary>
        /// <see cref="Zoom"/> is the current zoom level of the CameraComponent. 
        /// </summary>
        /// <remarks>
        /// <see cref="Zoom"/> automatically clamps between <see cref="MaximumZoom"/> and <see cref="MinimumZoom"/> whenever <see cref="Zoom"/>, <see cref="MaximumZoom"/>, or <see cref="MinimumZoom"/> are updated.
        /// </remarks>
        public float Zoom
        {
            get
            {
                return _zoom;
            }
            set
            {
                if ((value >= MinimumZoom) && (value < MaximumZoom))
                {
                    _zoom = value;
                }
            }
        }
        #endregion Public Members

        #region Private Members
        private float _farPlane { get; set; }

        private float _fieldOfView { get; set; }

        private float _maximumZoom = float.MaxValue;

        private float _minimumZoom { get; set; }

        private float _nearPlane { get; set; }

        private float _zoom { get; set; }
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        /// <summary>
        /// Checks whether or not a <see cref="Microsoft.Xna.Framework.Point"/> is contained within the <see cref="BoundingFrustum"/> of the CameraComponent.
        /// </summary>
        public ContainmentType Contains(Point point)
        {
            return Contains(new Vector2(point.ToVector2()));
        }

        /// <summary>
        /// Checks whether or not a Komodo.Lib.Math.Vector2 is contained within the <see cref="BoundingFrustum"/> of the CameraComponent.
        /// </summary>
        public ContainmentType Contains(Vector2 vector)
        {
            return BoundingFrustum.Contains(new Vector3(vector.X, vector.Y, 0).MonoGameVector);
        }

        /// <summary>
        /// <see cref="Contains(Rectangle)"/> checks whether or not a <see cref="Microsoft.Xna.Framework.Rectangle"/> is contained within the <see cref="BoundingBox"/> of the CameraComponent.
        /// </summary>
        public ContainmentType Contains(Rectangle rectangle)
        {
            var max = new Vector3(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height, 0.5f);
            var min = new Vector3(rectangle.X, rectangle.Y, 0.5f);
            var boundingBox = new BoundingBox(min.MonoGameVector, max.MonoGameVector);
            return BoundingFrustum.Contains(boundingBox);
        }

        /// <summary>
        /// Moves the Component <see cref="Komodo.Core.ECS.Components.Component.Position"/> of the CameraComponent by the specified direction.
        /// </summary>
        /// <param name="direction">Direction and magnitude of the movement.</param>
        public void Move(Vector3 direction)
        {
            Position += direction;
        }

        /// <summary>
        /// Sets the CameraComponent as the active camera for the linked <see cref="Komodo.Core.ECS.Systems.Render2DSystem"/> and <see cref="Komodo.Core.ECS.Systems.Render3DSystem"/>.
        /// </summary>
        public void SetActive()
        {
            if (Parent?.Render2DSystem != null)
            {
                Parent.Render2DSystem.ActiveCamera = this;
            }
            if (Parent?.Render3DSystem != null)
            {
                Parent.Render3DSystem.ActiveCamera = this;
            }
        }

        /// <summary>
        /// Translates x, y, z from screen space to world space.
        /// </summary>
        /// <param name="x">X component of screen space.</param>
        /// <param name="y">Y component of screen space.</param>
        /// <param name="z">Z component of screen space.</param>
        /// <returns> Position in world space.</returns>
        public Vector3 ScreenToWorld(float x, float y, float z)
        {
            return ScreenToWorld(new Vector3(x, y, z));
        }

        /// <summary>
        /// Translates <see cref="Komodo.Lib.Math.Vector3"/> from screen space to world space.
        /// </summary>
        /// <param name="screenPosition">Position in screen space.</param>
        /// <returns> Position in world space.</returns>
        public Vector3 ScreenToWorld(Vector3 screenPosition)
        {
            var viewport = Game.GraphicsManager.ViewPort;
            return Vector3.Transform(
                (
                    screenPosition
                    - new Vector3(viewport.X, viewport.Y)
                ),
                InverseViewMatrix
            );
        }

        /// <summary>
        /// Translates x, y, z from world space to screen space.
        /// </summary>
        /// <param name="x">X component of world space.</param>
        /// <param name="y">Y component of world space.</param>
        /// <param name="z">Z component of world space.</param>
        /// <returns> Position in screen space.</returns>
        public Vector3 WorldToScreen(float x, float y, float z)
        {
            return WorldToScreen(new Vector3(x, y, z));
        }

        /// <summary>
        /// Translates x, y, z from world space to screen space.
        /// </summary>
        /// <param name="worldPosition">Position in world space.</param>
        /// <returns> Position in screen space.</returns>
        public Vector3 WorldToScreen(Vector3 worldPosition)
        {
            var viewport = Game.GraphicsManager.ViewPort;
            return Vector3.Transform(
                worldPosition + new Vector3(viewport.X, viewport.Y, 0f),
                ViewMatrix
            );
        }

        /// <summary>
        /// Zooms in the CameraComponent, clamping <see cref="Zoom"/> between <see cref="MaximumZoom"/> and <see cref="MinimumZoom"/>.
        /// </summary>
        /// <param name="deltaZoom">Amount to zoom the CameraComponent in by.</param>
        public void ZoomIn(float deltaZoom)
        {
            ClampZoom(Zoom + deltaZoom);
        }

        /// <summary>
        /// Zooms out the CameraComponent, clamping <see cref="Zoom"/> between <see cref="MaximumZoom"/> and <see cref="MinimumZoom"/>.
        /// </summary>
        /// <param name="deltaZoom">Amount to zoom the CameraComponent out by.</param>
        public void ZoomOut(float deltaZoom)
        {
            ClampZoom(Zoom - deltaZoom);
        }
        #endregion Public Member Methods

        #region Internal Member Methods
        /// <summary>
        /// Calculates the <see cref="ViewMatrix"/> by creating a look-at Matrix.
        /// </summary>
        /// <returns>A <see cref="Microsoft.Xna.Framework.Matrix"/> representing the View matrix of the CameraComponent.</returns>
        internal Matrix CalculateViewMatrix()
        {
            return Matrix.CreateLookAt(
                WorldPosition.MonoGameVector,
                Target == null ? (WorldPosition + Vector3.Forward).MonoGameVector : Target.Position.MonoGameVector,
                Up.MonoGameVector
            );
        }
        #endregion Internal Member Methods

        #region Private Member Methods
        /// <summary>
        /// Clamps <see cref="Zoom"/> between <see cref="MaximumZoom"/> and <see cref="MinimumZoom"/> based on the passed value.
        /// </summary>
        /// <param name="value"><see cref="Zoom"/> value to be tested. If the value is legal, <see cref="Zoom"/> will be set with the given value, otherwise <see cref="Zoom"/> will be clamped to between <see cref="MaximumZoom"/> or <see cref="MinimumZoom"/>.</param>
        private void ClampZoom(float value)
        {
            if (value < MinimumZoom)
            {
                Zoom = MinimumZoom;
            }
            else
            {
                Zoom = value > MaximumZoom ? MaximumZoom : value;
            }
        }
        #endregion Private Member Methods

        #endregion Member Methods
    }
}