using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RoadRules.Models.Entities;

namespace RoadRules.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }

        public IDbSet<Answer> Answers { get; set; }
        public IDbSet<Question> Questions { get; set; }
        public IDbSet<QuestionType> QuestionTypes { get; set; }
        public IDbSet<Test> Tests { get; set; }
        public IDbSet<TestResult> TestResults { get; set; }
        public IDbSet<Puzzle> Puzzles { get; set; }
        public IDbSet<Piece> Pieces { get; set; }
        public IDbSet<PuzzleResult> PuzzleResults { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}