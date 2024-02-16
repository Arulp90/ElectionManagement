using System.ComponentModel.DataAnnotations;

namespace ElectionManagement.Web.Models
{
    public class ConstituencyViewModel
    {
        [Required, StringLength(50, ErrorMessage = "Can be up to 50 characters.")]

        public string ConstituencyName { get; set; }

        [Required]
        public string State { get; set; }

        public int Id { get; set; }
    }
}
