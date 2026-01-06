using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace online_pricing_calculator_api.Infrastructure.Data.Entities;

[Table("discounttypes")]
[Index("Code", Name = "discounttypes_code_key", IsUnique = true)]
public partial class Discounttype
{
    [Key]
    [Column("discounttypeid")]
    public int Discounttypeid { get; set; }

    [Column("code")]
    [StringLength(50)]
    public string Code { get; set; } = null!;

    [Column("description")]
    [StringLength(200)]
    public string? Description { get; set; }

    [InverseProperty("Discounttype")]
    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();
}
