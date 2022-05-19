using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prs_server_net6_c37.Models {

    [Index(nameof(PartNbr), IsUnique = true)]
    public class Product {

        public int Id { get; set; } = 0;
        [StringLength(30)]
        public string PartNbr { get; set; } = string.Empty;
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(11,2)")]
        public decimal Price { get; set; } = 0;
        [StringLength(30)]
        public string Unit { get; set; } = "Each";
        [StringLength(30)]
        public string? Photopath { get; set; } = null;

        public int VendorId { get; set; } = 0;
        public virtual Vendor? Vendor { get; set; } = null;
    }
}
