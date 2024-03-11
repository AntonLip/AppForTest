using testapp.Models.Interfaces;
using testapp.Models.DtoModels.Answer;
using testapp.Models.DbModels;

namespace testapp.Models.DtoModels.Question
{
    public class QuestionDto : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public Disciplines Discipline { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
