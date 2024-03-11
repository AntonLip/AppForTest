using testapp.Models.DbModels;

namespace testapp.ViewModels;

public class EditDisciplinesViewModel
{
    public EditDisciplinesViewModel()
    {
        Discipline = new Disciplines();
        Themes = new List<Theme>();
    }
    public Disciplines Discipline { get; set; }

    public List<Theme> Themes { get; set; }
}
