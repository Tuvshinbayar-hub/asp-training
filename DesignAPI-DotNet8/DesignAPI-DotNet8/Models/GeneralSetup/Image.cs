using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.GeneralSetup
{
    public class Image : BaseCreation
    {
        public string OriginalFileName { get; set; }
        public string OriginalFilePath { get; set; }
        public string ContentType { get; set; }

        public string ThumbnailFilePath { get; set; }
        public string Tag { get; set; }
    }
}