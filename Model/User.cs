using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Model;

public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string? DisplayName { get; set; }

    [StringLength(100)]
    public string? UserName { get; set; }

    [StringLength(255)]
    public string? Password { get; set; }

    public int RoleId { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role Role { get; set; } = null!;
}
