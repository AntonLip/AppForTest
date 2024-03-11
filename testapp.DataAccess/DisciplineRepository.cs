using testapp.Models.Interfaces.Repository;
using testapp.Models.DbModels;

namespace testapp.DataAccess
{
    public class DisciplineRepository : BaseRepository<Disciplines>, IDisciplineRepository
    {
        public DisciplineRepository(AppDbContext context)
            : base(context)
        {

        }
    }
}
