using CvmReader.Application.Dtos;
using CvmReader.Application.Dtos.Request;
using CvmReader.Application.Dtos.Response;

namespace CvmReader.Application.Interfaces
{
    public interface ICompaniesService
    {
        Task<ServicePaginationResponse<List<Companie>>>
            GetAllRegisteredCompanies(PaginationRequest request);

        Task<ServicePaginationResponse<List<T>>> 
            GetItrByCnpj<T>(string report, string type, string cnpj, int year, PaginationRequest pagination);
    }
}
