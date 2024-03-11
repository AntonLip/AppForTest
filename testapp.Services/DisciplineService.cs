using AutoMapper;
using testapp.Models.DbModels;
using testapp.Models.Interfaces.Repository;
using testapp.Models.Interfaces.Service;
using testapp.Models.ViewModels;

namespace testapp.Services
{
    public class DisciplineService : BaseService<Disciplines, Disciplines, Disciplines, Disciplines>, IDisciplineService
    {
        private readonly IThemeRepository _themeRepository;
        public DisciplineService(IDisciplineRepository repository,
                                IThemeRepository themeRepository, IMapper mapper)
            : base(repository, mapper)
        {
            _themeRepository = themeRepository;
        }
        public override async Task<Disciplines> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var themes = _themeRepository.GetWithInclude(p => p.DisciplinesId == id);
            foreach (var item in themes)
            {
                await _themeRepository.RemoveAsync(item);
            }
            return await base.RemoveAsync(id, cancellationToken);
        }
        public async Task AddThemeToDisciplinesAsync(Theme item, CancellationToken cancellationToken = default)
        {
            await _themeRepository.AddAsync(item, cancellationToken);
        }

        public Disciplines GetByIdWithTheme(Guid id)
        {
            var item = _repository.GetWithInclude(p => p.Id == id, includeProperties: p => p.Themes).FirstOrDefault();
            return item;
        }

        public EditDisciplines GetForEditById(Guid id)
        {
            var discipline = _repository.GetWithInclude(p => p.Id == id, includeProperties: p => p.Themes);
            EditDisciplines model = new EditDisciplines();
            model.Discipline = discipline.FirstOrDefault();
            foreach (var item in discipline.FirstOrDefault().Themes)
            {
                model.Themes.Add(new ThemeDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsDelete = false
                });
            }

            return model;
        }
        
        public async Task UpdateWithThemeAsync(EditDisciplines model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));
            var discipline = await _repository.GetByIdAsync(model.Discipline.Id);
            if (discipline is null)
                throw new ArgumentNullException(nameof(discipline));
            if (discipline.Name != model.Discipline.Name)
            {
                discipline.Name = model.Discipline.Name;
                await _repository.UpdateAsync(discipline);
            }
            foreach (var item in model.Themes)
            {
                if (item.Id != Guid.Empty)
                {
                    var theme = await _themeRepository.GetByIdAsync(item.Id);

                    if(item.IsDelete)
                        await _themeRepository.RemoveAsync(theme);
                    if(theme.Name != item.Name)
                    {
                        theme.Name = item.Name;
                        await _themeRepository.UpdateAsync(theme);                        
                    }
                }
                else
                {
                    await _themeRepository.AddAsync(new Theme{Name = item.Name, DisciplinesId = discipline.Id});
                }
            }
        }

        public async Task<Disciplines> GetDiscpilineByThemeId(Guid themeId)
        {
            if(themeId == Guid.Empty)
                throw new ArgumentNullException(nameof(themeId));
            var theme = await _themeRepository.GetByIdAsync(themeId);
            var disciplines = await _repository.GetByIdAsync(theme.DisciplinesId);
            disciplines.Themes.Add(theme);
            return disciplines;
        }

        public List<Disciplines> GetAllWithTheme()
        {
            return _repository.GetWithInclude(p => p.Themes).ToList();
        }

        public Theme GetThemeByName(string themeName)
        {
            if (string.IsNullOrEmpty(themeName))
                throw new ArgumentOutOfRangeException();
            var theme = _themeRepository.GetWithInclude(p => p.Name == themeName).FirstOrDefault();
            return theme is null ? throw new ArgumentNullException() : theme;
        }
    }
}
