using bbc.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using bbc.LocalDatabase;
using SQLite;
using System.IO;
using Windows.Storage;
using AppConfig;

[assembly: Xamarin.Forms.Dependency(typeof(Window_SQLite))]
namespace bbc.UWP
{
    public class Window_SQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, Constant.LocalDatabaseName);
            return new SQLite.SQLiteConnection(path);
        }
    }
}
