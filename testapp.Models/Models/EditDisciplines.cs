using testapp.Models.DbModels;

namespace testapp.Models.ViewModels;

public class EditDisciplines
{
    public EditDisciplines()
    {
        Discipline = new Disciplines();
        Themes = new List<ThemeDto>();
    }
   
    public Disciplines Discipline { get; set; }

    public List<ThemeDto> Themes { get; set; }
}
