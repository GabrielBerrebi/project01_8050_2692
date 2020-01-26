using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace DAL
{
    public static class extensions
    {
        public static Order Clone(this Order order)//on va mettre un clone du order dans notre nouveau tableau bH
        {
            return new Order
            {
                OrderKey = order.OrderKey,
                StatutOrder = order.StatutOrder,
                CreateDate = order.CreateDate,
                GuestRequestKey = order.GuestRequestKey,
                HostingUnitKey = order.HostingUnitKey,
                OrderDate = order.OrderDate
            };
        }
    }
}
