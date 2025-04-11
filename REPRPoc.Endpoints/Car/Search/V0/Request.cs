using Microsoft.AspNetCore.Mvc;

namespace REPRPoc.Endpoints.Car.Search.V0
{
    public class Request
    {
        [FromQuery]
        public string? Plate { get; set; } = null;
        [FromQuery]
        public string? Maker { get; set; } = null;
        [FromQuery]
        public string? Model { get; set; } = null;
        [FromQuery]
        public string? Color { get; set; } = null;
    }
}
