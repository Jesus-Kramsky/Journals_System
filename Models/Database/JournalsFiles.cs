using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Journals_System.Models.Database
{
    public class JournalsFiles
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdJournal { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string FileName { get; set; }
        [ForeignKey("Researcher")]
        [Required]
        public int IdResearcher { get; set; }
        public Researchers Researcher { get; set; }
    }
}
