using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class UpdateGoogleCalendar
    {
        [Required]
        public string? Id { get; set; }
        [Required]
        public string? CalendarId { get; set; }
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