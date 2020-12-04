using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.BE
{
    public class BE_Product
    {
        public int productId { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int productTypeId { get; set; }
        public int productCategoryId { get; set; }
        public decimal cost { get; set; }
        public decimal salePrice { get; set; }
        public bool isEnabled { get; set; }
        public decimal quantity { get; set; }
        public int measuredUnitId { get; set; }
        public int dietId { get; set; }
        public int headquartersId { get; set; }
        public int kcalTotal { get; set; }
        public List<BE_ProductDetail> detail { get; set; }
        public decimal waste { get; set; }
        public decimal costbyRecipeMeasureUnit { get; set; }
        public int RecipeMeasureUnitId { get; set; }
        public string  CompanyCode { get; set; }
        public int invoiceItemId { get; set; }
    }
}
