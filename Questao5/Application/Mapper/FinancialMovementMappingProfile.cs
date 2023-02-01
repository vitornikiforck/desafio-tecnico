using AutoMapper;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Entities;

namespace Questao5.Application.Mapper
{
    public class FinancialMovementMappingProfile : Profile
    {
        public FinancialMovementMappingProfile()
        {
            CreateMap<CreateFinancialMovementCommand, FinancialMovement>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => System.Guid.NewGuid().ToString().ToUpper()));
            CreateMap<FinancialMovement, CreateFinancialMovementResponse>();
        }
    }
}
