using System;
using System.Collections.Generic;

namespace GoodHamburguerAPI.Model.GoodHamburguer;

public partial class TbOrder
{
    public int IdOrder { get; set; }

    public DateTime? DateOrder { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual ICollection<TbItemOrdered> TbItemOrdereds { get; set; } = new List<TbItemOrdered>();
}
