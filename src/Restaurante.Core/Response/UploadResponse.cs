namespace Restaurant.Core.Response
{
    public class UploadResponse
    {
        public string Url { get; set; }
        public string Path { get; set; }

        public UploadResponse(string url, string path)
        {
            Url = url;
            Path = path;
        }
    }
}
