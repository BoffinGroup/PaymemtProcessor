using PaymentProcessor.Domain.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentProcessor.Domain.DTOs
{
    public class CardInfoDTO
    {
        [Required(ErrorMessage = "CreditCardNumber is required")]
        [CreditCard]
        public string CreditCardNumber { get; set; }
        [Required(ErrorMessage = "CardHolder is required")]
        public string CardHolder { get; set; }
        [CurrentDate(ErrorMessage = "Date must be after or equal to current date")]
        public DateTime ExpiryDate { get; set; }
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Security code must 3 digits ")]
        public string SecurityCode { get; set; }


        [Required(ErrorMessage = "Amount is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public decimal Amount { get; set; }
    }
}
