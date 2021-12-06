﻿using AutoMapper;
using SharpBank.API.DTOs.Account;
using SharpBank.API.DTOs.Bank;
using SharpBank.Models;

namespace SharpBank.API.Profiles
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateBankDTO,Bank>();
            CreateMap<UpdateBankDTO, Bank>();
            CreateMap<Bank,GetBankDTO>();
            CreateMap<CreateAccountDTO, Account>();
            CreateMap<UpdateAccountDTO, Account>();
            CreateMap<Account, GetAccountDTO>();
        }
    }
}
