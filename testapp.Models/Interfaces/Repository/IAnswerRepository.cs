using testapp.Models.DbModels;

namespace testapp.Models.Interfaces.Repository
{
    public interface IAnswerRepository : IRepository<Answer, Guid>
    {
    }
}
