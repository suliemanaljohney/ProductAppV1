using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAppV1.Shared.Dto.CategoryDto
{
    public class UpdateCategoryDto
    {
        public UpdateCategoryDto()
        {
           
        }

        [Required]
        public string Name { get; set; } = string.Empty;
       
    }
}
