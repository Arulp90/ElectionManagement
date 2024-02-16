using System.ComponentModel.DataAnnotations;

namespace ElectionManagement.Web.Models
{
    public class PartyViewModel
    {
        [Required, StringLength(50, ErrorMessage = "Can be up to 50 characters.")]

        public string PartyName { get; set; }

        [Required]
        public string Symbol { get; set; }

        public int Id { get; set; }
    }
}
