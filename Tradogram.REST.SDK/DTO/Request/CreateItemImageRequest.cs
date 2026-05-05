namespace Tradogram.REST.SDK.DTO.Request
{
    public class CreateItemImageRequest
    {
        /// <summary>
        /// Path to the file you want to upload. Valid file types are .jpg, .jpeg, .gif, or .png. Only one image per item is allowed, subsequent uploads will overwrite existing images.
        /// </summary>
        public required string FilePath { get; set; } = string.Empty;
    }
}
