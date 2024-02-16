using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ElectionManagement.Models
{
    public class Constituency
    {
        [Key]
        public int Id { get; set; }
        public int? StateId { get; set; }

        public string? ConstituencyName { get; set; }

        [ForeignKey("StateId")]
        public virtual State State { get; set; }

    }
}
