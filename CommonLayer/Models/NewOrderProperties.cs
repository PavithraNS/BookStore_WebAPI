using LanguageExt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.Models
{
    public class NewOrderProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId { get; set; }
        [Required]
        public int product_id { get; set; }

        [Required]
        public string product_name { get; set; }

        [Required]
        //min: 1
        public long product_quantity { get; set; }

        [Required]
        public long product_price { get; set; }
    }
}
