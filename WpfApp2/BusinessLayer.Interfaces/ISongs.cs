namespace WpfApp2.BusinessLayer.Interfaces
{
    using System.Collections.Generic;

    using WpfApp2.General;

    interface ISongs
    {
        List<string> GetWords(List<Category> categories);

        string CreateQuery(List<Category> categories);
    }
}