using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace online_pricing_calculator_api.Infrastructure.Data.Entities;

[Table("items")]
public partial class Item
{
    [Key]
    [Column("itemid")]
    public int Itemid { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("unitprice")]
    [Precision(10, 2)]
    public decimal Unitprice { get; set; }

    [Column("isactive")]
    public bool Isactive { get; set; }

    [Column("createdat", TypeName = "timestamp without time zone")]
    public DateTime Createdat { get; set; }

    [InverseProperty("Item")]
    public virtual ICollection<Itemdiscount> Itemdiscounts { get; set; } = new List<Itemdiscount>();
}
