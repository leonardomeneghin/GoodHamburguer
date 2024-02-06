using System;
using System.Collections.Generic;

namespace GoodHamburguerAPI.Model.GoodHamburguer;

public partial class TbItemType
{
    public int IdItemType { get; set; }

    public string ItemTypeName { get; set; } = null!;

    public virtual ICollection<TbProduct> TbProducts { get; set; } = new List<TbProduct>();
}
