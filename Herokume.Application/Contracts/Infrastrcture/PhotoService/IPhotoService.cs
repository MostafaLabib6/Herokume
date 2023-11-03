using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Herokume.Application.Contracts.Infrastrcture.PhotoService;

public interface IPhotoService
{
    public Task<ImageUploadResult> AddImage(IFormFile file);
    public Task<DeletionResult> DeleteImage(string publicId);
}
