using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.Models
{
    public class CartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cartItem_id { get; set; }
        public int product_id { get; set; }

        [ForeignKey("product_id")]
        public Product Product { get; set; }
        public string loginUser { get; set; }
        public int quantityToBuy { get; set; }
    }
}
