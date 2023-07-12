using System.Collections.Generic;

namespace Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<User> User { get; set; } = new List<User>();
    }
}
