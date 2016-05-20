using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoadRules.Models.Entities
{
    public class Test
    {
        public Test()
        {
            Questions = new List<Question>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}