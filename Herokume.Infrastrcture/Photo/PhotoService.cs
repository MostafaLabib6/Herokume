using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Herokume.Application.Contracts.Infrastrcture.PhotoService;
using Herokume.Application.Models.Photo;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Herokume.Infrastrcture.Photo;

public class PhotoService : IPhotoService
{
    private readonly Cloudinary _cloudinary;

    public PhotoService(IOptions<PhotoSettings> options)
    {
        var account = new Account(
            cloud: options.Value.CloudName,
            apiKey: options.Value.ApiKey,
            apiSecret: options.Value.ApiSecret
            );
        _cloudinary = new Cloudinary(account);
    }
    public async Task<ImageUploadResult> AddImage(IFormFile file)
    {
        var uploadResult = new ImageUploadResult();
        if (file.Length > 0)
        {
            using var stream = file.OpenReadStream();
            var ImageParam = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation().Height(600).Width(450)
            };
            uploadResult = await _cloudinary.UploadAsync(ImageParam);
        }
        return uploadResult;
    }

    public async Task<DeletionResult> DeleteImage(string publicId)
    {
        var deleteResult = new DeletionParams(publicId);
        var result = await _cloudinary.DestroyAsync(deleteResult);
        return result;
    }
}
