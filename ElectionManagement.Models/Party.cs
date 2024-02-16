using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectionManagement.Models
{
    public class Party
    {
        [Key]
        public int Id { get; set; }
        public int SymbolId { get; set; }
        public string? PartyName { get; set; }

        [ForeignKey("SymbolId")]
        public SymbolsMaster SymbolsMaster { get; set; }
    }
}
