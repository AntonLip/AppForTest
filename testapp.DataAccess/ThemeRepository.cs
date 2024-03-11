using testapp.Models.Interfaces.Repository;
using testapp.Models.DbModels;

namespace testapp.DataAccess
{
    public class ThemeRepository : BaseRepository<Theme>, IThemeRepository
    {
        public ThemeRepository(AppDbContext context)
            : base(context)
        {

        }
    }
}
