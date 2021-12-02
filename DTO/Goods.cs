using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Goods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool Selling { get; set; }
        public bool Image { get; set; }
        public string Url { get; set; }

        public Goods(int id, string name, string unit, double price, int quantity, bool selling, bool image, string url = null)
        {
            Id = id;
            Name = name;
            Unit = unit;
            Price = price;
            Quantity = quantity;
            Selling = selling;
            Image = image;
            Url = url;
        }
    }
}
