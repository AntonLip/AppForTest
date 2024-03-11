using testapp.Models.Interfaces;

namespace testapp.Models.DbModels
{
    public class Results : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public DateTime DateToTakePass{ get; set; }
        public int Grade { get; set; }
        public Guid DisciplineId { get; set; }
        public Guid ResultThemeId { get; set; }
    }
}
