using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

using bbc.Data.Models;
using Xamarin.Forms;
using System.Linq;

namespace bbc.LocalDatabase
{
    public class LessonDatabaseAccess
    {
        private SQLiteConnection dbConnection;
        private static object collisionLock = new object();

        public List<Lesson> Lessons { get; set; }

        public LessonDatabaseAccess()
        {
            dbConnection = DependencyService.Get<ISQLite>().GetConnection();
            dbConnection.CreateTable<Lesson>();

            this.Lessons = new List<Lesson>(dbConnection.Table<Lesson>());

            //if(!dbConnection.Table<Lesson>().Any()) // Đã có dữ liệu
            //{

            //}
        }

        // INSERT
        public void AddLesson(Lesson myLesson)
        {
            dbConnection.Insert(myLesson);
        }

        // GET
        public List<Lesson> GetLessonDb()
        {
            //var myQuery = from lesson in dbConnection.Table<Lesson>()
            //              select lesson;
            //return myQuery.ToList<Lesson>();

            return dbConnection.Table<Lesson>().ToList();
        }

        //DELETE
        public void DeleteLesson(string id)
        {
            dbConnection.Table<Lesson>().Delete(c => c.Id == id);
        }
    }
}
