using testapp.Models.DbModels;
using testapp.Models.ViewModels;

namespace testapp.Models.Interfaces.Service
{
    public interface IDisciplineService : IService<Disciplines, Disciplines, Disciplines, Disciplines, Guid>
    {
        Task AddThemeToDisciplinesAsync(Theme item, CancellationToken cancellationToken = default);
        List<Disciplines> GetAllWithTheme();
        Disciplines GetByIdWithTheme(Guid id);
        Task<Disciplines> GetDiscpilineByThemeId(Guid themeId);
        EditDisciplines GetForEditById(Guid id);
        Task UpdateWithThemeAsync(EditDisciplines model);
        public Theme GetThemeByName(string themeName);
    }
}
