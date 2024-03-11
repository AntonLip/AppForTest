using Newtonsoft.Json;
using testapp.Models.Interfaces;

namespace testapp.Models.DbModels
{
    public class ThemeDto : IEntity<Guid>
    {
        public ThemeDto()
        {
                
        }

        [JsonProperty(nameof(Id))]
        public Guid Id { get; set; }
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }
        [JsonProperty(nameof(IsDelete))]
        public bool IsDelete { get; set; }
    }
}
