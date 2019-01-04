namespace WpfApp2.BusinessLayer.Interfaces
{
    using System.Collections.Generic;

    public interface ICategories
    {
        List<Category> checkCategories(string input);

        Category randomCategory(string tableName);
    }
}