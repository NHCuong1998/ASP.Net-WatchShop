using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Dao.Models
{
    [Table("ProductType")]
    public class ProductTypeModel : BaseModel
    {
        [StringLength(50)]
        [Required(ErrorMessage = "TypeCode is required")]
        public string TypeCode { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "TypeName is required")]
        public string TypeName { get; set; }

        public Guid ParentId { get; set; }

    }
}
