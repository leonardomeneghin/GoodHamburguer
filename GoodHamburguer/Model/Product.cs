using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodHamburguerAPI.Model;

public partial class Product : BaseEntity
{
    [Column("id_product")]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Price { get; set; }

    public int IdItemType { get; set; }

    public virtual ItemType IdItemTypeNavigation { get; set; } = null!;

    public virtual ICollection<ItemOrdered> ItemOrdereds { get; set; } = new List<ItemOrdered>();
}
