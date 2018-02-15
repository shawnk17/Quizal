using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace quizLibrary
{
    public class quizRepo : IquizRepo
    {
        private readonly quizDbContext _db;
        public quizRepo(quizDbContext db)
        {
            _db = db;
        }

        public void AddQuiz(Quiz newQuiz)
        {

            _db.QuizTable.Add(newQuiz);
            _db.SaveChanges();

        }

        public Quiz GetQuizById(int id)
        {

            Quiz targetQuiz = _db.QuizTable
                .Include(q => q.Questions)
                .ThenInclude(qu => qu.Answers)
                .FirstOrDefault(q => q.QuizId == id);
            return targetQuiz;

        }

        public List<Quiz> GetQuizAll()
        {

            var quizzes = from quiz in _db.QuizTable
                          select quiz;

            return quizzes.ToList();

        }

        public void EditQuiz(Quiz editedQuiz)
        {


            _db.QuizTable.Attach(editedQuiz);
            var entry = _db.Entry(editedQuiz);
            entry.State = EntityState.Modified;
            _db.SaveChanges();

        }

        public void DeleteQuiz(int id)
        {

            var targetQuiz = _db.QuizTable.Find(id);
            _db.QuizTable.Remove(targetQuiz);
            _db.SaveChanges();

        }

        public void AddQuestion(Question newQuestion)
        {

            _db.QuestionTable.Add(newQuestion);
            _db.SaveChanges();

        }

        public List<Question> GetQuestions(int QuizId)
        {

            //var questions = from question in _db.QuestionTable

            //                where question.QuizId == QuizId
            //                select question;
            var questions = _db.QuestionTable
                .Include(q => q.Answers)
                .Where(q => q.QuizId == QuizId);

            return questions.ToList();

        }

        public Question GetQuestionById(int id)
        {

            var question = _db.QuestionTable.Find(id);
            _db.Entry(question).Collection(quest => quest.Answers).Load();
            return question;

        }

        public void EditQuestion(Question editedQuestion)
        {

            _db.QuestionTable.Attach(editedQuestion);
            var entry = _db.Entry(editedQuestion);
            entry.State = EntityState.Modified;
            _db.SaveChanges();

        }

        public void DeleteQuestion(int id)
        {

            _db.QuestionTable.Remove(GetQuestionById(id));
            _db.SaveChanges();

        }

        public void AddAnswer(Answer newAnswer)
        {

            _db.AnswerTable.Add(newAnswer);
            _db.SaveChanges();

        }

        public List<Answer> GetAnswers(int QuestionId)
        {
            var answers = from answer in _db.AnswerTable
                          where answer.QuestionId == QuestionId
                          select answer;
            return answers.ToList();

        }

        public Answer GetAnswerById(int id)
        {

            var answer = _db.AnswerTable.Find(id);
            return answer;

        }

        public void EditAnswer(Answer editedAnswer)
        {

            _db.AnswerTable.Attach(editedAnswer);
            var entry = _db.Entry(editedAnswer);
            entry.State = EntityState.Modified;
            _db.SaveChanges();

        }

        public void DeleteAnswer(int id)
        {

            _db.AnswerTable.Remove(GetAnswerById(id));
            _db.SaveChanges();

        }
    }
}
