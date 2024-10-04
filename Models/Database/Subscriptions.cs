using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Journals_System.Models.Database
{
    public class Subscriptions
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSubscriptions { get; set; }

        // Foreign key for Subscriber
        public int SubscriberId { get; set; }
        public Researchers Subscriber { get; set; }

        // Foreign key for Followed
        public int FollowedId { get; set; }
        public Researchers Followed { get; set; }
    }
}
