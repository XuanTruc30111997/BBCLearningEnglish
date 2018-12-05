using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bbc.iOS;
using Foundation;
using UIKit;

using bbc.LocalDatabase;
using SQLite;
using System.IO;
using AppConfig;

[assembly: Xamarin.Forms.Dependency(typeof(IOS_SQLite))]
namespace bbc.iOS
{
    public class IOS_SQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string dbPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder  
            string libraryPath = Path.Combine(dbPath, "..", "Library"); // Library folder  
            if (!Directory.Exists(libraryPath))
                Directory.CreateDirectory(libraryPath);
            var path = Path.Combine(libraryPath, Constant.LocalDatabaseName);
            return new SQLite.SQLiteConnection(path);
        }
    }
}