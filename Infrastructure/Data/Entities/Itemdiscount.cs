using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace online_pricing_calculator_api.Infrastructure.Data.Entities;

[Table("itemdiscounts")]
[Index("Itemid", Name = "idx_itemdiscounts_itemid")]
[Index("Itemid", "Discountid", Name = "uq_item_discount", IsUnique = true)]
public partial class Itemdiscount
{
    [Key]
    [Column("itemdiscountid")]
    public int Itemdiscountid { get; set; }

    [Column("itemid")]
    public int Itemid { get; set; }

    [Column("discountid")]
    public int Discountid { get; set; }

    [ForeignKey("Discountid")]
    [InverseProperty("Itemdiscounts")]
    public virtual Discount Discount { get; set; } = null!;

    [ForeignKey("Itemid")]
    [InverseProperty("Itemdiscounts")]
    public virtual Item Item { get; set; } = null!;
}
