using AutoMapper;
using ApiBoasPraticas.Models;
using ApiBoasPraticas.DTOs;

namespace ApiBoasPraticas.DTOs
{
    /// <summary>
    /// Configuração do AutoMapper - Demonstra DRY
    /// Mapeamentos centralizados em um lugar
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Pessoa -> PessoaDto
            CreateMap<Pessoa, PessoaDto>();

            // CreatePessoaDto -> Pessoa
            CreateMap<CreatePessoaDto, Pessoa>();

            // UpdatePessoaDto -> Pessoa (para updates parciais)
            CreateMap<UpdatePessoaDto, Pessoa>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}