using ProductAppV1.Shared.Dto.ProductDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAppV1.Shared.Dto.CategoryDto
{
    public class CreateCategoryDto
    {
        public CreateCategoryDto()
        {
            Products = new HashSet<CreateProductForCategoryDto>();
        }

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public virtual ICollection<CreateProductForCategoryDto> Products { get; set; }
    }
}
