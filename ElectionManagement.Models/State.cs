﻿using System.ComponentModel.DataAnnotations;

namespace ElectionManagement.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


    }
}
