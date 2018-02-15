
using Microsoft.EntityFrameworkCore;

namespace quizLibrary
{
    public class quizDbContext : DbContext
    {
        public quizDbContext(DbContextOptions<quizDbContext> options)
         : base(options)

        {
        }

        public DbSet<Quiz> QuizTable { get; set; }
        public DbSet<Question> QuestionTable { get; set; }
        public DbSet<Answer> AnswerTable { get; set; }
        
    }
}
