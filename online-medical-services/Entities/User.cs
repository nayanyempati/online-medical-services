using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace online_medical_services.Entities;

[Table("users")]
public partial class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("first_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Column("email")]
    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("phone")]
    [StringLength(50)]
    [Unicode(false)]
    public string Phone { get; set; } = null!;

    [Column("password")]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [Column("password_reset_link")]
    [Unicode(false)]
    public string PasswordResetLink { get; set; } = null!;

    [Column("verification_link")]
    [Unicode(false)]
    public string VerificationLink { get; set; } = null!;

    [Column("password_reset_link_expiry", TypeName = "datetime")]
    public DateTime PasswordResetLinkExpiry { get; set; }

    [Column("created_on", TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    [Column("photo")]
    [Unicode(false)]
    public string Photo { get; set; } = null!;

    [Column("last_updated_on", TypeName = "datetime")]
    public DateTime LastUpdatedOn { get; set; }

    [Column("is_account_verified")]
    public int IsAccountVerified { get; set; }

    [Column("account_status")]
    [StringLength(50)]
    [Unicode(false)]
    public string AccountStatus { get; set; } = null!;

    [Column("role")]
    [StringLength(50)]
    [Unicode(false)]
    public string Role { get; set; } = null!;

    [Column("token")]
    [StringLength(50)]
    [Unicode(false)]
    public string Token { get; set; } = null!;
}
