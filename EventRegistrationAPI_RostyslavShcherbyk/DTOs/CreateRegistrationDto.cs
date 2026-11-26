// This file defines what info is needed to register for event

namespace EventRegistrationAPI_RostyslavShcherbyk.DTOs
{
    public class CreateRegistrationDto
    {
        // Name of person registering
        public string StudentName { get; set; } = string.Empty;

        // Email address of person registering
        public string Email { get; set; } = string.Empty;
    }
}
