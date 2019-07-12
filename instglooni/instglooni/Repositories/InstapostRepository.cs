using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using instglooni.Models;
using SQLite;

namespace instglooni.Repositories
{
    public class InstapostRepository
    {
        SQLiteConnection database;
        public InstapostRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
        }
        public IEnumerable<Instapost> GetItems()
        {
            return (from i in database.Table<Instapost>() select i).ToList();

        }
        public Instapost GetItem(string post_code)
        {
            return database.Get<Instapost>(post_code);
        }
        public int DeleteItem(string post_code)
        {
            return database.Delete<Instapost>(post_code);
        }
    }
}
