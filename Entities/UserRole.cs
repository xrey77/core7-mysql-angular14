using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace core7_msyql_angular14.Entities
{
    [Table("userroles")]
    public class UserRole {

        [Key]
        public int Id {get; set;}

        [Column("userid")]
        public int UserId {get; set;}

        [Column("rolename",TypeName="varchar(10)")]        
        public String RoleName {get; set;}
        public User User {get; set; } = null;
    }
    
}