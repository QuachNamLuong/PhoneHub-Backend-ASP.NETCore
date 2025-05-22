using Minio;
using Minio.DataModel.Args;

namespace PhoneHub.API.Services;

public interface IMinioService
{
    Task<string> UploadImage(string bucketName, IFormFile image, CancellationToken cancellationToken = default);
    Task RenameFileAsync(string bucket, string oldName, string newName, CancellationToken cancellationToken = default);
    Task RemoveFileAsync(string bucket, string name, CancellationToken cancellationToken = default);
    // Task GetFiles();
}

public class MinioService(IMinioClient minio) : IMinioService
{
    private async Task<bool> IsBucketExistsAsync(string bucketName, CancellationToken cancellationToken = default)
    {
        try
        {
            var args = new BucketExistsArgs().WithBucket(bucketName);
            return await minio.BucketExistsAsync(args, cancellationToken);
        }
        catch (Exception ex)
        {
            // logger.LogError(ex, "Failed to check if bucket '{Bucket}' exists.", bucketName);
            return false;
        }
    }

    private async Task CreateBucketIfNotExitsAsync(string newBucketName, CancellationToken cancellationToken = default)
    {
        var isBucketNameExits = await IsBucketExistsAsync(newBucketName, cancellationToken);
        if (!isBucketNameExits)
        {
            try
            {
                var mbArgs = new MakeBucketArgs().WithBucket(newBucketName);
                await minio.MakeBucketAsync(mbArgs, cancellationToken);
            }
            catch (Exception ex)
            {
                // logger.LogError(ex, "Failed to create bucket \"{newBucketName}\" ", newBucketName);
            }
        }
    }

    private async Task<string> GetUniqueObjectNameAsync(string baseName, string bucketName, CancellationToken cancellationToken)
    {
        var extension = Path.GetExtension(baseName);
        var nameWithoutExt = Path.GetFileNameWithoutExtension(baseName);
        var objectName = baseName;
        int counter = 1;

        while (await ObjectExistsAsync(bucketName, objectName, cancellationToken))
        {
            objectName = $"{nameWithoutExt}_{counter}{extension}";
            counter++;
        }

        return objectName;
    }

    private async Task<bool> ObjectExistsAsync(string bucketName, string objectName, CancellationToken cancellationToken)
    {
        try
        {
            var args = new StatObjectArgs()
                .WithBucket(bucketName)
                .WithObject(objectName);
            var _ = await minio.StatObjectAsync(args, cancellationToken);
            return true;
        }
        catch (Minio.Exceptions.ObjectNotFoundException)
        {
            return false;
        }
    }


    public async Task<string> UploadImage(string bucketName, IFormFile image, CancellationToken cancellationToken = default)
    {
        await CreateBucketIfNotExitsAsync(bucketName, cancellationToken);
        var objectName = await GetUniqueObjectNameAsync(image.FileName, bucketName, cancellationToken);

        // Upload the image from the stream
        await using var stream = image.OpenReadStream();
        await minio.PutObjectAsync(new PutObjectArgs()
            .WithBucket(bucketName)
            .WithObject(objectName)
            .WithStreamData(stream)
            .WithObjectSize(stream.Length)
            .WithContentType(image.ContentType),
            cancellationToken
        );

        // Save the public URL (if the bucket is public)
        var imageUrl = $"http://localhost:9000/{bucketName}/{objectName}";
        return imageUrl;
    }

    public async Task RenameFileAsync(string bucket, string oldName, string newName, CancellationToken cancellationToken = default)
    {
        try
        {
            var cosArgs = new CopySourceObjectArgs()
                .WithBucket(bucket)
                .WithObject(oldName);

            // 1. Copy the object to new name
            var copyArgs = new CopyObjectArgs()
                .WithBucket(bucket)
                .WithObject(newName)
                .WithCopyObjectSource(cosArgs);

            await minio.CopyObjectAsync(copyArgs, cancellationToken);

            // 2. Delete the original object
            var removeArgs = new RemoveObjectArgs()
                .WithBucket(bucket)
                .WithObject(oldName);

            await minio.RemoveObjectAsync(removeArgs, cancellationToken);

            // logger.LogInformation("Renamed {Old} to {New} in bucket {Bucket}", oldName, newName, bucket);
        }
        catch (Exception ex)
        {
            // logger.LogError(ex, "Failed to rename file in MinIO");
            throw; // or return an ErrorOr / ApiResponse.Failure
        }
    }

    public async Task RemoveFileAsync(string bucket, string name, CancellationToken cancellationToken = default)
    {
        try
        {
            var removeArgs = new RemoveObjectArgs()
                .WithBucket(bucket)
                .WithObject(name);

            await minio.RemoveObjectAsync(removeArgs, cancellationToken);

            // logger.LogInformation("Remove {Name} in bucket {Bucket}", name, bucket);
        }
        catch (Exception ex)
        {
            // logger.LogError(ex, "Failed to rename file in MinIO");
            throw; // or return an ErrorOr / ApiResponse.Failure
        }
    }
}