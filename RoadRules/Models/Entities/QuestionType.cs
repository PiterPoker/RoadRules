using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoadRules.Models.Entities
{
    public class QuestionType
    {
        public QuestionType()
        {
            Questions = new List<Question>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Content { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}