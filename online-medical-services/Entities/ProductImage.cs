using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace online_medical_services.Entities;

[Table("product_images")]
public partial class ProductImage
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("product_token")]
    [StringLength(50)]
    [Unicode(false)]
    public string ProductToken { get; set; } = null!;

    [Column("url")]
    [StringLength(500)]
    [Unicode(false)]
    public string Url { get; set; } = null!;

    [Column("name")]
    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("token")]
    [StringLength(50)]
    [Unicode(false)]
    public string Token { get; set; } = null!;

    [Column("created_on", TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    [Column("created_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;
}
