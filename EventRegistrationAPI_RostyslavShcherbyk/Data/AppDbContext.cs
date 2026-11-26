// This file is responsible for connection app to database and managing it's tables

using Microsoft.EntityFrameworkCore;
using EventRegistrationAPI_RostyslavShcherbyk.Models;

namespace EventRegistrationAPI_RostyslavShcherbyk.Data
{
    public class AppDbContext : DbContext
    {
        // Passes database connection settings to Entity Framework Core
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; } // Table that stores all campus events
        public DbSet<Registration> Registrations { get; set; } // Table that stores all event regisrations






        // Add some data to database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add a few campus events for testing
            modelBuilder.Entity<Event>().HasData(

                // Past event - Registration is closed
                new Event
                {
                    EventId = 1,
                    Title = "Campus Welcome Day",
                    Location = "Davis Campus",
                    EventDate = new DateTime(2026, 9, 15, 10, 0, 0),
                    Capacity = 50
                },

                // Future event with avalable spots
                new Event
                {
                    EventId = 2,
                    Title = "Game Development Workshop",
                    Location = "Trafalgar Campus",
                    EventDate = new DateTime(2027, 1, 20, 12, 0, 0),
                    Capacity = 30
                },

                // Future event with no available spots
                new Event
                {
                    EventId = 3,
                    Title = "Career Networking Event",
                    Location = "Hazel McCallion Campus",
                    EventDate = new DateTime(2027, 2, 10, 14, 0, 0),
                    Capacity = 2
                },

                // Another future event with available spots
                new Event
                {
                    EventId = 4,
                    Title = "Programming Competition",
                    Location = "Davis Campus",
                    EventDate = new DateTime(2027, 3, 15, 11, 0, 0),
                    Capacity = 40
                }
            );



            // Add 2 registrations to vent 3 to make it full
            modelBuilder.Entity<Registration>().HasData(
                new Registration
                {
                    RegistrationId = 1,
                    EventId = 3,
                    StudentName = "Alex Smith",
                    Email = "alex@example.com",
                    RegisteredOn = new DateTime(2026, 11, 20, 10, 0, 0)
                },

                new Registration
                {
                    RegistrationId = 2,
                    EventId = 3,
                    StudentName = "Daniel Brown",
                    Email = "daniel@example.com",
                    RegisteredOn = new DateTime(2026, 11, 21, 12, 0, 0)
                }
            );



        }





    }
}
