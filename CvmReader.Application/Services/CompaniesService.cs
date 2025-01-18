using AutoMapper;
using CvmReader.Application.Dtos;
using CvmReader.Application.Dtos.Request;
using CvmReader.Application.Dtos.Response;
using CvmReader.Application.Helpers;
using CvmReader.Application.Interfaces;
using System.Text;

namespace CvmReader.Application.Services
{
    public class CompaniesService(HttpClient httpClient, IMapper mapper) : ICompaniesService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IMapper _mapper = mapper;

        private readonly Dictionary<string, string> reportType = new()
        {
            { "consolidado", "con" },
            { "individual", "ind" },
        };

        public async Task<ServicePaginationResponse<List<Companie>>>
            GetAllRegisteredCompanies(PaginationRequest pagination)
        {
            var file = await GetFile("cad_cia_aberta");
            file ??= await DownloadCadCiaAberta();

            var data = await ReadFile(file!);

            return CreateServicePagination<Companie>(data, pagination);
        }

        public async Task<ServicePaginationResponse<List<T>>>
            GetItrByCnpj<T>(string report, string type, string cnpj, int year, PaginationRequest pagination)
        {
            string formattedCnpj = cnpj.CnpjFormatter();
            string fileName = string.Format("itr_cia_aberta_{0}_{1}_{2}", report, reportType[type], year);

            var file = await GetFile(fileName);
            file ??= await DownloadItrCiaAbertaByYear(year, fileName);

            var data = await ReadFile(file!);
            var filteredCompanies = data.FindAll(d => d.Contains(formattedCnpj));

            return CreateServicePagination<T>(filteredCompanies, pagination);
        }

        private ServicePaginationResponse<List<T>>
            CreateServicePagination<T>(List<string> data, PaginationRequest pagination)
        {
            var totalItems = data.Count;
            var dataFilter = data
                .Skip((pagination.Page - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToList();

            return new ServicePaginationResponse<List<T>>()
            {
                Data = _mapper.Map<List<T>>(dataFilter.Select(e => e.Split(";"))),
                Pagination = new Pagination()
                {
                    Page = pagination.Page,
                    PageSize = dataFilter.Count,
                    TotalItems = totalItems,
                    TotalPages = (int)Math.Ceiling(totalItems / (double)pagination.PageSize)
                }
            };
        }

        private static async Task<List<string>> ReadFile(byte[] file)
        {
            var stream = new MemoryStream(file);

            var reader = new StreamReader(stream, Encoding.GetEncoding("ISO-8859-1"));
            var text = await reader.ReadToEndAsync();

            return text.Split("\r\n").Skip(1)
               .Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
        }

        private async Task<byte[]?> DownloadCadCiaAberta()
        {
            string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", $"cad_cia_aberta_{DateTime.Now:yyyy-MM-dd}.csv");

            var response = await _httpClient.GetAsync("https://dados.cvm.gov.br/dados/CIA_ABERTA/CAD/DADOS/cad_cia_aberta.csv");
            response.EnsureSuccessStatusCode();

            var csvContent = await response.Content.ReadAsByteArrayAsync();
            await FileHelper.SaveFileAsync(pathFile, csvContent);

            return csvContent;
        }

        private async Task<byte[]?> DownloadItrCiaAbertaByYear(int year, string file)
        {
            string url = string.Format("https://dados.cvm.gov.br/dados/CIA_ABERTA/DOC/ITR/DADOS/itr_cia_aberta_{0}.zip", year);

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsByteArrayAsync();

            FileHelper.ExtractZipFiles(content, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files"));

            return await GetFile(file);
        }

        private static async Task<byte[]?> GetFile(string name)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");

            FileHelper.DeleteOldFiles(path);

            var files = FileHelper.SearchFilePathByName(path, name);

            return files is null
                ? null
                : await File.ReadAllBytesAsync(files.First());
        }
    }
}
