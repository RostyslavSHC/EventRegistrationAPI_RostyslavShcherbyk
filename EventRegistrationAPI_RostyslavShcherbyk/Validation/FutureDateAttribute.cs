// This file checks if event date and time are in the future

using System.ComponentModel.DataAnnotations;

namespace EventRegistrationAPI_RostyslavShcherbyk.Validation
{
    public class FutureDateAttribute : ValidationAttribute
    {
        // Check if provided date and time are in the future
        public override bool IsValid(object? value)
        {
            if (value is DateTime date)
            {
                return date > DateTime.Now;
            }

            return false;
        }
    }
}
