using MuSearch.BusinessLayer;
using MuSearch.DB;
using MuSearch.DB.Interfaces;
using WpfApp2.BusinessLayer;
using WpfApp2.BusinessLayer.Interfaces;

namespace Musearch
{
    public sealed class Container
    {
        private static Container instance = null;

        //interfaces DB:
        public IDBcategories categoriesDB;
        public IDBsongs songsDB;
        public IDBusers usersDB;

        //interfaces BL:
        public ICategories categoriesBL;
        public ISongs songsBL;
        public IUsers usersBL;

        private Container()
        {
            this.categoriesDB = new DBcategories();
            this.songsDB = new DBsongs();
            this.usersDB = new DBusers();

            this.categoriesBL = new Categories();
            this.songsBL = new Songs();
            this.usersBL = new Users();
        }

        public static Container Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Container();
                }
                return instance;
            }
        }
        
    }
}
