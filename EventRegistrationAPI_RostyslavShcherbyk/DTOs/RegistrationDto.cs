// This file defines what registration info is returned by API

namespace EventRegistrationAPI_RostyslavShcherbyk.DTOs
{
    public class RegistrationDto
    {
        // ID of registration
        public int RegistrationId { get; set; }

        // Name of event person registeed for
        public string EventTitle { get; set; } = string.Empty;

        // Name of person registered
        public string StudentName { get; set; } = string.Empty;

        // Email adress of person registered
        public string Email { get; set; } = string.Empty;

        // Date and time when registration was created for event
        public DateTime RegisteredOn { get; set; }
    }
}
