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
        #region Constructores
        public SerializedObject()
        {
            Properties = new Dictionary<string, object>();
            Type = null;
            Value = null;
        }
        #endregion Constructores

        #region Members

        #region Public Members
        public string Type { get; set; }
        public Dictionary<string, object> Properties { get; set; }
        public object Value { get; set; }
        #endregion Public Members

        #endregion Members
    }
}
