namespace AutoEmailService.Model
{
    public class SmtpModel
    {
        public string? HostAddress { get; set; }
        public int? PortNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
    }
}
