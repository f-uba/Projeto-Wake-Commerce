namespace Domain.Entities.DTOs
{
    public sealed class ProductDTO
    {
        /// <summary>
        /// Unique identificator of a product
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Quantity of the product in stock
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Value of the product
        /// </summary>
        public double Value { get; set; }
    }
}
