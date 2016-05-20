using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoadRules.Models.Entities
{
    public class TestResult
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
        public double Points { get; set; }
    }
}