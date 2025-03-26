namespace Restaurant.Core.Request
{
    public class UploadRequest
    {
        public string FileName { get; set; }
        public string FolderName { get; set; }
        public Stream Stream { get; set; }
        public string ContentType { get; set; }

        public UploadRequest(string fileName, string folderName, Stream stream, string contentType)
        {
            FileName = fileName;
            FolderName = folderName;
            Stream = stream;
            ContentType = contentType;
        }
    }
}
