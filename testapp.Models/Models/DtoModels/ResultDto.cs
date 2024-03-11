using testapp.Models.DbModels;
using testapp.Models.Interfaces;

namespace testapp.Models.DtoModels
{
    public class ResultDto : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime DateToTakePass { get; set; }
        public string DisciplineName { get; set; }
        public List<string> ThemeNames { get; set; }
        public int Grade { get; set; }
    }
}
