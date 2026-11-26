// This file defines what info is needed to register for event

using System.ComponentModel.DataAnnotations;

namespace EventRegistrationAPI_RostyslavShcherbyk.DTOs
{
    public class CreateRegistrationDto
    {
        // Name of person registering - Required
        [Required(ErrorMessage = "Student name is required.")]
        public string StudentName { get; set; } = string.Empty;

        // Email address of person registering - Required, must be valid email
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;
    }
}
