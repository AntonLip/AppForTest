using System.Text.RegularExpressions;

namespace testapp.ViewModels.AdminViewModels
{
    public class ApplicationUserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Group { get; set; }
        public string Role { get; set; }

    }
}
