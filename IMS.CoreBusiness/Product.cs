using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to 1")]
        public int Quantity { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater or equal to 1")]
        public double Price { get; set; }
        public string Description { get; set; }

        //components

        public string Cpu { get; set; }
        public string Case { get; set; }
        public string Memmory { get; set; }
        public string Hdd { get; set; }
        public string PowerSupply { get; set; }
        public string Motherboard { get; set; }
        public string GraphicCard { get; set; }

    }
}
