using System.ComponentModel.DataAnnotations;

namespace Event_Management.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }
        public List<Participant> Participants { get; set; } = new List<Participant>();
    }
}
