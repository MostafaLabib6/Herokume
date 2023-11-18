using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Herokume.Application.Contracts.Infrastrcture.PhotoService;
using Herokume.Application.Models.Photo;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Serilog;

namespace Herokume.Infrastrcture.Photo;

public class PhotoService : IPhotoService
{
    private readonly Cloudinary _cloudinary;
    //private readonly ILogger _logger;
    public PhotoService(IOptions<PhotoSettings> options)//, ILogger logger)
    {
        var account = new Account(
            cloud: options.Value.CloudName,
            apiKey: options.Value.ApiKey,
            apiSecret: options.Value.ApiSecret
            );
        _cloudinary = new Cloudinary(account);
        //_logger = logger;
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
            try
            {
                uploadResult = await _cloudinary.UploadAsync(ImageParam);
            }
            catch (Exception ex)
            {
                //_logger.Error(ex, "Failed To Upload image");
            }
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
