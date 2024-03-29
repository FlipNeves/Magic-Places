﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicPlaces_API.Models
{
    public class Places
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; }
        public string Location { get; set; }
        public DateTime LastDate { get; set; }
        public string Comment { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

    }
}
