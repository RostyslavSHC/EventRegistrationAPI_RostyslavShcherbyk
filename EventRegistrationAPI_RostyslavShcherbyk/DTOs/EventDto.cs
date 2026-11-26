// This file defines what event info is returned by API

namespace EventRegistrationAPI_RostyslavShcherbyk.DTOs
{
    public class EventDto
    {
        // ID of event
        public int EventId { get; set; }

        // Name of evnet
        public string Title { get; set; } = string.Empty;

        // Where event is located
        public string Location { get; set; } = string.Empty;

        // Date and time of event
        public DateTime EventDate { get; set; }

        // Maximum number of people who can register
        public int Capacity { get; set; }

        // Number of people arleady registered
        public int RegisteredCount { get; set; }

        // Number of available spots left
        public int SpotsLeft { get; set; }
    }
}
