using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gibdd.DBO
{
    class AutoForCardIndOwner
    {
        public int AutoID { get; set; }
        public string Number { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public bool DrivingAway { get; set; }
        public int OwnerID { get; set; }
    }
}
