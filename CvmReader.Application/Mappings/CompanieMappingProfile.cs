using AutoMapper;
using CvmReader.Application.Dtos;
using CvmReader.Application.Helpers;

namespace CvmReader.Application.Mappings
{
    public class CompanieMappingProfile : Profile
    {
        public CompanieMappingProfile()
        {
            CreateMap<string[], Companie>()
                .ForMember(dest => dest.CnpjCompanhia,
                    opt => opt.MapFrom(src => src[0]))
                .ForMember(dest => dest.DenominacaoSocial,
                    opt => opt.MapFrom(src => src[1]))
                .ForMember(dest => dest.DenominacaoComercercial,
                    opt => opt.MapFrom(src => src[2]))
                .ForMember(dest => dest.DataRegime,
                    opt => opt.MapFrom(src => src[3].TryConvertDateOnly()))
                .ForMember(dest => dest.DataConstituicao,
                    opt => opt.MapFrom(src => src[4].TryConvertDateOnly()))
                .ForMember(dest => dest.DataCancelamento,
                    opt => opt.MapFrom(src => src[5].TryConvertDateOnly()))
                .ForMember(dest => dest.MotivoCancelamento,
                    opt => opt.MapFrom(src => src[6]))
                .ForMember(dest => dest.Situacao,
                    opt => opt.MapFrom(src => src[7]))
                .ForMember(dest => dest.DataInicioSituacao,
                    opt => opt.MapFrom(src => src[8].TryConvertDateOnly()))
                .ForMember(dest => dest.CodigoCvm,
                    opt => opt.MapFrom(src => int.Parse(src[9])))
                .ForMember(dest => dest.SetorAtivividade,
                    opt => opt.MapFrom(src => src[10]))
                .ForMember(dest => dest.TipoMercado,
                    opt => opt.MapFrom(src => src[11]))
                .ForMember(dest => dest.CategoriaRegistro,
                    opt => opt.MapFrom(src => src[12]))
                .ForMember(dest => dest.DataInicioCategoriaRegistro,
                    opt => opt.MapFrom(src => src[13].TryConvertDateOnly()))
                .ForMember(dest => dest.SituacaoEmissor,
                    opt => opt.MapFrom(src => src[14]))
                .ForMember(dest => dest.DataInicioSituacaoEmissor,
                    opt => opt.MapFrom(src => src[15].TryConvertDateOnly()))
                .ForMember(dest => dest.ControleAcionario,
                    opt => opt.MapFrom(src => src[16]))
                .ForPath(dest => dest.EnderecoCompanhia.TipoEndereco,
                    opt => opt.MapFrom(src => src[17]))
                .ForPath(dest => dest.EnderecoCompanhia.Logradouro,
                    opt => opt.MapFrom(src => src[18]))
                .ForPath(dest => dest.EnderecoCompanhia.Complemento,
                    opt => opt.MapFrom(src => src[19]))
                .ForPath(dest => dest.EnderecoCompanhia.Bairro,
                    opt => opt.MapFrom(src => src[20]))
                .ForPath(dest => dest.EnderecoCompanhia.Municipio,
                    opt => opt.MapFrom(src => src[21]))
                .ForPath(dest => dest.EnderecoCompanhia.UnidadeFederativa,
                    opt => opt.MapFrom(src => src[22]))
                .ForPath(dest => dest.EnderecoCompanhia.Pais,
                    opt => opt.MapFrom(src => src[23]))
                .ForPath(dest => dest.EnderecoCompanhia.Cep,
                    opt => opt.MapFrom(src => src[24].CepFormatter()))
                .ForPath(dest => dest.ContatoCompanhia.DddTelefone,
                    opt => opt.MapFrom(src => src[25]))
                .ForPath(dest => dest.ContatoCompanhia.Telefone,
                    opt => opt.MapFrom(src => src[26].PhoneFormatter()))
                .ForPath(dest => dest.ContatoCompanhia.DddFax,
                    opt => opt.MapFrom(src => src[27]))
                .ForPath(dest => dest.ContatoCompanhia.Fax,
                    opt => opt.MapFrom(src => src[28].PhoneFormatter()))
                .ForPath(dest => dest.ContatoCompanhia.Email,
                    opt => opt.MapFrom(src => src[29]))
                .ForPath(dest => dest.Responsavel.Tipo,
                    opt => opt.MapFrom(src => src[30]))
                .ForPath(dest => dest.Responsavel.Nome,
                    opt => opt.MapFrom(src => src[31]))
                .ForPath(dest => dest.Responsavel.DataInicioAtuacao,
                    opt => opt.MapFrom(src => src[32].TryConvertDateOnly()))
                .ForPath(dest => dest.Responsavel.Endereco.Logradouro,
                    opt => opt.MapFrom(src => src[33]))
                .ForPath(dest => dest.Responsavel.Endereco.Complemento,
                    opt => opt.MapFrom(src => src[34]))
                .ForPath(dest => dest.Responsavel.Endereco.Bairro,
                    opt => opt.MapFrom(src => src[35]))
                .ForPath(dest => dest.Responsavel.Endereco.Municipio,
                    opt => opt.MapFrom(src => src[36]))
                .ForPath(dest => dest.Responsavel.Endereco.UnidadeFederativa,
                    opt => opt.MapFrom(src => src[37]))
                .ForPath(dest => dest.Responsavel.Endereco.Pais,
                    opt => opt.MapFrom(src => src[38]))
                .ForPath(dest => dest.Responsavel.Endereco.Cep,
                    opt => opt.MapFrom(src => src[39].CepFormatter()))
                .ForPath(dest => dest.Responsavel.Contato.DddTelefone,
                    opt => opt.MapFrom(src => src[40]))
                .ForPath(dest => dest.Responsavel.Contato.Telefone,
                    opt => opt.MapFrom(src => src[41].PhoneFormatter()))
                .ForPath(dest => dest.Responsavel.Contato.DddFax,
                    opt => opt.MapFrom(src => src[42]))
                .ForPath(dest => dest.Responsavel.Contato.Fax,
                    opt => opt.MapFrom(src => src[43].PhoneFormatter()))
                .ForPath(dest => dest.Responsavel.Contato.Email,
                    opt => opt.MapFrom(src => src[44]))
                .ForPath(dest => dest.Auditor.Cnpj,
                    opt => opt.MapFrom(src => src[45]))
                .ForPath(dest => dest.Auditor.Nome,
                    opt => opt.MapFrom(src => src[46]));
        }
    }
}
