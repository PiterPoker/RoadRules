using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoadRules.Models.Entities
{
    public class Puzzle
    {
        public Puzzle()
        {
            Pieces = new List<Piece>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageType { get; set; }
        public string Name { get; set; }
        public ICollection<Piece> Pieces { get; set; }
    }
}