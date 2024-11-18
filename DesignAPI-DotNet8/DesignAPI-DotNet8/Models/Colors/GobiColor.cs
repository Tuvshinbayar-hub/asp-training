using DesignAPI_DotNet8.Models.BaseModels;
using DesignAPI_DotNet8.Enums;

namespace DesignAPI_DotNet8.Models.Colors
{
    public class GobiColor : BaseWithModified
    {
        public string GobiColorCode { get; set; }
        public string FourDigitColorCode { get; set; }
        public bool MainFlag { get; set; }

        public int? ColorTypeId { get; set; }
        public ColorType? ColorType { get; set; }

        public int? ColorShadeId { get; set; }
        public ColorShade? ColorShade { get; set; }

        public int? PantoneColorId { get; set; }
        public PantoneColor? PantoneColor { get; set; }
        
        public int? DyingMethodId { get; set; }
        public DyingMethod? DyingMethod { get; set; }

        public int? ColorRecipeId { get; set; }
        public ColorRecipe? ColorRecipe { get; set; }

        public DandruffClassification DandruffClassification { get; set; }
    }
}
