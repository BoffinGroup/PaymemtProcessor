using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using PaymentProcessor.Domain.DTOs;
using PaymentProcessor.Domain.Entities;

namespace PaymentProcessor.Domain.Profiles
{
    public class CardProfiles:Profile
    {
        public CardProfiles()
        {
            CreateMap<CardInfoDTO, CardInfo>();
        }
    }
}
