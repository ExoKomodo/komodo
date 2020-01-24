namespace Komodo.Core
{
    public interface ISerializable<T>
    {
        #region Member Methods
        
        #region Public Member Methods
        void Deserialize(SerializedObject serializedObject);
        SerializedObject Serialize();
        #endregion Public Member Methods
        
        #endregion Member Methods
    }
}