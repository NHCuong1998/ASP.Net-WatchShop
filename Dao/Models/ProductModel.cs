using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Models
{
    [Table("Product")]
    public class ProductModel : BaseModel
    {
        [StringLength(50)]
        [Required(ErrorMessage = "ProductCode is required")]
        public string ProductCode { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "ProductName is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "ProductType is required")]
        public Guid ProductTypeId { get; set; }

        public decimal CaseSize { get; set; }

        [StringLength(50)]
        public string CaseMaterial { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(150)]
        public string WaterResistance { get; set; }

        [StringLength(250)]
        public string Function { get; set; }

        [StringLength(50)]
        public string WatchMovement { get; set; }

        [Required(ErrorMessage = "BranchCode is required")]
        public Guid BranchId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price >= 0")]
        public int Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity >= 0")]
        public int Quantity { get; set; }

        public string About { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [Display(Name = "Product Image")]
        public string ProductImage { get; set; }

    }
}
