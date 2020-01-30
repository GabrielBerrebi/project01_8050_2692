using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using outils;

namespace BE
{
    public class Order
    {
        public int HostingUnitKey { get; set; }
        public int GuestRequestKey { get; set; }
        public int OrderKey { get; set; }
        public GuestRequest requete { get; set; }
        public HostingUnit unit { get; set; }
        public Status status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime OrderDate { get; set; }
        public Status StatutOrder { get; set; }
        public Order()
        {
            
        }
        public override string ToString()
        {
            return this.TostringProperties();
        }
    }
}
