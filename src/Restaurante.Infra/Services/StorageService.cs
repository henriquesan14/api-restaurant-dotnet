using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using Restaurant.Core.Request;
using Restaurant.Core.Response;
using Restaurant.Core.Services;

namespace Restaurant.Infra.Services
{
    public class StorageService : IStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly AmazonS3Client _s3Client;
        private const double DURATION = 24;

        public StorageService(IConfiguration configuration)
        {
            _configuration = configuration;
            var credentials = new BasicAWSCredentials(_configuration["AwsSettings:AccessKey"], _configuration["AwsSettings:SecretKey"]);
            _s3Client = new AmazonS3Client(credentials, RegionEndpoint.SAEast1);
        }

        public async Task<UploadResponse> Save(UploadRequest request)
        {
            var dateNow = DateTime.Now;
            string objectKey = $"{request.FolderName}/{dateNow.ToString("dd-MM-yyyy-HH:mm:ss")}_{request.FileName}";
            string url = "";

            try
            {
                using (Stream fileToUpload = request.Stream)
                {
                    var putObjectRequest = new PutObjectRequest
                    {
                        BucketName = _configuration["AwsSettings:BucketName"],
                        Key = objectKey,
                        InputStream = fileToUpload,
                        ContentType = request.ContentType,
                    };

                    var response = await _s3Client.PutObjectAsync(putObjectRequest);

                    if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    {
                        url = GeneratePreSignedURL(objectKey);
                    }
                    else
                    {
                        throw new Exception("Falha no upload do arquivo.");
                    }
                }
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine("Erro S3: " + ex.Message);
                // Handle exception or rethrow
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                // Handle exception or rethrow
            }

            return new UploadResponse(url, objectKey);
        }

        public async Task Delete(string path)
        {
            var deleteObjectRequest = new DeleteObjectRequest
            {
                BucketName = _configuration["AwsSettings:BucketName"],
                Key = path
            };
            await _s3Client.DeleteObjectAsync(deleteObjectRequest);
        }

        private string GeneratePreSignedURL(string objectKey)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = _configuration["AwsSettings:BucketName"],
                Key = objectKey,
                Verb = HttpVerb.GET,
                Expires = DateTime.Now.AddHours(DURATION)
            };

            string url = _s3Client.GetPreSignedURL(request);
            return url;
        }

    }
}
