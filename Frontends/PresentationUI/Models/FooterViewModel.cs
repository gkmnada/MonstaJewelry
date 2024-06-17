using DtoLayer.CatalogDto.CategoryDto;
using DtoLayer.CatalogDto.FooterDto;

namespace PresentationUI.Models
{
    public class FooterViewModel
    {
        public List<ResultCategoryDto> ResultCategoryDto { get; set; }
        public List<ResultFooterWithCategoryDto> ResultFooterWithCategoryDto { get; set; }
    }
}
