using System.Collections.Generic;

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
