using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace online_medical_services.Entities;

[Table("address_book")]
public partial class AddressBook
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("address")]
    [Unicode(false)]
    public string Address { get; set; } = null!;

    [Column("city")]
    [StringLength(200)]
    [Unicode(false)]
    public string City { get; set; } = null!;

    [Column("provinance")]
    [StringLength(200)]
    [Unicode(false)]
    public string Provinance { get; set; } = null!;

    [Column("country")]
    [StringLength(100)]
    [Unicode(false)]
    public string Country { get; set; } = null!;

    [Column("pincode")]
    public int Pincode { get; set; }

    [Column("token")]
    [StringLength(50)]
    [Unicode(false)]
    public string Token { get; set; } = null!;

    [Column("is_primary")]
    public int? IsPrimary { get; set; }
}
