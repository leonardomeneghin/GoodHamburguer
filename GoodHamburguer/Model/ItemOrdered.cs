using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodHamburguerAPI.Model;

public partial class ItemOrdered : BaseEntity
{
    [Column("id_item_ordered")]
    public int Id { get; set; }

    public int IdOrder { get; set; }

    public int IdProduct { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
