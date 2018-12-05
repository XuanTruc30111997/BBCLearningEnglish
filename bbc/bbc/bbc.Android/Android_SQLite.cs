using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.IO;
using bbc.LocalDatabase;
using bbc.Droid;
using SQLite;

using AppConfig;

[assembly: Xamarin.Forms.Dependency(typeof(Android_SQLite))]
namespace bbc.Droid
{
    public class Android_SQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbPath, Constant.LocalDatabaseName);
            return new SQLite.SQLiteConnection(path);
        }
    }
}