using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dao.Models
{
    [Table("Cart")]
    public class CartModel : BaseModel
    {
        public string UserID { get; set; }
        public Guid ProductID { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity >= 0")]
        public int Total { get; set; }
    }
}
