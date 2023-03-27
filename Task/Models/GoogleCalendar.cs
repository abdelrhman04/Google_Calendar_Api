using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Models
{
    public class GoogleCalendar
    {
        [Required]
        public string? Summary { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        [DateValidation("End", ErrorMessage = "Not valid")]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
    }
}