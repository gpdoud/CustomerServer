using System.ComponentModel.DataAnnotations;

namespace Customer.Models;

public class CustomerSupport {
    public int Id { get; set; }
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    [StringLength(80)]
    public string? Email { get; set; }
    [StringLength(12)]
    public string? Phone { get; set; }
    public bool IsActive { get; set; } = true;
}
