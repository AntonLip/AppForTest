using testapp.Models.DbModels;

namespace testapp.Models.Interfaces.Repository
{
    public interface IQuestionRepository : IRepository<Question, Guid>
    {
    }
}
