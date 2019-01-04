namespace MuSearch.DB.Interfaces
{
    public interface IDBconnection
    {
        bool IsConnect();

        void Close();
    }
}