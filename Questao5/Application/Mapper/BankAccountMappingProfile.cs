using AutoMapper;
using Questao5.Application.Queries.Responses;
using Questao5.Domain.Entities;

namespace Questao5.Application.Mapper
{
    public class BankAccountMappingProfile : Profile
    {
        public BankAccountMappingProfile()
        {
            CreateMap<BankAccount, BankAccountGetBalanceResponse>()
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.GetBalance()))
                .ForMember(dest => dest.Date, opt => opt.Ignore());
        }
    }
}
