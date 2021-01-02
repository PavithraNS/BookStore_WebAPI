using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.Models
{
    public class CustomerDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
        public string addressType { get; set; }

        [Required]
        public string email { get; set; }
        [Required]
        public string fullAddress { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string state { get; set; }
    }
}
