namespace SalesBuzz.API.DTOs
{
    public class PatchProductDto
    {
        public string? Name { get; set; }

        public decimal? Price { get; set; }

        public int? StockQuantity { get; set; }
    }
}