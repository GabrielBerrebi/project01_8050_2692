using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DSi;
namespace DAL
{
    public interface Idal
    {
         bool addrequest(GuestRequest  getRequest);
         bool StatusModify(GuestRequest status);
         bool addhostingunit(HostingUnit hostingUnit);
         bool releasehostingunit(HostingUnit hostingUnit);
         bool HostingUnitModify(HostingUnit hostingUnit);
         bool AddOrder(Order order);
         bool ModifyOrder(Order order);
          bool AddHost(Host a);
          HostingUnit GetHostingUnit(int id);
          GuestRequest GetGuestRequest(int id);
          Order GetOrder(int id);
          BankBranch GetBankBranch(int id);
           List<Order> GetOrders();
           List<HostingUnit> Getunits();
    }
}
