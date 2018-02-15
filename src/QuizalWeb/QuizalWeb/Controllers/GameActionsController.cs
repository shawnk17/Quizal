using quizLibrary;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace QuizalWeb.Controllers
{
    public class GameActionsController : Controller
    {
        private readonly IquizRepo _quizRepo;

        public GameActionsController(IquizRepo quizRepo)
        {
            _quizRepo = quizRepo;
        }

        // GET: api/GameActions
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GameActions/5
        [Route("api/gameActions/{id}")]
        public List<Question> Get(int id)
        {
         
            return _quizRepo.GetQuestions(id);
        }

        // POST: api/GameActions
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GameActions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GameActions/5
        public void Delete(int id)
        {
        }
    }
}
