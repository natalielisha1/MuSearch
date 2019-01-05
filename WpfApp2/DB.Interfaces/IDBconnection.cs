namespace MuSearch.DB.Interfaces
{
    public interface IDBconnection
    {
        /// <summary>
        /// see if the connection is connected
        /// </summary>
        /// <returns>true if it is cinnected and false otherwise</returns>
        bool IsConnect();

        /// <summary>
        /// close the connection
        /// </summary>
        void Close();
    }
}