using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodHamburguerAPI.Model;

public partial class Order : BaseEntity
{
    [Column("id_order")]
    public int Id { get; set; }

    public DateTime? DateOrder { get; set; }

    public decimal? TotalPrice { get; set; }

    public decimal? DiscountApplyed { get; set; }

    public virtual ICollection<ItemOrdered> ItemOrdereds { get; set; } = new List<ItemOrdered>();
}
