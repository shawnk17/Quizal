using System;
using Microsoft.AspNetCore.Mvc;
using quizLibrary;
using Microsoft.AspNetCore.Http;

namespace QuizalWeb.Controllers
{
    public class QuizWebAppController : Controller
    {
        private readonly IquizRepo _quizRepo;

        public QuizWebAppController(IquizRepo quizRepo)
        {
            _quizRepo = quizRepo;
        }        
        // GET: QuizWebApp

        public ActionResult Index()
        {
            return View(_quizRepo.GetQuizAll());
        }

        // GET: QuizWebApp/Details/5
        public ActionResult Details(int id)
        {
            return View(_quizRepo.GetQuizById(id));
        }

        // GET: QuizWebApp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuizWebApp/Create
        [HttpPost]
        public ActionResult Create(Quiz newQuiz, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                newQuiz.PublishDate = DateTime.Now;
                _quizRepo.AddQuiz(newQuiz);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: QuizWebApp/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_quizRepo.GetQuizById(id));
        }

        // POST: QuizWebApp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Quiz EditedQuiz, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _quizRepo.EditQuiz(EditedQuiz);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuizWebApp/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_quizRepo.GetQuizById(id));
        }

        // POST: QuizWebApp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _quizRepo.DeleteQuiz(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult GameArea(int id)
        {
            ViewBag.QuizId = id;
            return View();
        }
    }
}
