using testapp.Models.DbModels;
using testapp.Models.DtoModels.Answer;
using testapp.Models.Interfaces;

namespace testapp.Models.DtoModels.Question
{
    public class GetQuestionDto : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ThemeName { get; set; }
        public Disciplines Discipline { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
