using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace core7_msyql_angular14.Entities
{
    [Table("users")]
    public class User {

        [Key]
        public int Id {get; set;}

        [Column("lastname",TypeName="varchar(20)")]
        [Required]
        public string LastName {get; set;}

        [Column("firstname",TypeName="varchar(20)")]
        [Required]
        public string FirstName {get; set;}

        [Column("username",TypeName="varchar(10)")]
        [Required]
        public string UserName {get; set;}

        [Column("password",TypeName="varchar(200)")]
        [Required]
        public string Password {get; set;}

        [Column("email",TypeName="varchar(100)")]
        [Required]
        public string Email { get; set; }

        [Column("mobile",TypeName="varchar(20)")]
        public string Mobile { get; set; }

        [Column("isactivated")]
        public int? Isactivated {get; set;} = 0;

        [Column("isblocked")]
        public int? Isblocked {get; set;}

        [Column("mailtoken")]
        public int? Mailtoken {get; set;}

        [Column("qrcodeurl",TypeName="text")]
        public string Qrcodeurl {get; set;}

        [Column("profilepic",TypeName="varchar(50)")]
        public string Profilepic {get; set;}

        [Column("sale_price",TypeName="varchar(200)")]
        public string Secretkey  {get; set;}

        [Column("created_at",TypeName="timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getutcdate()")]
        public DateTime Created_at { get; set; }

        [Column("updated_at",TypeName="timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getutcdate()")]
        public DateTime Updated_at { get; set; }

        // [Column("roles",TypeName="varchar(10)")]
        // public string Roles { get; set; }

        public UserRole Roles { get; set; }

    }
}