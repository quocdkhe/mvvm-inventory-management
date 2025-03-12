using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Model;

public partial class Unit
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string? DisplayName { get; set; }

    [InverseProperty("Unit")]
    public virtual ICollection<Object> Objects { get; set; } = new List<Object>();
}
