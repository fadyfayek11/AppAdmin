namespace App.Admin.Models
{

    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }
}
