using PaymentProcessor.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentProcessor.Domain.Entities
{
    public class PaymentState
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime PayDate { get; set; }
        [Required]
        public State State { get; set; }
        [Required]
        public string CorrelationId { get; set; }
        [Required]
        public string RequestString { get; set; }
        [Required]
        public string ResponseString { get; set; }
    }
}
