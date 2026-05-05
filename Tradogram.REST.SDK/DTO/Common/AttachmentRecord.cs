namespace Tradogram.REST.SDK.DTO.Common
{
    public class AttachmentRecord
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int TotalRecords { get; set; }
        public bool HasMorePages { get; set; } = false;
        public List<Attachment> Attachments { get; set; } = new List<Attachment>();
    }

    public class Attachment
    {
        public string base64 { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string extension { get; set; } = string.Empty;
        public string filename { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string filesize { get; set; } = string.Empty;
    }
}
