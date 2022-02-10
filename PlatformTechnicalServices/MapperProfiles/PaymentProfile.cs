﻿using AutoMapper;
using Iyzipay.Model;
using PlatformTechnicalServices.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformTechnicalServices.MapperProfiles
{
    public class PaymentProfile:Profile
    {
        public PaymentProfile()
        {
            CreateMap<InstallmentPriceModel, InstallmentPrice>().ReverseMap();//tersi de çalşsın anlamına gelir aşağıdakini yazmaya gerek kalmaz
            //CreateMap<InstallmentPrice,InstallmentPriceModel>();
            CreateMap<InstallmentModel, InstallmentDetail>().ReverseMap();
            CreateMap<BasketModel, BasketItem>().ReverseMap();
            CreateMap<CardModel, PaymentCard>().ReverseMap();
            CreateMap<AddressModel, Address>().ReverseMap();
            CreateMap<CustomerModel, Buyer>().ReverseMap();
            CreateMap<PaymentResponseModel, Payment>().ReverseMap();
        }
    }
}
