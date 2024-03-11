using AutoMapper;
using testapp.Models.Interfaces.Repository;
using testapp.Models.Interfaces.Service;
using testapp.Models.DbModels;

namespace testapp.Services
{
    public class GroupService : BaseService<Group, Group, Group, Group>, IGroupService
    {
        public GroupService(IGroupRepository repository, IMapper mapper)
            : base(repository, mapper)
        {

        }
    }
}
