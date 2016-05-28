using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoadRules.Models.Entities
{
    public class Question
    {
        public Question()
        {
            Answers = new List<Answer>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Content { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageType { get; set; }
        public double Points { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
        public int QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}