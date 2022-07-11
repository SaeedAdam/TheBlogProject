using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TheBlogProject.Services
{
    public interface IImageService
    {
        Task<byte[]> EncodeImageAsync(IFormFile file);
        Task<byte[]> EncodeImageAsync(string fileName);
        string DecodeImageAsync(byte[] data, string type);
        string GetContentType(IFormFile file);
        int GetImageSize(IFormFile file);
    }
}
