using Restaurant.Core.Request;
using Restaurant.Core.Response;

namespace Restaurant.Core.Services
{
    public interface IStorageService
    {
        Task<UploadResponse> Save(UploadRequest request);
        Task Delete(string path);
    }
}
