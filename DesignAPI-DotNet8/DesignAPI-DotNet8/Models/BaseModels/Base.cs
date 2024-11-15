namespace DesignAPI_DotNet8.Models.BaseModels
{
    public class Base
    {
        public int Id { get; private set; }
    }

    public class BaseCreation: Base
    {
        public User? CreatedBy { get; private set;}
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
    }

    public class BaseWithModified : BaseCreation
    {
        public User? ModifiedBy { get; set; }
        public DateTime ModefiedAt { get; set; } = DateTime.Now;
    }
}
