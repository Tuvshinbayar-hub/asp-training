namespace DesignAPI_DotNet8.Models
{
    public class PantoneColor
    {
        public int Id { get; private set; }
        public required PantoneColorProperty Property { get; set; }
        public string? RgbHex { get; set; }
        public string? RgbTriple { get; set; }
        // public required User CreatedBy {get; set;}
    }
}
