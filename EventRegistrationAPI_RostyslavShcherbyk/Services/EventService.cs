// This file used to access event data from DB and convert it into DTOs

using Microsoft.EntityFrameworkCore;
using EventRegistrationAPI_RostyslavShcherbyk.Data;
using EventRegistrationAPI_RostyslavShcherbyk.DTOs;

namespace EventRegistrationAPI_RostyslavShcherbyk.Services
{
    public class EventService : IEventService
    {
        private readonly AppDbContext _context;

        // Gets access to databbase
        public EventService(AppDbContext context)
        {
            _context = context;
        }


        // Get all campus events sorted by date
        public async Task<List<EventDto>> GetAllAsync()
        {
            return await _context.Events
                .OrderBy(e => e.EventDate)
                .Select(e => new EventDto
                {
                    EventId = e.EventId,
                    Title = e.Title,
                    Location = e.Location,
                    EventDate = e.EventDate,
                    Capacity = e.Capacity,

                    // Calculate # of registered people and available spots
                    RegisteredCount = e.Registrations.Count,
                    SpotsLeft = e.Capacity - e.Registrations.Count
                })
                .ToListAsync();
        }


        // Get specific event by its ID. Return null if not found
        public async Task<EventDto?> GetByIdAsync(int id)
        {
            return await _context.Events
                .Where(e => e.EventId == id)
                .Select(e => new EventDto
                {
                    EventId = e.EventId,
                    Title = e.Title,
                    Location = e.Location,
                    EventDate = e.EventDate,
                    Capacity = e.Capacity,

                    // Calculate # of registered people and available spots
                    RegisteredCount = e.Registrations.Count,
                    SpotsLeft = e.Capacity - e.Registrations.Count
                })
                .FirstOrDefaultAsync();
        }
    }
}
