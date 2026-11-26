// This file defines what operrations  registration service must provide

using EventRegistrationAPI_RostyslavShcherbyk.DTOs;

namespace EventRegistrationAPI_RostyslavShcherbyk.Services
{
    public interface IRegistrationService
    {
        // Get all registrations for specific event
        Task<List<RegistrationDto>?> GetAllAsync(int eventId);

        // Register person for specific event
        Task<RegistrationDto?> CreateAsync(int eventId, CreateRegistrationDto dto);

        // Cancel registration by ID
        Task<bool> DeleteAsync(int id);
    }
}
