using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace online_medical_services.Entities;

[Table("products")]
public partial class Product
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(250)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("description")]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [Column("type")]
    [StringLength(50)]
    [Unicode(false)]
    public string Type { get; set; } = null!;

    [Column("price", TypeName = "money")]
    public decimal Price { get; set; }

    [Column("brand")]
    [StringLength(200)]
    [Unicode(false)]
    public string Brand { get; set; } = null!;

    [Column("discount")]
    public int Discount { get; set; }

    [Column("expiry", TypeName = "datetime")]
    public DateTime Expiry { get; set; }

    [Column("returnable")]
    [StringLength(50)]
    [Unicode(false)]
    public string Returnable { get; set; } = null!;

    [Column("token")]
    [StringLength(50)]
    [Unicode(false)]
    public string Token { get; set; } = null!;

    [Column("created_on", TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [Column("created_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }
}
