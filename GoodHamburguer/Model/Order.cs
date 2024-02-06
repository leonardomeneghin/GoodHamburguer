using System.ComponentModel.DataAnnotations.Schema;

namespace GoodHamburguerAPI.Model
{
    public class Order : BaseEntity
    {
        [Column("id_order")]
        public override int Id { get; set; }
    }
}
