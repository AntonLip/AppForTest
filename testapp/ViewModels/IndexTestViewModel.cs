using testapp.Models.DbModels;
using testapp.Models.Enums;

namespace testapp.ViewModels
{
    public class IndexTestViewModel
    {
        public Guid DisciplineId { get; set; }
        public Guid ThemeId { get; set; }
        public TypeOfTest TypeOfTest { get; set; }
        public List<Disciplines> Disciplines { get;  set; }
    }
}
