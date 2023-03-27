using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Models
{
    public class GoogleCalendarSearch
    {
        [Required]
        public string? Description { get; set; }
      
        public DateTime? Start { get; set; } = null;


        public DateTime? End { get; set; } = null;
    }
}