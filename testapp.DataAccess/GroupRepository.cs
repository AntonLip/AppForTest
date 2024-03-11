using testapp.Models.Interfaces.Repository;
using testapp.Models.DbModels;

namespace testapp.DataAccess
{
    public class GroupRepository : BaseRepository<Group> , IGroupRepository
    {
        public GroupRepository(AppDbContext context)
            : base(context)
        {

        }
    }
}
