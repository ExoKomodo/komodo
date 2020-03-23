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
        public BoundingFrustum BoundingFrustum => new BoundingFrustum(Projection);
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
                if (value > 0 && value <=360)
                {
                    _fieldOfView = value;
                }
            }
        }
        public Matrix InverseViewMatrix => Matrix.Invert(ViewMatrix);
        public bool IsPerspective { get; set; }
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
        public Entity Target { get; set; }
        public Vector3 Up { get; set; }
        public Matrix ViewMatrix { get; internal set; }
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
        internal Matrix CalculateViewMatrix()
        {
            return Matrix.CreateLookAt(
                WorldPosition.MonoGameVector,
                Target == null ? (WorldPosition + Vector3.Forward).MonoGameVector : Target.Position.MonoGameVector,
                Up.MonoGameVector
            );
        }

        public ContainmentType Contains(Point point)
        {
            return Contains(new Vector2(point.ToVector2()));
        }

        public ContainmentType Contains(Vector2 vector)
        {
            return BoundingFrustum.Contains(new Vector3(vector.X, vector.Y, 0).MonoGameVector);
        }

        public ContainmentType Contains(Rectangle rectangle)
        {
            var max = new Vector3(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height, 0.5f);
            var min = new Vector3(rectangle.X, rectangle.Y, 0.5f);
            var boundingBox = new BoundingBox(min.MonoGameVector, max.MonoGameVector);
            return BoundingFrustum.Contains(boundingBox);
        }

        public void LookAt(Vector3 position)
        {
            var viewport = Game.GraphicsManager.ViewPort;
            Position = (
                position
                - new Vector3(
                    viewport.Width / 2f,
                    viewport.Height / 2f
                )
            );
        }

        public void Move(Vector3 direction)
        {
            Position += direction;
        }

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

        public Vector3 ScreenToWorld(float x, float y, float z)
        {
            return ScreenToWorld(new Vector3(x, y, z));
        }

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

        public Vector3 WorldToScreen(float x, float y, float z)
        {
            return WorldToScreen(new Vector3(x, y, z));
        }

        public Vector3 WorldToScreen(Vector3 worldPosition)
        {
            var viewport = Game.GraphicsManager.ViewPort;
            return Vector3.Transform(
                worldPosition + new Vector3(viewport.X, viewport.Y, 0f),
                ViewMatrix
            );
        }

        public void ZoomIn(float deltaZoom)
        {
            ClampZoom(Zoom + deltaZoom);
        }

        public void ZoomOut(float deltaZoom)
        {
            ClampZoom(Zoom - deltaZoom);
        }
        #endregion Public Member Methods

        #region Private Member Methods
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