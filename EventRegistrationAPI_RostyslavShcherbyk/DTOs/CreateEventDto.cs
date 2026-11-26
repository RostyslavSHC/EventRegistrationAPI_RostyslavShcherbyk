// this file defines what info is needed to create new event

using System.ComponentModel.DataAnnotations;
using EventRegistrationAPI_RostyslavShcherbyk.Validation;

namespace EventRegistrationAPI_RostyslavShcherbyk.DTOs
{
    public class CreateEventDto
    {
        // Name of event - Required, maximum 100 characters
        [Required(ErrorMessage = "Event title is required.")]
        [StringLength(100, ErrorMessage = "Event title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        // Where event is located - Required
        [Required(ErrorMessage = "Event location is required.")]
        public string Location { get; set; } = string.Empty;

        // Date and time of event - Must be in the future
        [FutureDate(ErrorMessage = "Event date must be in the future.")]
        public DateTime EventDate { get; set; }

        // Maximum number of people who can register - Between 1 and 500
        [Range(1, 500, ErrorMessage = "Capacity must be between 1 and 500.")]
        public int Capacity { get; set; }
    }
}
