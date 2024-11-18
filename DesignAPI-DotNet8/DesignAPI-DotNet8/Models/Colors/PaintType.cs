using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.GobiColor
{
    public class PaintType : BaseCreation
    {
        public string Name { get; set; }
        public float PaintWeight { get; set; }
        public bool IsActive { get; set; }
    }
}
