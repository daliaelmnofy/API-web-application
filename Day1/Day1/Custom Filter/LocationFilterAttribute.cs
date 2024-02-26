using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Day1.Models;

namespace Day1.Custom_Filter
{
    public class LocationFilterAttribute : ActionFilterAttribute
    {
        private readonly string[] _allowedLocations;

        public LocationFilterAttribute(params string[] allowedLocations)
        {
            _allowedLocations = allowedLocations;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var department = context.ActionArguments["department"] as Department;

            // Check if the department's location is allowed
            if (!_allowedLocations.Contains(department.Location, StringComparer.OrdinalIgnoreCase))
            {
                context.Result = new BadRequestObjectResult($"Location '{department.Location}' is not allowed.");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}

