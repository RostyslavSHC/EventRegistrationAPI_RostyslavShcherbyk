// This file responsible for defining a registration and store information about the person attending an event


using System.ComponentModel.DataAnnotations;

namespace EventRegistrationAPI_RostyslavShcherbyk.Models
{
    // Represents a student's registration for an event
    public class Registration
    {
        // ID of registration - Primary key
        public int RegistrationId { get; set; }

        // ID of event the person registered for - Foreign key
        public int EventId { get; set; }

        // Name of person registering - Required
        [Required]
        public string StudentName { get; set; } = string.Empty;

        // Email address of person registering - Required
        [Required]
        public string Email { get; set; } = string.Empty;

        // Date and time when the registration was created
        public DateTime RegisteredOn { get; set; }

        // Event assicoated with this registration
        // One-to-many relationship: Each registration belongs to 1 event
        public Event Event { get; set; } = null!;
    }
}