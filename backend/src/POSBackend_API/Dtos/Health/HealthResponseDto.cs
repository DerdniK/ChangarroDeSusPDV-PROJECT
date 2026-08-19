namespace POSBackend_API.Dtos.Health
{
    public class HealthResponseDto
    {
        public string? Status {get; set;}
        public string? Version {get; set;}
        public DateTime Timestamp {get; set;}
    }
}