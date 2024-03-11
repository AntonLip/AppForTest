using testapp.Models.DtoModels.Answer;
using testapp.Models.Interfaces;

namespace testapp.Models.DtoModels.Question
{
    public class AddQuestionDto : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
