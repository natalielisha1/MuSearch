namespace WpfApp2.BusinessLayer.Interfaces
{
    using System.Collections.Generic;

    interface ISongs
    {
        List<string> GetWords(List<Category> categories);

        string CreateQuery(List<Category> categories);
    }
}