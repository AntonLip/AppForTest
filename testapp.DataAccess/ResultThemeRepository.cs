using testapp.Models.DbModels;
using testapp.Models.Interfaces.Repository;

namespace testapp.DataAccess;

public class ResultThemeRepository : BaseRepository<ResultTheme>, IResultThemeRepository
{
    public ResultThemeRepository(AppDbContext context)
    : base(context)
    {
        
    }
}