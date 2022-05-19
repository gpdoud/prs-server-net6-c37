using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prs_server_net6_c37.Models {

    public class Request {

        public int Id { get; set; } = 0;
        [StringLength(80)]
        public string Description { get; set; } = string.Empty;
        [StringLength(80)]
        public string Justification { get; set; } = string.Empty;
        [StringLength(80)]
        public string? RejectionReason { get; set; } = null;
        [StringLength(30)]
        public string DeliveryMode { get; set; } = string.Empty;
        [StringLength(10)]
        public string Status { get; set; } = string.Empty;
        [Column(TypeName = "decimal(11,2)")]
        public decimal Total { get; set; } = 0;

        public int UserId { get; set; } = 0;
        public virtual User? User { get; set; } = null;

        public virtual IEnumerable<Requestline>? Requestlines { get; set; } = null;

    }
}
