namespace POSBackend_API.Dtos
{
    public class RegisterResponseDto
    {
        public bool Success {get; set;}
        public string? Message {get; set;}
        public string? UserId {get; set;}
    }
}