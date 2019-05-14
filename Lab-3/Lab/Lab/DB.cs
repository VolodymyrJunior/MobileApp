using System.Collections.Generic;
using Xamarin.Forms;
using SQLite;
using System.Linq;

namespace Lab
{
    public class DB
    {
        SQLiteConnection database;
        public DB(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Choose>();
        }
        public IEnumerable<Choose> GetItems()
        {
            return (from i in database.Table<Choose>() select i).ToList();

        }

        public void SaveItem(Choose item)
        {
            if (item.typeProduct != "" && item.vendor != "")
            {
                this.database.Insert(item);
            }
        }
    }
}
