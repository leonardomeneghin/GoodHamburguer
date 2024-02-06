using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodHamburguerAPI.Model;

public partial class ItemType : BaseEntity
{
    [Column("id_item_type")]
    public int Id { get; set; }

    public string ItemTypeName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
