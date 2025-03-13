using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Model;

public partial class Object
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string? DisplayName { get; set; }

    public int UnitId { get; set; }

    public int SupplierId { get; set; }

    [Column("QRCode")]
    [StringLength(255)]
    public string? QRCode { get; set; }

    [StringLength(255)]
    public string? BarCode { get; set; }

    [ForeignKey("SupplierId")]
    [InverseProperty("Objects")]
    public virtual Supplier Supplier { get; set; } = null!;

    [ForeignKey("UnitId")]
    [InverseProperty("Objects")]
    public virtual Unit Unit { get; set; } = null!;
}
