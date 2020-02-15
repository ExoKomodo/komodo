using System;
using System.Collections.Generic;
using Komodo.Core.Engine.Components;
using Komodo.Core.Engine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Entities
{
    public class Entity
    {
        #region Constructors
        public Entity(Scene parentScene)
        {
            Components = new List<IComponent>();
            IsEnabled = true;
            ParentScene = parentScene;
            Position = KomodoVector3.Zero;
            Rotation = 0.0f;
            Scale = KomodoVector2.One;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public List<IComponent> Components
        {
            get
            {
                return _components;
            }
            protected set
            {
                _components = value;
            }
        }
        public bool IsEnabled { get; set; }
        public Scene ParentScene
        {
            get
            {
                return _parentScene;
            }
            internal set
            {
                _parentScene = value;
            }
        }
        public KomodoVector3 Position { get; set; }
        public float Rotation { get; set; }
        public KomodoVector2 Scale { get; set; }
        #endregion Public Members

        #region Protected Members
        protected List<IComponent> _components;
        protected Scene _parentScene;
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public void AddComponent(IComponent componentToAdd)
        {
            if (Components == null)
            {
                Components = new List<IComponent>();
            }
            if (componentToAdd.Parent != null)
            {
                componentToAdd.Parent.RemoveComponent(componentToAdd);
            }
            Components.Add(componentToAdd);
            componentToAdd.Parent = this;
            if (ParentScene != null)
            {
                ParentScene.AddComponent(componentToAdd);
            }
        }

        public bool ChangeScene(Scene sceneToChangeTo)
        {
            if (sceneToChangeTo == null)
            {
                return false;
            }
            if (ParentScene != null)
            {
                ParentScene.RemoveEntity(this);
            }
            return sceneToChangeTo.AddEntity(this);
        }

        public void ClearComponents()
        {
            var componentsToRemove = Components.ToArray();
            foreach (var component in componentsToRemove)
            {
                RemoveComponent(component);
            }
            Components.Clear();
        }

        public void Deserialize(SerializedObject serializedObject)
        {
            var type = Type.GetType(serializedObject.Type);
            if (type == this.GetType())
            {
                ParentScene = null;
                Components = new List<IComponent>();
                Position = new KomodoVector3();
                Rotation = 0.0f;
                Scale = new KomodoVector2();

                if (serializedObject.Properties.ContainsKey("Components"))
                {
                    var obj = serializedObject.Properties["Components"];
                    if (obj is List<IComponent>)
                    {
                        var components = obj as List<IComponent>;
                        foreach (var component in components)
                        {
                            component.Parent = this;
                            this.AddComponent(component);
                        }
                    }
                }
                if (
                    serializedObject.Properties.ContainsKey("PositionX")
                    && serializedObject.Properties.ContainsKey("PositionY")
                    && serializedObject.Properties.ContainsKey("PositionZ")
                )
                {
                    var x = serializedObject.Properties["PositionX"];
                    var y = serializedObject.Properties["PositionY"];
                    var z = serializedObject.Properties["PositionZ"];
                    if (x is float && y is float && z is float)
                    {
                        Position = new KomodoVector3((float)x, (float)y, (float)z);
                    }
                }
                if (serializedObject.Properties.ContainsKey("Rotation"))
                {
                    var rotation = serializedObject.Properties["Rotation"];
                    if (rotation is float)
                    {
                        Rotation = (float)rotation;
                    }
                }
                if (
                    serializedObject.Properties.ContainsKey("ScaleX")
                    && serializedObject.Properties.ContainsKey("ScaleY")
                )
                {
                    var x = serializedObject.Properties["ScaleX"];
                    var y = serializedObject.Properties["ScaleY"];
                    if (x is float && y is float)
                    {
                        Scale = new KomodoVector2((float)x, (float)y);
                    }
                }
            }
            else
            {
                // TODO: Add InvalidTypeException to Deserialize
                throw new Exception("Not correct type");
            }
        }
        
        public bool RemoveComponent(IComponent componentToRemove)
        {
            if (Components != null)
            {
                if (ParentScene != null)
                {
                    if (!ParentScene.RemoveComponent(componentToRemove))
                    {
                        return false;
                    }
                }
                componentToRemove.Parent = null;
                return Components.Remove(componentToRemove);
            }
            return false;
        }

        public SerializedObject Serialize()
        {
            var serializedObject = new SerializedObject();
            serializedObject.Type = this.GetType().ToString();
            
            var components = new List<SerializedObject>();
            foreach (var component in Components)
            {
                components.Add(component.Serialize());
            }
            serializedObject.Properties["Components"] = components;

            serializedObject.Properties["PositionX"] = Position.X;
            serializedObject.Properties["PositionY"] = Position.Y;
            serializedObject.Properties["PositionZ"] = Position.Z;
            
            serializedObject.Properties["Rotation"] = Rotation;
            
            serializedObject.Properties["Scale.X"] = Scale.X;
            serializedObject.Properties["Scale.Y"] = Scale.X;

            return serializedObject;
        }

        #endregion Public Member Methods

        #region Protected Member Methods
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}