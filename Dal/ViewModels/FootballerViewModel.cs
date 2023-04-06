using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Dal.Enums;

namespace Dal.ViewModels;

public class FootballerViewModel
{
    [Range(1, long.MaxValue)] // нужно ли это, если id не редактируется
    public long? Id { get; set; }
    
    [Required(ErrorMessage = "Поле \"Имя\" обязательно")]
    [Display(Name = "Имя")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Поле \"Фамилия\" обязательно")]
    [Display(Name = "Фамилия")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Поле \"Пол\" обязательно")]
    [Display(Name = "Пол")]
    public string Gender { get; set; }
    
    [Required(ErrorMessage = "Поле \"Команда\" обязательно")]
    [Display(Name = "Команда")]
    public TeamViewModel Team { get; set; }
    
    [Required(ErrorMessage = "Поле \"Дата рождения\" обязательно")]
    [UIHint("Date")]
    [Display(Name = "Дата рождения")]
    public DateOnly?  Birthday { get; set; }
    
    [Required(ErrorMessage = "Поле \"Страна\" обязательно")]
    [Display(Name = "Страна")]
    public string Country { get; set; }
}