using testapp.Models.Interfaces.Repository;
using testapp.Models.DbModels;

namespace testapp.DataAccess
{
    public class ResultRepository : BaseRepository<Results>, IResultRepository
    {
        public ResultRepository(AppDbContext context)
            : base(context)
        {

        }
    }
}
