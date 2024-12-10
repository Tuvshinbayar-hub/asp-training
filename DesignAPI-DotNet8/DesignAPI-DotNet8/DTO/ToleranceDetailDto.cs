namespace DesignAPI_DotNet8.DTO
{
    public class ToleranceDetailDto
    {
        public int Id { get; set; }
        public string Tolerance { get; set; }
        public string DimensionName { get; set; }
        public float ToleranceMinus { get; set; } = 0f;
        public float TolerancePlus { get; set; } = 0f;
    }

}
