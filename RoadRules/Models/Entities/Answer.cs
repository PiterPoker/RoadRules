using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoadRules.Models.Entities
{
    public class Answer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Content { get; set; }

        [DefaultValue(true)]
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}