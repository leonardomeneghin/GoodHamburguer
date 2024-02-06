using System.ComponentModel.DataAnnotations.Schema;

namespace GoodHamburguerAPI.Model
{
    public class Product : BaseEntity
    {
        [Column("id_product")]
        public override int Id {  get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public decimal? Price { get; set; }
        [Column("id_item_type")]
        public int id_item_type { get; set; }
    }
}
