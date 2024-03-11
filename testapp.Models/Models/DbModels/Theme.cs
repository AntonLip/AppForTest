using System.ComponentModel.DataAnnotations.Schema;
using testapp.Models.Interfaces;

namespace testapp.Models.DbModels
{
    public class Theme : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        [ForeignKey("Disciplines")]
        public Guid DisciplinesId { get; set; }
    }
}
