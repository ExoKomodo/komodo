
using System;
using System.Text.Json.Serialization;
using Komodo.Core.Engine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Components
{
    public class CameraComponent : Component, ISerializable<CameraComponent>
    {
        #region Constructors
        public CameraComponent(float maxZoom = 1f, float minZoom = 0f) : base(true, null)
        {
            MaxZoom = maxZoom;
            MinZoom = minZoom;
            Position = KomodoVector3.Zero;
            Zoom = 1f;
        }
        #endregion Constructors

        #region Members
        
        #region Public Members
        public Rectangle Bounds
        {
            get
            {
                return Viewport.Bounds;
            }
        }
        public bool IsInitialized { get; set; }
        public float MaxZoom { get; set; }
        public float MinZoom { get; set; }
        public new KomodoVector3 Position { get; set; }
        public Viewport Viewport { get; protected set; }
        public Rectangle VisibleArea { get; protected set; }
        public float Zoom { get; set; }
        #endregion Public Members

        #region Private Members
        #endregion Private Members

        #region Protected Members
        #endregion Protected Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public void AdjustZoom(float zoomAmount)
        {
            Zoom += zoomAmount;
            if (Zoom < MinZoom)
            {
                Zoom = MinZoom;
            }
            if (Zoom > MaxZoom)
            {
                Zoom = MaxZoom;
            }
        }

        public override void Deserialize(SerializedObject serializedObject)
        {
            throw new System.NotImplementedException();
        }

        sealed public override void Draw(SpriteBatch spriteBatch)
        {
        }

        public void Pan(KomodoVector3 translation)
        {
            Position = KomodoVector3.Add(Position, translation);
        }

        public override SerializedObject Serialize()
        {
            throw new System.NotImplementedException();
        }

        public void SetActive()
        {
            Parent.ParentScene.ActiveCamera = this;
        }

        public override void Update(GameTime gametime)
        {
            if (!IsInitialized)
            {
                IsInitialized = true;
                Viewport = Parent.ParentScene.Game.GraphicsManager.ViewPort;
            }
            UpdateMatrix();
        }
        #endregion Public Member Methods

        #region Protected Member Methods
        protected void UpdateMatrix()
        {
            Transform = Matrix.CreateTranslation(
                new Vector3(
                    -Position.X,
                    -Position.Y,
                    0
                )
            )
            * Matrix.CreateScale(Zoom)
            * Matrix.CreateTranslation(
                new Vector3(
                    Bounds.Width * 0.5f,
                    Bounds.Height * 0.5f,
                    0
                )
            );
            UpdateVisibleArea();
        }
        protected void UpdateVisibleArea()
        {
            var inverseViewMatrix = Matrix.Invert(Transform);

            var tl = Vector2.Transform(
                Vector2.Zero,
                inverseViewMatrix
            );
            var tr = Vector2.Transform(
                new Vector2(
                    Bounds.X,
                    0
                ),
                inverseViewMatrix
            );
            var bl = Vector2.Transform(
                new Vector2(
                    0,
                    Bounds.Y
                ),
                inverseViewMatrix
            );
            var br = Vector2.Transform(
                new Vector2(
                    Bounds.Width,
                    Bounds.Height
                ),
                inverseViewMatrix
            );

            var min = new Vector2(
                MathHelper.Min(
                    tl.X,
                    MathHelper.Min(
                        tr.X,
                        MathHelper.Min(
                            bl.X,
                            br.X
                        )
                    )
                ),
                MathHelper.Min(
                    tl.Y,
                    MathHelper.Min(
                        tr.Y,
                        MathHelper.Min(
                            bl.Y,
                            br.Y
                        )
                    )
                )
            );
            var max = new Vector2(
                MathHelper.Max(
                    tl.X,
                    MathHelper.Max(
                        tr.X,
                        MathHelper.Max(
                            bl.X,
                            br.X
                        )
                    )
                ),
                MathHelper.Max(
                    tl.Y,
                    MathHelper.Max(
                        tr.Y,
                        MathHelper.Max(
                            bl.Y,
                            br.Y
                        )
                    )
                )
            );
            VisibleArea = new Rectangle(
                (int)min.X,
                (int)min.Y,
                (int)(max.X - min.X),
                (int)(max.Y - min.Y)
            );
        }
        #endregion Protected Member Methods
        
        #endregion Member Methods

        #region Static Methods

        #region Public Static Methods
        public static Matrix Transform { get; protected set; }
        #endregion Public Static Methods

        #endregion Static Methods
    }
}