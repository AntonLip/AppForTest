using AutoMapper;
using testapp.Models.Interfaces.Repository;
using testapp.Models.DbModels;
using testapp.Models.DtoModels;

namespace testapp.Models.Settings
{
    public class UserGroupNumberResolver : IValueResolver<ApplicationUser, AppUserDto, string>
    {
        private readonly IGroupRepository _repository;
        public UserGroupNumberResolver(IGroupRepository repository)
        {
            _repository = repository;
        }
        public string Resolve(ApplicationUser source, AppUserDto destination, string destMember, ResolutionContext context)
        {
            try
            {
                var group = _repository.GetByIdAsync(source.GroupId).Result;
                destination.GroupNumber = group.Name;
                return group.Name;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return "";
            }
        }
    }
}
