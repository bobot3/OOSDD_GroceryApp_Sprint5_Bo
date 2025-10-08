using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Models
{
    public partial class ProductCategory(int id, string name, int productId, int categoryId)
    {
        public int Id { get; set; } = id;
        public String Name { get; set; } = name;
        public int ProductId { get; set; } = productId;
        public int CategoryId { get; set; } = categoryId;
    }
}
