using testapp.Models.Interfaces;

namespace testapp.Models.DbModels
{
    public class Disciplines : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Theme>? Themes{ get; set; }
    }
}
