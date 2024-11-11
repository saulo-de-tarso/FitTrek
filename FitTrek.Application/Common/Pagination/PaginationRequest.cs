using FitTrek.Application.Common.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FitTrek.Application.Common.Pagination;

public class PaginationRequest
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "PageNumber must be greater than 0.")]
    [DefaultValue(1)]
    public int PageNumber { get; set; }

    [Required]
    [EnumDataType(typeof(PageSizeEnum), ErrorMessage = "PageSize must be in the interval [5, 10, 15, 30]")]
    public PageSizeEnum PageSize { get; set; }
}
