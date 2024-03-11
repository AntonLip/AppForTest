using System.ComponentModel.DataAnnotations.Schema;
using testapp.Models.Interfaces;

namespace testapp.Models.DbModels
{
    public class Question : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        [ForeignKey("Theme")]
        public Guid ThemeId { get; set; }
        public Theme Theme { get; set; }
        public List<Answer>? Answers {get;set;}
    }
}
