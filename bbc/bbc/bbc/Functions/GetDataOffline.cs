using System;
using System.Collections.Generic;
using System.Text;

using bbc.LocalDatabase;
using bbc.Data.Models;

namespace bbc.Functions
{
    public class GetDataOffline
    {
        public static List<Lesson> getLessonOffline()
        {
            LessonDatabaseAccess lessonDB = new LessonDatabaseAccess();
            return lessonDB.GetLessonDb();
        }

        public static List<Question> getQuetsionOffline(string idLesson)
        {
            QuestionDatabaseAccess questionDB = new QuestionDatabaseAccess();
            return questionDB.GetQuestionDb(idLesson);
        }

        public static List<Answer> getAnswerOffline(string idQuestion)
        {
            AnswerDatabaseAccess answerDB = new AnswerDatabaseAccess();
            return answerDB.GetAnswerDb(idQuestion);
        }
    }
}
