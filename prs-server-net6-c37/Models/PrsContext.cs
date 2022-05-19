using Microsoft.EntityFrameworkCore;

namespace prs_server_net6_c37.Models {
    
    public class PrsContext : DbContext {

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Vendor> Vendors { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<Requestline> Requestlines { get; set; } = null!;

        public PrsContext(DbContextOptions<PrsContext> options) : base(options) { }
    }
}
