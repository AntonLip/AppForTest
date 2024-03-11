namespace testapp.Models.DtoModels.Answer
{
    public class AnswerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsChoosen { get; set; }
        public bool IsDelete { get; set; }
    }
}
