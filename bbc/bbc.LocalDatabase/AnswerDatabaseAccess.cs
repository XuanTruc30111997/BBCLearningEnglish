using System;
using System.Collections.Generic;
using System.Text;

using bbc.Data.Models;
using Xamarin.Forms;
using System.Linq;
using SQLite;

namespace bbc.LocalDatabase
{
    public class AnswerDatabaseAccess
    {
        private SQLiteConnection dbConnection;
        private static object collisionLock = new object();

        public List<Answer> Answers { get; set; }

        public AnswerDatabaseAccess()
        {
            dbConnection = DependencyService.Get<ISQLite>().GetConnection();
            dbConnection.CreateTable<Answer>();

            this.Answers = new List<Answer>(dbConnection.Table<Answer>());
        }

        // GET
        public List<Answer> GetAnswerDb(string idQuestion)
        {
            return dbConnection.Table<Answer>().Where(c => c.QuestionID == idQuestion).ToList();
        }

        // INSERT
        public void AddAnswer(Answer myAnswer)
        {
            dbConnection.Insert(myAnswer);
        }

        // DELETE
        // Xóa tất cả các câu trả lời có trong câu hỏi
        public void DeleteAnswer(string idQuestion)
        {
            dbConnection.Table<Answer>().Delete(c => c.QuestionID == idQuestion);
        }
    }
}
