using AccountingNotebookAPI.DTOs;
using AccountingNotebookAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebookAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Account, AccountDTO>();

            CreateMap<Transaction, TransactionDetailDTO>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => RenderType(src.Type)))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount*(-1)));
                

            CreateMap<Transaction, TransactionForListDTO>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => RenderType(src.Type)))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount * (-1)));
        }

        private string RenderType(TransactionType type) {
            switch (type)
            {
                case TransactionType.credit:
                    return "Credit";
                case TransactionType.debit:
                    return "Debit";
            }
            return "Error";
        }
    }
}
