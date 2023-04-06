using System.ComponentModel.DataAnnotations;

namespace Dal.Enums;

public enum Country
{
    // ага, вот только страны мне нужно хранить на русском
    [Display(Name = "Россия")]
    Russia,
    [Display(Name = "США")]
    USA,
    [Display(Name = "Италия")]
    Italy,
}