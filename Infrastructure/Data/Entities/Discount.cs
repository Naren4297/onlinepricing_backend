using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace online_pricing_calculator_api.Infrastructure.Data.Entities;

[Table("discounts")]
[Index("Discounttypeid", Name = "idx_discounts_typeid")]
public partial class Discount
{
    [Key]
    [Column("discountid")]
    public int Discountid { get; set; }

    [Column("discounttypeid")]
    public int Discounttypeid { get; set; }

    [Column("percentagevalue")]
    [Precision(5, 2)]
    public decimal? Percentagevalue { get; set; }

    [Column("buyquantity")]
    public int? Buyquantity { get; set; }

    [Column("freequantity")]
    public int? Freequantity { get; set; }

    [Column("isactive")]
    public bool Isactive { get; set; }

    [ForeignKey("Discounttypeid")]
    [InverseProperty("Discounts")]
    public virtual Discounttype Discounttype { get; set; } = null!;

    [InverseProperty("Discount")]
    public virtual ICollection<Itemdiscount> Itemdiscounts { get; set; } = new List<Itemdiscount>();
}
