// This file is responsible for  defining what opeartions event service must provide

using EventRegistrationAPI_RostyslavShcherbyk.DTOs;

namespace EventRegistrationAPI_RostyslavShcherbyk.Services
{
    public interface IEventService
    {
        // Get all campus events
        Task<List<EventDto>> GetAllAsync();

        // Get spcific event by its ID
        Task<EventDto?> GetByIdAsync(int id);

        // Create new cmapus event
        Task<EventDto> CreateAsync(CreateEventDto dto);
    }
}
