using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


#nullable disable

namespace ADONetMovie_RazorPages.Models
{
    public partial class Movie
    {
         public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int ActorId { get; set; }
    }
}
