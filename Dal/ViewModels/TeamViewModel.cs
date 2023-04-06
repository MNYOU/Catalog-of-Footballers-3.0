using System.ComponentModel.DataAnnotations;

namespace Dal.ViewModels;

public class TeamViewModel
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Поле \"Команда\" обязательно")]
    [Display(Name = "Команда")]
    public string Name { get; set; }
}