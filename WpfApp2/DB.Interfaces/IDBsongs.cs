namespace MuSearch.DB.Interfaces
{
    using System.Collections.Generic;

    using WpfApp2.BusinessLayer;

    public interface IDBsongs
    {
        List<string> GetWords(List<Category> categories);

        string CreateQuery(List<Category> categories);
    }
}