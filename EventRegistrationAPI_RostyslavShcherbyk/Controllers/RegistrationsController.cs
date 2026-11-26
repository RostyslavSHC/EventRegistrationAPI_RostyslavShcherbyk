// this file handles API requessts for event registrations

using EventRegistrationAPI_RostyslavShcherbyk.DTOs;
using EventRegistrationAPI_RostyslavShcherbyk.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventRegistrationAPI_RostyslavShcherbyk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        // Gets access to the registration service
        public RegistrationsController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }





        // GET: api/Events/3/registrations          -          Get all registrations for specific event
        [HttpGet("/api/events/{id}/registrations")]
        public async Task<ActionResult<IEnumerable<RegistrationDto>>> GetRegistrations(int id)
        {
            var registrations = await _registrationService.GetAllAsync(id);

            // Return 404 if event does not exist
            if (registrations == null)
                return NotFound();

            return Ok(registrations);
        }







        // POST: api/Events/3/registrations          -          Register person for specific event
        [HttpPost("/api/events/{id}/registrations")]
        public async Task<ActionResult<RegistrationDto>> CreateRegistration(int id, CreateRegistrationDto dto)
        {
            try
            {
                // Create registration using registration service
                var created = await _registrationService.CreateAsync(id, dto);

                // Return 404 if event does not exist
                if (created == null)
                    return NotFound();

                // Return 201 with newly created registration
                return StatusCode(201, created);
            }
            catch (ArgumentException ex)
            {
                // Return 400 if event is in the past
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Return 409 if email is already registered or event is full
                return Conflict(ex.Message);
            }
        }






        // DELETE: api/Registrations/1          -          Cancel registration by it's ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            bool deleted = await _registrationService.DeleteAsync(id);

            // Return 404 if registration doesn't exist
            if (!deleted)
                return NotFound();

            // Return 204 if registration was sucessfully deleted
            return NoContent();
        }









    }
}
