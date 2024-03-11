using AutoMapper;
using Microsoft.AspNetCore.Identity;
using testapp.Models.DbModels;
using testapp.Models.DtoModels;

namespace testapp.Models.Settings
{
    public class UserResolver : IValueResolver<Results, ResultDto, ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserResolver(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public ApplicationUser Resolve(Results source, ResultDto destination, ApplicationUser destMember, ResolutionContext context)
        {
            try
            {
                var user = _userManager.FindByIdAsync(source.UserId).Result;
                return user;
            }
            catch (Exception)
            {
                return new ApplicationUser();
            }

        }
    }
}