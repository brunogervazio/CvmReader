namespace CvmReader.Application.Dtos
{
    public class QuarterlyInformationBp
    {
        public string CnpjCompanhia { get; set; } = string.Empty;
        public DateOnly DataReferencia { get; set; }
        public int Versao { get; set; }
        public string DenominacaoSocial { get; set; } = string.Empty;
        public int CodigoCvm { get; set; }
        public string GrupoDemonstacao { get; set; } = string.Empty;
        public string Moeda { get; set; } = string.Empty;
        public string EscalaMoeda { get; set; } = string.Empty;
        public string OrdemExercicio { get; set; } = string.Empty;
        public DateOnly DataFimExercicio { get; set; }
        public string CodigoConta { get; set; } = string.Empty;
        public string DescricaoConta { get; set; } = string.Empty;
        public decimal ValorConta { get; set; }
        public bool ContaFixa { get; set; }
    }
}
