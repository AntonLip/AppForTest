using testapp.Models.Interfaces.Repository;
using testapp.Models.DbModels;

namespace testapp.DataAccess
{
    public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(AppDbContext context)
            : base(context)
        {

        }
    }
}
