using System.ComponentModel.DataAnnotations;

namespace FitTrek.Application.Common.Enums;

public enum PageSizeEnum
{
    [Display(Name = "5")]
    Size5 = 5,

    [Display(Name = "10")]
    Size10 = 10,

    [Display(Name = "15")]
    Size15 = 15,

    [Display(Name = "30")]
    Size30 = 30
}