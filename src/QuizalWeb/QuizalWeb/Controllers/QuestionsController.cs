using Microsoft.AspNetCore.Mvc;
using quizLibrary;
using Microsoft.AspNetCore.Http;


namespace QuizalWeb.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IquizRepo _quizRepo;

        public QuestionsController(IquizRepo quizRepo)
        {
            _quizRepo = quizRepo;
        }
        // GET: Questions
        public ActionResult Index(int quizId)
        {
            ViewBag.QuizTitle = _quizRepo.GetQuizById(quizId).Title;
            ViewBag.QuizId = quizId;
            return View(_quizRepo.GetQuestions(quizId));
        }

        // GET: Questions/Details/5
        public ActionResult Details(int id)
        {
            return View(_quizRepo.GetQuestionById(id));
        }

        // GET: Questions/Create
        public ActionResult Create(int quizId)
        {
            ViewBag.QuizId = quizId;
            return View();
        }

        // POST: Questions/Create
        [HttpPost]
        public ActionResult Create(Question newQuestion, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                _quizRepo.AddQuestion(newQuestion);
                return RedirectToAction("Index", new { quizId = newQuestion.QuizId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_quizRepo.GetQuestionById(id));
        }

        // POST: Questions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Question editedQuestion, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _quizRepo.EditQuestion(editedQuestion);
                return RedirectToAction("Index", new { quizId = editedQuestion.QuizId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_quizRepo.GetQuestionById(id));
        }

        // POST: Questions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _quizRepo.DeleteQuestion(id);
                return RedirectToAction("Index", new { quizId = _quizRepo.GetQuestionById(id).QuizId });
            }
            catch
            {
                return View();
            }
        }
    }
}
