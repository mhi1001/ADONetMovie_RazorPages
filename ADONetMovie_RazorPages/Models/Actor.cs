using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Models
{
    public class Actor
    {
        public int Id { get; set;}
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Country { get; set; }

        [Required]
        public DateTime Birth_year { get; set; }

        [Required]
        public bool Alive { get; set; }
    }
}
