using System.ComponentModel.DataAnnotations.Schema;

namespace GoodHamburguerAPI.Model
{
    public class Order : BaseEntity
    {
        [Column("id_order")]
        public override int Id { get; set; }
        [Column("date_order")]
        public DateTime DateOrder { get; set; }
        [Column("total_price")]
        public decimal TotalPrice{ get; set; }
        [Column("discount_applyed")]
        public decimal DiscountApplyed { get; set; }
    }
}
