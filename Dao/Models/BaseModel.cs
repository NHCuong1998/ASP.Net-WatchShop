using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dao.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }

        [DefaultValue("true")]
        public bool Status { get; set; }

        [StringLength(50)]
        public string UserNew { get; set; }

        public DateTime DateNew { get; set; }

        [StringLength(50)]
        public string UserEdit { get; set; }

        public DateTime DateEdit { get; set; }
    }
}
