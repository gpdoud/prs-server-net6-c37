namespace prs_server_net6_c37.ViewModels {
    public class Poline {
        public string Product { get; set; } = null!;
        public string PartNbr { get; set; } = null!;
        public decimal Price { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public decimal LineTotal => Price * Quantity;
    }
}
