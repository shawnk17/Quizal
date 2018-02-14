using System.Collections.Generic;

namespace quizLibrary
{
    public interface IquizRepo
    {
        void AddAnswer(Answer newAnswer);
        void AddQuestion(Question newQuestion);
        void AddQuiz(Quiz newQuiz);
        void DeleteAnswer(int id);
        void DeleteQuestion(int id);
        void DeleteQuiz(int id);
        void EditAnswer(Answer editedAnswer);
        void EditQuestion(Question editedQuestion);
        void EditQuiz(Quiz editedQuiz);
        Answer GetAnswerById(int id);
        List<Answer> GetAnswers(int QuestionId);
        Question GetQuestionById(int id);
        List<Question> GetQuestions(int QuizId);
        List<Quiz> GetQuizAll();
        Quiz GetQuizById(int id);
    }
}