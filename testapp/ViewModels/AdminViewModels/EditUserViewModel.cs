using System.ComponentModel.DataAnnotations;

namespace testapp.ViewModels.AdminViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Guid GroupId { get; set; }
        public string UserRoleId { get; set; }
        public IList<string> Roles { get; set; }
        public List<string> Claims { get; set; }
    }
}
