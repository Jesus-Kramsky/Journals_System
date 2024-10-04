using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Journals_System.Models.Database
{
    public class Researchers
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdResearcher { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email{ get; set; }

        [Required]
        public string Password { get; set; }
    }
}
