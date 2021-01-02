using LanguageExt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int product_id { get; set; }
        [Required]
        public string bookName { get; set; }
        public string bookImage { get; set; }
        public string admin_user_id { get; set; }
        
        [Required]
        public string author { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public long quantity { get; set; }

        [Required]
        //min: 1
        public long price { get; set; }

        public long discountPrice { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
    }
}
