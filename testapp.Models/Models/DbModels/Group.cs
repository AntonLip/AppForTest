using System;
using testapp.Models.Interfaces;

namespace testapp.Models.DbModels
{
    public class Group : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
