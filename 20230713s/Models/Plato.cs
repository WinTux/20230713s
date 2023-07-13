using System.ComponentModel.DataAnnotations;

namespace _20230713s.Models
{
    public class Plato
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
    }
}
