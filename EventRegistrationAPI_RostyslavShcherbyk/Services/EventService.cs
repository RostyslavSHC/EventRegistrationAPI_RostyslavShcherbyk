// This file used to access event data from DB and convert it into DTOs

using Microsoft.EntityFrameworkCore;
using EventRegistrationAPI_RostyslavShcherbyk.Data;
using EventRegistrationAPI_RostyslavShcherbyk.DTOs;
using EventRegistrationAPI_RostyslavShcherbyk.Models;

namespace EventRegistrationAPI_RostyslavShcherbyk.Services
{
    public class EventService : IEventService
    {
        private readonly AppDbContext _context;

        // Gets acess to databbase
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

                    // Calluclate # of registered people and available spots
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





        // Create new campus event
        public async Task<EventDto> CreateAsync(CreateEventDto dto)
        {
            // Convert received DTO into event entity
            var campusEvent = new Event
            {
                Title = dto.Title,
                Location = dto.Location,
                EventDate = dto.EventDate,
                Capacity = dto.Capacity
            };

            // Add new event and save it to db
            _context.Events.Add(campusEvent);
            await _context.SaveChangesAsync();

            // Return our new just created event as DTO
                // Instead of writing DTO mapping again, I simply reuse my existing method
                // This automatically includes RegisteredCount and SpotsLeft
            return (await GetByIdAsync(campusEvent.EventId))!;
        }





    }
}
