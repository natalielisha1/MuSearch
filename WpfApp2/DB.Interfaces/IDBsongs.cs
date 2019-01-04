namespace MuSearch.DB.Interfaces
{
    using System.Collections.Generic;

    using WpfApp2.General;

    public interface IDBsongs
    {
        List<string> GetWords(List<Category> categories);

        string CreateQuery(List<Category> categories);
    }
}