using DtoLayer.CatalogDto.CategoryDto;

namespace DtoLayer.CatalogDto.ExclusiveSelectionsDto
{
    public class ResultExclusiveSelectionsDto
    {
        public string ExclusiveSelectionsID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryID { get; set; }
        public ResultCategoryDto Category { get; set; }
    }
}
