using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Models
{
    [Table("Branch")]
    public class BranchModel : BaseModel
    {
        [StringLength(50)]
        [Required(ErrorMessage = "BranchCode is required")]
        public string BranchCode { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "BranchName is required")]
        public string BranchName { get; set; }

        public string BranchCountry { get; set; }
    }
}