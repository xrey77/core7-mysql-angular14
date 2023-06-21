using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace core7_msyql_angular14.Entities
{
[Table("products")]    
public class Product {

        [Key]
        public int Id { get; set; }

        [Column("descriptions",TypeName="varchar(100)")]
        [Required]
        public string Descriptions { get; set; }

        [Column("qty")]
        public int? Qty { get; set; }

        [Column("unit",TypeName="varchar(10)")]
        public string Unit { get; set; }

        [Column("cost_price",TypeName="decimal(10,2)")]
        public decimal? Cost_price { get; set; }

        [Column("sell_price",TypeName="decimal(10,2)")]
        public decimal? Sell_price { get; set; }

        [Column("prod_pic",TypeName="varchar(100)")]
        public string Prod_pic { get; set; }

        [Column("category",TypeName="varchar(20)")]
        public string Category { get; set; }

        [Column("sale_price",TypeName="decimal(10,2)")]
        public decimal? Sale_price { get; set; }

        [Column("alert_level")]
        public int? Alert_level { get; set; }

        [Column("critical_level")]
        public int? Critical_level { get; set; }

        [Column("created_at",TypeName="timestamp")]
        [DefaultValue("CURRENT_TIMESTAMP")]
        public DateTime Created_at { get; set; }

        [Column("updated_at",TypeName="timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getutcdate()")]
        public DateTime Updated_at { get; set; }
    }    
}