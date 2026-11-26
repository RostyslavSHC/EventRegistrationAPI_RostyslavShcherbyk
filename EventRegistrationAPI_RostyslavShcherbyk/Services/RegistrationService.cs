// This file handles registration operations, bussiness rules and db access

using Microsoft.EntityFrameworkCore;
using EventRegistrationAPI_RostyslavShcherbyk.Data;
using EventRegistrationAPI_RostyslavShcherbyk.DTOs;
using EventRegistrationAPI_RostyslavShcherbyk.Models;

namespace EventRegistrationAPI_RostyslavShcherbyk.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly AppDbContext _context;

        // Gets access to database
        public RegistrationService(AppDbContext context)
        {
            _context = context;
        }





        // Get all registrrations for specific event
        public async Task<List<RegistrationDto>?> GetAllAsync(int eventId)
        {
            // Check if event exists
            bool exists = await _context.Events
                .AnyAsync(e => e.EventId == eventId);

            if (!exists)
                return null;

            // Get registrations for tis event and convert it into DTOs
            return await _context.Registrations
                .Where(r => r.EventId == eventId)
                .Select(r => new RegistrationDto
                {
                    RegistrationId = r.RegistrationId,
                    EventTitle = r.Event.Title,
                    StudentName = r.StudentName,
                    Email = r.Email,
                    RegisteredOn = r.RegisteredOn
                })
                .ToListAsync();
        }




        // Register person for an specific event
        public async Task<RegistrationDto?> CreateAsync(int eventId, CreateRegistrationDto dto)
        {
            // Rule 1: Event must exist
            var campusEvent = await _context.Events.FindAsync(eventId);

            if (campusEvent == null)
                return null;


            // Rule 2: People cannot register for past events
            if (campusEvent.EventDate <= DateTime.Now)
            {
                throw new ArgumentException("Registration is closed for past events.");
            }

            // Rule 3: Same email cannot register twice for same event
            // I also convert both emails to lowercase to ignore capitalization because in actuall email adresses capitalization doesn't matter
            bool alreadyRegistered = await _context.Registrations
                .AnyAsync(r => r.EventId == eventId &&
                               r.Email.ToLower() == dto.Email.ToLower());

            if (alreadyRegistered)
            {
                throw new InvalidOperationException("This email is already registered for this event.");
            }


            // Rule 4: Event must have available spots
            int registeredCount = await _context.Registrations
                .CountAsync(r => r.EventId == eventId);

            if (registeredCount >= campusEvent.Capacity)
            {
                throw new InvalidOperationException("This event is full.");
            }


            // Create registration if all business rules are satisfied
            var registration = new Registration
            {
                EventId = eventId,
                StudentName = dto.StudentName,
                Email = dto.Email,
                RegisteredOn = DateTime.Now
            };

            // Add registration and save it to database
            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();

            // Return newly created registration as DTO
            return new RegistrationDto
            {
                RegistrationId = registration.RegistrationId,
                EventTitle = campusEvent.Title,
                StudentName = registration.StudentName,
                Email = registration.Email,
                RegisteredOn = registration.RegisteredOn
            };
        }








        // Cancel registration by its ID
        public async Task<bool> DeleteAsync(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);

            // Return false if registration does not exist
            if (registration == null)
                return false;

            // Remove registration from db to free a spot
            _context.Registrations.Remove(registration);
            await _context.SaveChangesAsync();

            return true;
        }






    }
}
