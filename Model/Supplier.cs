using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Model;

public partial class Supplier
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string? DisplayName { get; set; }

    [StringLength(255)]
    public string? Address { get; set; }

    [StringLength(20)]
    public string? Phone { get; set; }

    [StringLength(255)]
    public string? Email { get; set; }

    [StringLength(255)]
    public string? MoreInfo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ContractDate { get; set; }

    [InverseProperty("Supplier")]
    public virtual ICollection<Object> Objects { get; set; } = new List<Object>();
}
