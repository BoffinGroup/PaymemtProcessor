using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProcessor.Domain.DTOs
{
    public class APIResponse
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public object Data { get; set; }
    }
}
