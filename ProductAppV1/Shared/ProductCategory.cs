using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAppV1.Shared
{
    public class ProductCategory
    {
        public ProductCategory()
        {

        }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual int CategoryId { get; set; }
    }
}
