using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
