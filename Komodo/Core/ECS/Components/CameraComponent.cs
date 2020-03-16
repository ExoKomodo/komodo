using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.ECS.Components
{
    public class CameraComponent : Component
    {
        #region Constructors
        public CameraComponent() : base(true, null)
        {
            Rotation = KomodoVector3.Zero;
            Zoom = 1;
            Position = KomodoVector3.Zero;
            IsPerspective = false;
            NearPlane = 1f;
            FarPlane = 2f;
            FieldOfView = 90f;
        }
        #endregion Constructors
        
        #region Members

        #region Public Members
        public Rectangle BoundingRectangle
        {
            get
            {
                var frustum = GetBoundingFrustum();
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
        public KomodoVector3 Center => WorldPosition + Origin;
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
        public KomodoVector3 Forward => new KomodoVector3(0, 0, -1);
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
        public KomodoVector3 Origin { get; set; }
        public Matrix Projection
        {
            get
            {
                var graphicsManager = Parent.ParentScene.Game.GraphicsManager;
                if (IsPerspective)
                {
                    return Matrix.CreatePerspectiveFieldOfView(
                        MathHelper.ToRadians(FieldOfView),
                        graphicsManager.ViewPort.Width / graphicsManager.ViewPort.Height,
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
                        graphicsManager.ViewPort.Width,
                        graphicsManager.ViewPort.Height,
                        0,
                        NearPlane,
                        FarPlane
                    );
                }
            }
        }
        public new KomodoVector3 Rotation { get; set; }
        public new Matrix RotationMatrix
        {
            get
            {
                return Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z);
            }
        }
        public KomodoVector3 Up => new KomodoVector3(0, 1, 0);
        public Matrix ViewMatrix { get; protected set; }
        public Viewport Viewport { get; protected set; }
        public float Zoom
        {
            get
            {
                return _zoom;
            }
            set
            {
                if ((value >= MinimumZoom) && (value < +MaximumZoom))
                {
                    _zoom = value;
                }
            }
        }
        #endregion Public Members

        #region Protected Members
        protected float _farPlane { get; set; }
        protected float _fieldOfView { get; set; }
        protected float _maximumZoom = float.MaxValue;
        protected float _minimumZoom { get; set; }
        protected float _nearPlane { get; set; }
        protected float _zoom { get; set; }
        #endregion Protected Members

        #endregion Members
        
        #region Member Methods

        #region Public Member Methods
        public ContainmentType Contains(Point point)
        {
            return Contains(new KomodoVector2(point.ToVector2()));
        }

        public ContainmentType Contains(KomodoVector2 vector)
        {
            return GetBoundingFrustum().Contains(new KomodoVector3(vector.X, vector.Y, 0).MonoGameVector);
        }

        public ContainmentType Contains(Rectangle rectangle)
        {
            var max = new Vector3(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height, 0.5f);
            var min = new Vector3(rectangle.X, rectangle.Y, 0.5f);
            var boundingBox = new BoundingBox(min, max);
            return GetBoundingFrustum().Contains(boundingBox);
        }

        public override void Deserialize(SerializedObject serializedObject)
        {
            throw new NotImplementedException();
        }

        public BoundingFrustum GetBoundingFrustum()
        {
            return new BoundingFrustum(Projection);
        }

        public void LookAt(KomodoVector3 position)
        {
            Position = (
                position
                - new KomodoVector3(
                    Viewport.Width / 2f,
                    Viewport.Height / 2f
                )
            );
        }

        public void Move(KomodoVector3 direction)
        {
            Position += direction;
        }

        public void RotateX(float radians)
        {
            Rotate(radians, 0f, 0f);
        }
        
        public void RotateY(float radians)
        {
            Rotate(0f, radians, 0f);
        }

        public void RotateZ(float radians)
        {
            Rotate(0f, 0f, radians);
        }
        
        public void Rotate(float radiansX, float radiansY, float radiansZ)
        {
            Rotate(new KomodoVector3(radiansX, radiansY, radiansZ));
        }

        public void Rotate(KomodoVector3 rotation)
        {
            Rotation += rotation;
        }

        public override SerializedObject Serialize()
        {
            throw new NotImplementedException();
        }

        public void SetActive()
        {
            Parent.ParentScene.ActiveCamera = this;
        }

        public KomodoVector3 ScreenToWorld(float x, float y, float z)
        {
            return ScreenToWorld(new KomodoVector3(x, y, z));
        }

        public KomodoVector3 ScreenToWorld(KomodoVector3 screenPosition)
        {
            return KomodoVector3.Transform(
                (
                    screenPosition
                    - new KomodoVector3(Viewport.X, Viewport.Y)
                ),
                Matrix.Invert(GetViewMatrix())
            );
        }

        public override void Update(GameTime gametime)
        {
            Viewport = Parent.ParentScene.Game.GraphicsManager.ViewPort;
            ViewMatrix = GetViewMatrix();
        }

        public KomodoVector3 WorldToScreen(float x, float y, float z)
        {
            return WorldToScreen(new KomodoVector3(x, y, z));
        }

        public KomodoVector3 WorldToScreen(KomodoVector3 worldPosition)
        {
            return KomodoVector3.Transform(
                worldPosition + new KomodoVector3(Viewport.X, Viewport.Y, 0f),
                GetViewMatrix()
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

        #region Protected Member Methods
        protected void ClampZoom(float value)
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

        protected Matrix GetInverseViewMatrix()
        {
            return Matrix.Invert(GetViewMatrix());
        }
        
        protected Matrix GetViewMatrix()
        {
            return GetVirtualViewMatrix();
        }

        protected Matrix GetVirtualViewMatrix()
        {
            return (
                Matrix.CreateTranslation(-WorldPosition.MonoGameVector)
                * Matrix.CreateTranslation(-Origin.MonoGameVector)
                * Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z)
                * Matrix.CreateScale(Zoom, Zoom, 1)
                * Matrix.CreateTranslation(Origin.MonoGameVector)
            );
        }
        #endregion Protected Member Methods

        #endregion Member Methods

        #region Static Members

        #region Public Static Members
        #endregion Public Static Members

        #endregion Static Members
    }
}