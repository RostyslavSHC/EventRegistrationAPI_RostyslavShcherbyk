// this file defines what info is needed to create new event

namespace EventRegistrationAPI_RostyslavShcherbyk.DTOs
{
    public class CreateEventDto
    {
        // Name of event
        public string Title { get; set; } = string.Empty; // Name of event

        // Where event is located
        public string Location { get; set; } = string.Empty;

        // Date and time of event
        public DateTime EventDate { get; set; }

        // Maximum number of people who can register
        public int Capacity { get; set; }
    }
}
