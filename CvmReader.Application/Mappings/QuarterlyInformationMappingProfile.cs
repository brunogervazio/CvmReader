using AutoMapper;
using CvmReader.Application.Dtos;
using System.Globalization;

namespace CvmReader.Application.Mappings
{
    public class QuarterlyInformationMappingProfile : Profile
    {
        public QuarterlyInformationMappingProfile()
        {
            CreateMap<string[], QuarterlyInformation>()
               .ForMember(dest => dest.CnpjCompanhia, opt => opt.MapFrom(src => src[0]))
               .ForMember(dest => dest.DataReferencia, opt => opt.MapFrom(src => DateOnly.Parse(src[1])))
               .ForMember(dest => dest.Versao, opt => opt.MapFrom(src => int.Parse(src[2])))
               .ForMember(dest => dest.DenominacaoSocial, opt => opt.MapFrom(src => src[3]))
               .ForMember(dest => dest.CodigoCvm, opt => opt.MapFrom(src => int.Parse(src[4])))
               .ForMember(dest => dest.GrupoDemonstacao, opt => opt.MapFrom(src => src[5]))
               .ForMember(dest => dest.Moeda, opt => opt.MapFrom(src => src[6]))
               .ForMember(dest => dest.EscalaMoeda, opt => opt.MapFrom(src => src[7]))
               .ForMember(dest => dest.OrdemExercicio, opt => opt.MapFrom(src => src[8]))
               .ForMember(dest => dest.DataInicioExercicio, opt => opt.MapFrom(src => DateOnly.Parse(src[9])))
               .ForMember(dest => dest.DataFimExercicio, opt => opt.MapFrom(src => DateOnly.Parse(src[10])))
               .ForMember(dest => dest.CodigoConta, opt => opt.MapFrom(src => src[11]))
               .ForMember(dest => dest.DescricaoConta, opt => opt.MapFrom(src => src[12]))
               .ForMember(dest => dest.ValorConta, opt => opt.MapFrom(src => decimal.Parse(src[13], CultureInfo.InvariantCulture)))
               .ForMember(dest => dest.ContaFixa, opt => opt.MapFrom(src => src[14] == "S"));

            CreateMap<string[], QuarterlyInformationBp>()
              .ForMember(dest => dest.CnpjCompanhia, opt => opt.MapFrom(src => src[0]))
              .ForMember(dest => dest.DataReferencia, opt => opt.MapFrom(src => DateOnly.Parse(src[1])))
              .ForMember(dest => dest.Versao, opt => opt.MapFrom(src => int.Parse(src[2])))
              .ForMember(dest => dest.DenominacaoSocial, opt => opt.MapFrom(src => src[3]))
              .ForMember(dest => dest.CodigoCvm, opt => opt.MapFrom(src => int.Parse(src[4])))
              .ForMember(dest => dest.GrupoDemonstacao, opt => opt.MapFrom(src => src[5]))
              .ForMember(dest => dest.Moeda, opt => opt.MapFrom(src => src[6]))
              .ForMember(dest => dest.EscalaMoeda, opt => opt.MapFrom(src => src[7]))
              .ForMember(dest => dest.OrdemExercicio, opt => opt.MapFrom(src => src[8]))
              .ForMember(dest => dest.DataFimExercicio, opt => opt.MapFrom(src => DateOnly.Parse(src[9])))
              .ForMember(dest => dest.CodigoConta, opt => opt.MapFrom(src => src[10]))
              .ForMember(dest => dest.DescricaoConta, opt => opt.MapFrom(src => src[11]))
              .ForMember(dest => dest.ValorConta, opt => opt.MapFrom(src => decimal.Parse(src[12], CultureInfo.InvariantCulture)))
              .ForMember(dest => dest.ContaFixa, opt => opt.MapFrom(src => src[13] == "S"));

            CreateMap<string[], QuarterlyInformationDmpl>()
             .ForMember(dest => dest.CnpjCompanhia, opt => opt.MapFrom(src => src[0]))
             .ForMember(dest => dest.DataReferencia, opt => opt.MapFrom(src => DateOnly.Parse(src[1])))
             .ForMember(dest => dest.Versao, opt => opt.MapFrom(src => int.Parse(src[2])))
             .ForMember(dest => dest.DenominacaoSocial, opt => opt.MapFrom(src => src[3]))
             .ForMember(dest => dest.CodigoCvm, opt => opt.MapFrom(src => int.Parse(src[4])))
             .ForMember(dest => dest.GrupoDemonstacao, opt => opt.MapFrom(src => src[5]))
             .ForMember(dest => dest.Moeda, opt => opt.MapFrom(src => src[6]))
             .ForMember(dest => dest.EscalaMoeda, opt => opt.MapFrom(src => src[7]))
             .ForMember(dest => dest.OrdemExercicio, opt => opt.MapFrom(src => src[8]))
             .ForMember(dest => dest.DataInicioExercicio, opt => opt.MapFrom(src => DateOnly.Parse(src[9])))
             .ForMember(dest => dest.DataFimExercicio, opt => opt.MapFrom(src => DateOnly.Parse(src[10])))
             .ForMember(dest => dest.ColunaDemonstracaoFinanceira, opt => opt.MapFrom(src => src[11]))
             .ForMember(dest => dest.CodigoConta, opt => opt.MapFrom(src => src[12]))
             .ForMember(dest => dest.DescricaoConta, opt => opt.MapFrom(src => src[13]))
             .ForMember(dest => dest.ValorConta, opt => opt.MapFrom(src => decimal.Parse(src[14], CultureInfo.InvariantCulture)))
             .ForMember(dest => dest.ContaFixa, opt => opt.MapFrom(src => src[15] == "S"));
        }
    }
}
