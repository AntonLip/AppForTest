using Microsoft.AspNetCore.Identity;

namespace testapp.Models.DbModels
{
    public class ApplicationUser : IdentityUser
    {
        public Guid GroupId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        //public string? PhotoPath { get; set; }
    }
}
