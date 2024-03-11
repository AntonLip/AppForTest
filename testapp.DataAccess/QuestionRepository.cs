using testapp.Models.Interfaces.Repository;
using testapp.Models.DbModels;

namespace testapp.DataAccess
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(AppDbContext context)
            : base(context)
        {

        }
    }
}
