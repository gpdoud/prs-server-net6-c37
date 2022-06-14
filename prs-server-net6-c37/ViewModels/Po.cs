using prs_server_net6_c37.Models;

namespace prs_server_net6_c37.ViewModels {
    public class Po {
        public Vendor Vendor { get; set; } = null!;
        public IEnumerable<Poline> Polines { get; set; } = null!;
        public decimal PoTotal { get; set; } = 0;
    }
}
