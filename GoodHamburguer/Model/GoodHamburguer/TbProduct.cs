using System;
using System.Collections.Generic;

namespace GoodHamburguerAPI.Model.GoodHamburguer;

public partial class TbProduct
{
    public int IdProduct { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Price { get; set; }

    public int IdItemType { get; set; }

    public virtual TbItemType IdItemTypeNavigation { get; set; } = null!;

    public virtual ICollection<TbItemOrdered> TbItemOrdereds { get; set; } = new List<TbItemOrdered>();
}
