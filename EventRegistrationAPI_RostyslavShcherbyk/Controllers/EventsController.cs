// This file handles API requests related to campus events

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventRegistrationAPI_RostyslavShcherbyk.DTOs;
using EventRegistrationAPI_RostyslavShcherbyk.Services;

namespace EventRegistrationAPI_RostyslavShcherbyk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        // Gets access to the event service
        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }





        // GET: api/Events          -          Get all campus events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents()
        {
            var events = await _eventService.GetAllAsync();
            return Ok(events);
        }

        // GET: api/Events/5          -          Get specific event by its ID
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetEvent(int id)
        {
            var campusEvent = await _eventService.GetByIdAsync(id);

            // Return 404 if event does not exist
            if (campusEvent == null)
                return NotFound();

            return Ok(campusEvent);
        }





        // POST: api/Events          -          Create a new campus event
        [HttpPost]
        public async Task<ActionResult<EventDto>> CreateEvent(CreateEventDto dto)
        {
            // Create new event using event service
            var created = await _eventService.CreateAsync(dto);

            // Return 201 with the newly created event
            return CreatedAtAction(nameof(GetEvent), new { id = created.EventId }, created);
        }







    }
}
