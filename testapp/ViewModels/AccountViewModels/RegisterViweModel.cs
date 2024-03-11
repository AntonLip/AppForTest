using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace testapp.ViewModels.AccountViewModels
{
    public class RegisterViweModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "EmailInUse", controller: "Account")]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Guid GroupId { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password's didn't match")]
        public string ConfirmPassword { get; set; }
    }
}
