using Gibdd.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gibdd.DBO
{
    class OwnerFullInfo 
    {
        public OwnerFullInfo()
        {
            Autos = new List<AutoForCardIndOwner>();
        }

        public int IndOwnerID { get; set; }
        public string Fio { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Inn { get; set; }
        public string NameCompany { get; set; }
        public bool IsEntity { get; set; }
        public List<AutoForCardIndOwner> Autos { get; set; }
    }
}
