using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Models
{
    [Table("User")]
    public class UserModel
    {
        [Key]
        public String UserID { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(250)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Fullname is required")]
        [StringLength(250)]
        public string FullName { get; set; }

        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                ErrorMessage = "Characters are not allowed.")]
        [StringLength(250)]
        public string Email { get; set; }

        [DefaultValue("false")]
        public bool IsAdmin { get; set; }

        [DefaultValue("true")]
        public bool Status { get; set; }
    }
}
