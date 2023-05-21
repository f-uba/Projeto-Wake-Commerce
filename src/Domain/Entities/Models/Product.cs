using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Models
{
    public sealed class Product
    {
        /// <summary>
        /// Unique identificator of a product
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the product
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Quantity of the product in stock
        /// </summary>
        [Required]
        public int Stock { get; set; }

        /// <summary>
        /// Value of the product
        /// </summary>
        [Required]
        public double Value { get; set; }
    }
}
