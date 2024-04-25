using System.Data;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AutoEmailService.Model
{
    public class MailData
    {
        public string? EmailSubject { get; set; }
        public string? EmailBody { get; set; }
        public string? EmailToTable { get; set; }
    }
}
