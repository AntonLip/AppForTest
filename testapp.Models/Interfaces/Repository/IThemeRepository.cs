using testapp.Models.DbModels;

namespace testapp.Models.Interfaces.Repository
{
    public interface IThemeRepository : IRepository<Theme, Guid>
    {
    }
}
