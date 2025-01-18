namespace CvmReader.Application.Dtos.Response
{
    public class ServicePaginationResponse<T> : ServiceResponse<T>
    {
        public Pagination Pagination { get; set; } = new();
    }
}
