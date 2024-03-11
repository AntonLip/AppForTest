using System;
using testapp.Models.Interfaces;

namespace testapp.Models.DbModels
{
    public class Answer : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
