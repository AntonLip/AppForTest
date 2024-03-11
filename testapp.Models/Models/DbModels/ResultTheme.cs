using System.ComponentModel.DataAnnotations.Schema;
using testapp.Models.Interfaces;

namespace testapp.Models.DbModels;

public class ResultTheme : IEntity<Guid>
{
    public Guid Id { get; set; }
    [ForeignKey("Results")]
    public Guid ResultId { get; set; }
    [ForeignKey("Theme")]
    public Guid ThemeId { get; set; }
}