using System.ComponentModel.DataAnnotations;
namespace Event_Management.Models
{
    public class Participant
    {
        [Key]
        public int P_Id { get; set; }

        [Required]
        public string Ad { get; set; }

        [Required]
        public string Soyad { get; set; }


        public string E_posta { get; set; }

        public bool Status { get; set; }

        public List<Event> Events { get; set; } = new List<Event>();
    }
}
