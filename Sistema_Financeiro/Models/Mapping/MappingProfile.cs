using APIs.Models.DTOs;
using AutoMapper;
using Domain.Entities;



namespace APIs.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoriaDTO, Categoria>().ReverseMap();
            CreateMap<DespesaDTO, Despesa>().ReverseMap();
            CreateMap<SistemaFinanceiroDTO, SistemaFinanceiro>().ReverseMap();
            CreateMap<UsuarioSistemaFinanceiroDTO, UsuarioSistemaFinanceiro>().ReverseMap();
        }
    }
}
