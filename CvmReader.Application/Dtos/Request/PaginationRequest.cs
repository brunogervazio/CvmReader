using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace CvmReader.Application.Dtos.Request
{
    public class PaginationRequest
    {
        [SwaggerSchema("Número da página que deseja consultar (inicia em 1).")]
        [Range(1, int.MaxValue, ErrorMessage = "O número da página deve ser maior ou igual a 1.")]
        public int Page { get; set; } = 1;

        [SwaggerSchema("Número de registros por página.")]
        public int PageSize { get; set; } = 20;
    }
}
