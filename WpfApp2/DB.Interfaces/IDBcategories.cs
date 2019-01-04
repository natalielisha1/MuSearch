namespace MuSearch.DB.Interfaces
{
    using System.Collections.Generic;

    using WpfApp2.BusinessLayer;

    public interface IDBcategories
    {
        List<Category> checkCategories(string input);

        Category randomCategory(string tableName);
    }
}