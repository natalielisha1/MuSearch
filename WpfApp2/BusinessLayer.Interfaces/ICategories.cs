namespace WpfApp2.BusinessLayer.Interfaces
{
    using System.Collections.Generic;

    using WpfApp2.General;

    public interface ICategories
    {
        List<Category> checkCategories(string input);

        Category randomCategory(string tableName);
    }
}