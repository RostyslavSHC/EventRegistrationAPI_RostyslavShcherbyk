// This file responsible for defining a campus event and store it's information


using System.ComponentModel.DataAnnotations;

namespace EventRegistrationAPI_RostyslavShcherbyk.Models
{
    // Represents a campus event
    public class Event
    {
        // ID of event - Primary key
        public int EventId { get; set; }

        // Name of eevnt - Required, maximum 100 characters
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        // Where event is located - Required
        [Required]
        public string Location { get; set; } = string.Empty;

        // Date and time of event
        public DateTime EventDate { get; set; }

        // Maximum number of people who can register
        public int Capacity { get; set; }

        // List of all registrations for this event
        // One-to-many relationship: 1 Event can have many registrations
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}