using Swashbuckle.AspNetCore.Annotations;

namespace CvmReader.Application.Dtos.Response
{
    public class Pagination
    {
        [SwaggerSchema("Número da página atual.")]
        public int Page { get; set; }

        [SwaggerSchema("Número de itens da página.")]
        public int PageSize { get; set; }

        [SwaggerSchema("Número total de itens disponíveis.")]
        public int TotalItems { get; set; }

        [SwaggerSchema("Número total de páginas.")]
        public int TotalPages { get; set; }
    }
}
