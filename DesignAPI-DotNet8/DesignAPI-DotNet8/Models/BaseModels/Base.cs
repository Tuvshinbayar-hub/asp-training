using DesignAPI_DotNet8.Models.Users;

namespace DesignAPI_DotNet8.Models.BaseModels
{
    public abstract class Base
    {
        public int Id { get; private set; }
    }

    public abstract class BaseCreation: Base
    {
        public User? CreatedBy { get; set;}
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }

    public abstract class BaseWithModified : BaseCreation
    {
        public User? ModifiedBy { get; set; }
        public DateTime? ModefiedAt { get; set; } = DateTime.Now;
    }
}
