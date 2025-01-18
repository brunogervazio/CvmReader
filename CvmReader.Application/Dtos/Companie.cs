namespace CvmReader.Application.Dtos
{
    public class Companie
    {
        public string CnpjCompanhia { get; set; } = string.Empty;
        public string DenominacaoSocial { get; set; } = string.Empty;
        public string DenominacaoComercercial { get; set; } = string.Empty;
        public DateOnly? DataRegime { get; set; }
        public DateOnly? DataConstituicao { get; set; }
        public DateOnly? DataCancelamento { get; set; }
        public string MotivoCancelamento { get; set; } = string.Empty;
        public string Situacao { get; set; } = string.Empty;
        public DateOnly? DataInicioSituacao { get; set; }
        public int CodigoCvm { get; set; }
        public string SetorAtivividade { get; set; } = string.Empty;
        public string TipoMercado { get; set; } = string.Empty;
        public string CategoriaRegistro { get; set; } = string.Empty;
        public DateOnly? DataInicioCategoriaRegistro { get; set; }
        public string SituacaoEmissor { get; set; } = string.Empty;
        public DateOnly? DataInicioSituacaoEmissor { get; set; } 
        public string ControleAcionario { get; set; } = string.Empty;
        public Endereco EnderecoCompanhia { get; set; } = new();
        public Contato ContatoCompanhia { get; set; } = new();
        public Responsavel Responsavel { get; set; } = new();
        public Auditor Auditor { get; set; } = new();
    }

    public class Responsavel
    {
        public string Tipo { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public DateOnly DataInicioAtuacao { get; set; }
        public Endereco Endereco { get; set; } = new();
        public Contato Contato { get; set; } = new();
    }

    public class Endereco
    {
        public string TipoEndereco { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Municipio { get; set; } = string.Empty;
        public string UnidadeFederativa { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
    }

    public class Contato
    {
        public string DddTelefone { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string DddFax { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class Auditor
    {
        public string Nome { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
    }
}
