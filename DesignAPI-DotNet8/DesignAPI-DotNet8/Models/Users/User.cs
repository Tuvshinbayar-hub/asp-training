using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.Users
{
    public class User : Base
    {
        public required string Name { get; set; }
        public int Role { get; set; }
    }
}
