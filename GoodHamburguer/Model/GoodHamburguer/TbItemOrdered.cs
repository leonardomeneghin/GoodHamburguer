using System;
using System.Collections.Generic;

namespace GoodHamburguerAPI.Model.GoodHamburguer;

public partial class TbItemOrdered
{
    public int IdItemOrdered { get; set; }

    public int IdOrder { get; set; }

    public int IdProduct { get; set; }

    public virtual TbOrder IdOrderNavigation { get; set; } = null!;

    public virtual TbProduct IdProductNavigation { get; set; } = null!;
}
