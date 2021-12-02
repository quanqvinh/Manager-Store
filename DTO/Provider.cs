using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Provider
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool NewProvider { get; set; }
        public Provider(DataRow dr, bool _new)
        {
            ID = (int)dr["ID"];
            Name = (string)dr["Name"];
            Address = (string)dr["Address"];
            PhoneNumber = (string)dr["Phone Number"];
            NewProvider = _new;
        }
    }
}
