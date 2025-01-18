using CvmReader.Application.Dtos;
using CvmReader.Application.Dtos.Request;
using CvmReader.Application.Dtos.Response;
using CvmReader.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CvmReader.Web.Controllers
{
    [ApiController]
    [Route("api/v1/companies")]
    public class CompaniesController(ICompaniesService companiesService) : ControllerBase
    {
        private readonly ICompaniesService _companiesService = companiesService;

        /// <summary>
        ///     Cias Abertas: Informação Cadastral
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>
        ///     Retorna dados cadastrais de companhias abertas, como CNPJ, data de registro e situação do registro.
        /// </returns>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Cias Abertas: Informação Cadastral",
            Description = "Retorna dados cadastrais de companhias abertas, como CNPJ, data de registro e situação do registro.")]
        public async Task<ActionResult<ServicePaginationResponse<List<Companie>>>>
            GetAll([FromQuery] PaginationRequest pagination)
        {
            var result = await _companiesService.GetAllRegisteredCompanies(pagination);
            return Ok(result);
        }

        /// <summary>
        ///     Balanço Patrimonial Ativo (BPA)
        /// </summary>
        /// <param name="type"></param>
        /// <param name="cnpj"></param>
        /// <param name="year"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("BPA/{type}/{cnpj}/{year}")]
        [SwaggerOperation(Summary = "Balanço Patrimonial Ativo (BPA)")]
        public async Task<ActionResult<ServicePaginationResponse<List<QuarterlyInformation>>>>
            GetBpa(
                [FromRoute, SwaggerParameter("Tipo de relatorio CONSOLIDADO/INDIVIDUAL", Required = true)] string type,
                [FromRoute, SwaggerParameter("CNPJ da companhia", Required = true)] string cnpj,
                [FromRoute, SwaggerParameter("Ano das informações trimestrais da companhia", Required = true)] int year,
                [FromQuery] PaginationRequest pagination)
        {
            var result = await _companiesService.GetItrByCnpj<QuarterlyInformationBp>("BPA", type, cnpj, year, pagination);
            return Ok(result);
        }

        /// <summary>
        ///     Balanço Patrimonial Passivo (BPP)
        /// </summary>
        /// <param name="type"></param>
        /// <param name="cnpj"></param>
        /// <param name="year"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("BPP/{type}/{cnpj}/{year}")]
        [SwaggerOperation(Summary = "Balanço Patrimonial Passivo (BPP)")]
        public async Task<ActionResult<ServicePaginationResponse<List<QuarterlyInformation>>>>
            GetBpp(
                [FromRoute, SwaggerParameter("Tipo de relatorio CONSOLIDADO/INDIVIDUAL", Required = true)] string type,
                [FromRoute, SwaggerParameter("CNPJ da companhia", Required = true)] string cnpj,
                [FromRoute, SwaggerParameter("Ano das informações trimestrais da companhia", Required = true)] int year,
                [FromQuery] PaginationRequest pagination)
        {
            var result = await _companiesService.GetItrByCnpj<QuarterlyInformationBp>("BPP", type, cnpj, year, pagination);
            return Ok(result);
        }

        /// <summary>
        ///     Demonstração de Fluxo de Caixa - Método Direto (DFC-MD)
        /// </summary>
        /// <param name="type"></param>
        /// <param name="cnpj"></param>
        /// <param name="year"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("DFC-MD/{type}/{cnpj}/{year}")]
        [SwaggerOperation(Summary = "Demonstração de Fluxo de Caixa - Método Direto (DFC-MD)")]
        public async Task<ActionResult<ServicePaginationResponse<List<QuarterlyInformation>>>>
            GetDfcMd(
                [FromRoute, SwaggerParameter("Tipo de relatorio CONSOLIDADO/INDIVIDUAL", Required = true)] string type,
                [FromRoute, SwaggerParameter("CNPJ da companhia", Required = true)] string cnpj,
                [FromRoute, SwaggerParameter("Ano das informações trimestrais da companhia", Required = true)] int year,
                [FromQuery] PaginationRequest pagination)
        {
            var result = await _companiesService.GetItrByCnpj<QuarterlyInformation>("DFC_MD", type, cnpj, year, pagination);
            return Ok(result);
        }

        /// <summary>
        ///     Demonstração de Fluxo de Caixa - Método Indireto (DFC-MI)
        /// </summary>
        /// <param name="type"></param>
        /// <param name="cnpj"></param>
        /// <param name="year"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("DFC-MI/{type}/{cnpj}/{year}")]
        [SwaggerOperation(Summary = "Demonstração de Fluxo de Caixa - Método Indireto (DFC-MI)")]
        public async Task<ActionResult<ServicePaginationResponse<List<QuarterlyInformation>>>>
            GetDfcMi(
                [FromRoute, SwaggerParameter("Tipo de relatorio CONSOLIDADO/INDIVIDUAL", Required = true)] string type,
                [FromRoute, SwaggerParameter("CNPJ da companhia", Required = true)] string cnpj,
                [FromRoute, SwaggerParameter("Ano das informações trimestrais da companhia", Required = true)] int year,
                [FromQuery] PaginationRequest pagination)
        {
            var result = await _companiesService.GetItrByCnpj<QuarterlyInformation>("DFC_MI", type, cnpj, year, pagination);
            return Ok(result);
        }

        /// <summary>
        ///     Demonstração das Mutações do Patrimônio Líquido (DMPL)
        /// </summary>
        /// <param name="type"></param>
        /// <param name="cnpj"></param>
        /// <param name="year"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("DMPL/{type}/{cnpj}/{year}")]
        [SwaggerOperation(Summary = "Demonstração das Mutações do Patrimônio Líquido (DMPL)")]
        public async Task<ActionResult<ServicePaginationResponse<List<QuarterlyInformation>>>>
            GetDmpl(
                [FromRoute, SwaggerParameter("Tipo de relatorio CONSOLIDADO/INDIVIDUAL", Required = true)] string type,
                [FromRoute, SwaggerParameter("CNPJ da companhia", Required = true)] string cnpj,
                [FromRoute, SwaggerParameter("Ano das informações trimestrais da companhia", Required = true)] int year,
                [FromQuery] PaginationRequest pagination)
        {
            var result = await _companiesService.GetItrByCnpj<QuarterlyInformationDmpl>("DMPL", type, cnpj, year, pagination);
            return Ok(result);
        }

        /// <summary>
        ///     Demonstração de Resultado Abrangente (DRA)
        /// </summary>
        /// <param name="type"></param>
        /// <param name="cnpj"></param>
        /// <param name="year"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("DRA/{type}/{cnpj}/{year}")]
        [SwaggerOperation(Summary = "Demonstração de Resultado Abrangente (DRA)")]
        public async Task<ActionResult<ServicePaginationResponse<List<QuarterlyInformation>>>>
            GetDra(
                [FromRoute, SwaggerParameter("Tipo de relatorio CONSOLIDADO/INDIVIDUAL", Required = true)] string type,
                [FromRoute, SwaggerParameter("CNPJ da companhia", Required = true)] string cnpj,
                [FromRoute, SwaggerParameter("Ano das informações trimestrais da companhia", Required = true)] int year,
                [FromQuery] PaginationRequest pagination)
        {
            var result = await _companiesService.GetItrByCnpj<QuarterlyInformation>("DRA", type, cnpj, year, pagination);
            return Ok(result);
        }

        /// <summary>
        ///     Demonstração de Resultado (DRE)
        /// </summary>
        /// <param name="type"></param>
        /// <param name="cnpj"></param>
        /// <param name="year"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("DRE/{type}/{cnpj}/{year}")]
        [SwaggerOperation(Summary = "Demonstração de Resultado (DRE)")]
        public async Task<ActionResult<ServicePaginationResponse<List<QuarterlyInformation>>>>
            GetDre(
                [FromRoute, SwaggerParameter("Tipo de relatorio CONSOLIDADO/INDIVIDUAL", Required = true)] string type,
                [FromRoute, SwaggerParameter("CNPJ da companhia", Required = true)] string cnpj,
                [FromRoute, SwaggerParameter("Ano das informações trimestrais da companhia", Required = true)] int year,
                [FromQuery] PaginationRequest pagination)
        {
            var result = await _companiesService.GetItrByCnpj<QuarterlyInformation>("DRE", type, cnpj, year, pagination);
            return Ok(result);
        }

        /// <summary>
        ///     Demonstração de Valor Adicionado (DVA)
        /// </summary>
        /// <param name="type"></param>
        /// <param name="cnpj"></param>
        /// <param name="year"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("DVA/{type}/{cnpj}/{year}")]
        [SwaggerOperation(Summary = "Demonstração de Valor Adicionado (DVA)")]
        public async Task<ActionResult<ServicePaginationResponse<List<QuarterlyInformation>>>>
            GetDva(
                [FromRoute, SwaggerParameter("Tipo de relatorio CONSOLIDADO/INDIVIDUAL", Required = true)] string type,
                [FromRoute, SwaggerParameter("CNPJ da companhia", Required = true)] string cnpj,
                [FromRoute, SwaggerParameter("Ano das informações trimestrais da companhia", Required = true)] int year,
                [FromQuery] PaginationRequest pagination)
        {
            var result = await _companiesService.GetItrByCnpj<QuarterlyInformation>("DVA", type, cnpj, year, pagination);
            return Ok(result);
        }
    }
}
