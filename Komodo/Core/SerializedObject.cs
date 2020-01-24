using System;
using System.Collections;
using System.Collections.Generic;

using System.Text.Json.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core
{
    public class SerializedObject
    {
        #region Members

        #region Public Members
        public string Type { get; set; }
        public Dictionary<string, object> Fields { get; set; }
        public object Value { get; set; }
        #endregion Public Members

        #endregion Members

        #region Static Methods
        
        #region Public Static Methods
        public static SerializedObject Serialize(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            var objType = obj.GetType();
            var serializedObj = new SerializedObject
            {
                Type = objType.ToString(),
                Fields = new Dictionary<string, object>(),
            };

            var properties = objType.GetProperties();
            foreach (var property in properties)
            {
                var propertyType = property.PropertyType;
                if (propertyType == typeof(TextureCollection)) {
                    return null;
                }
                var propertyValue = property.GetValue(obj);
                var attributes = property.Attributes;
                bool shouldIgnore = Attribute.IsDefined(property, typeof(JsonIgnoreAttribute));
                if (!shouldIgnore)
                {
                    if (propertyValue is IList)
                    {
                        serializedObj.Fields[property.Name] = new List<SerializedObject>();

                        var listField = propertyValue as IList;
                        foreach (var item in listField)
                        {
                            (serializedObj.Fields[property.Name] as IList).Add(SerializedObject.Serialize(item));
                        }
                    }
                    else if (propertyType.IsPrimitive)
                    {
                        serializedObj.Fields[property.Name] = propertyValue;
                    }
                    else if (propertyType.IsValueType)
                    {
                        serializedObj.Fields[property.Name] = propertyValue;
                    }
                    else
                    {
                        serializedObj.Fields[property.Name] = propertyValue;
                        // serializedObj.Value = propertyValue;
                        // serializedObj.Fields[property.Name] = SerializedObject.Serialize(objValue);
                    }
                }
            }

            return serializedObj;
        }
        #endregion Public Static Methods
        
        #endregion Static Methods
    }
}
