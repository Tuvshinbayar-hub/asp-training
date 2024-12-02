using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.GobiColor
{
    public class GobiColorRecipeDetail : BaseCreation
    {
        public string GobiColorCode { get; set; }
        public string PaintType { get; set; }
        public float PaintWeight { get; set; } = 0;
        public bool IsActive { get; set; } = true;
    }
}
