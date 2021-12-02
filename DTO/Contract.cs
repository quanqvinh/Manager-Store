using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Contract
    {
        public int CID { get; set; }
        public int EID { get; set; }
        public string Ename { get; set; }
        public double PriceContract { get; set; }
        public Dictionary<string, Goods> Goods { get; set; }
        public List<double> PriceImport { get; set; }
        public Provider Prov { get; set; }
        public DateTime Date { get; set; }
        public Contract()
        {
            Goods = new Dictionary<string, Goods>();
            PriceImport = new List<double>();
        }
        public void Add(Goods g, double price)
        {
            Goods.Add(g.Name, g);
            PriceImport.Add(price);
        }
    }
}
