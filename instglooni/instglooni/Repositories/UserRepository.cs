using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using instglooni.Models;

namespace instglooni.Repositories
{
    public class UserRepository
    {
        SQLiteConnection database;
        public UserRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
        }
        public IEnumerable<User> GetItems()
        {
            return (from i in database.Table<User>() select i).ToList();

        }
        public User GetItem(int id)
        {
            return database.Get<User>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<User>(id);
        }
        public int SaveItem(User item)
        {
            if (item.user_id != 0)
            {
                database.Update(item);
                return item.user_id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
