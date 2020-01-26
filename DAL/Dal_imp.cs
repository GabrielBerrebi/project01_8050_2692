using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DSi;

namespace DAL
{
    public class Dal_imp : Idal
    {
        public bool addhostingunit(HostingUnit hostingUnit)
        {

            if (DataSource.hostingUn.Any(n => n.HostingUnitKey==hostingUnit.HostingUnitKey)) { return false; }
            DataSource.hostingUn.Add(hostingUnit);
            return true;
        }

        public bool AddOrder(Order order)
        {
            if (DataSource.orders.Any(n=> n.OrderKey == order.OrderKey)) { return false; }
             DataSource.orders.Add(order);
            
            
            return true;
        }

        public bool addrequest(GuestRequest getRequest)
        {
            if (DataSource.guestRequests.Any(n => n.GuestRequestKey == getRequest.GuestRequestKey)) { return false; }
            DataSource.guestRequests.Add(getRequest);
            return true;
        }

        public BankBranch GetBankBranch(int id)
        {
            var resultbank = (from bank in DataSource.banks
                                 where bank.BankNumber == id
                                 select bank).FirstOrDefault();//renvoie moi le premiere element de la liste et si ya rien ne me renvoie rien
            return resultbank;

        }

        public GuestRequest GetGuestRequest(int id)
        {
            var resultrequest = (from GuestRequest in DataSource.guestRequests
                                 where GuestRequest.GuestRequestKey == id
                                 select GuestRequest).FirstOrDefault();//renvoie moi le premiere element de la liste et si ya rien ne me renvoie rien
            return resultrequest;
        }

        public HostingUnit GetHostingUnit(int id)
        {
            var resulthostingunit = (from HostingUnit in DataSource.hostingUn
                                     where HostingUnit.HostingUnitKey == id
                                     select HostingUnit).FirstOrDefault();
            return resulthostingunit;
        }

        public Order GetOrder(int id)
        {
            var resultorder = (from Order in DataSource.orders
                               where Order.GuestRequestKey == id
                               select Order).FirstOrDefault();
            return resultorder;
        }

       

        public bool HostingUnitModify(HostingUnit hostingUnit)
        {

            var resulthostingunit = (from HostingUnit in DataSource.hostingUn
                                     where HostingUnit.HostingUnitKey == hostingUnit.HostingUnitKey
                                     select HostingUnit).FirstOrDefault();
            if (resulthostingunit != null)
            {
                resulthostingunit = hostingUnit;
                return true;

            }
            else return false;
        }

        public bool ModifyOrder(Order order)
        {
            var resultorder = (from ordeer in DataSource.orders
                                     where ordeer.OrderKey == order.OrderKey
                                     select ordeer).FirstOrDefault();
            if (resultorder != null)
            {
                resultorder = order;
                return true;

            }
            else return false;
        } 

        public bool StatusModify(GuestRequest status)
        {
            var resultguest= (from guestrequest in DataSource.guestRequests
                                     where guestrequest.GuestRequestKey == status.GuestRequestKey
                                     select guestrequest).FirstOrDefault();
            if (resultguest != null)
            {
                resultguest = status;
                return true;

            }
            else return false;
        }
       public  bool releasehostingunit(HostingUnit hostingUnit)
        {
            if (DataSource.hostingUn.Any(n => n.HostingUnitKey == hostingUnit.HostingUnitKey))
            {
                DataSource.hostingUn.Remove(hostingUnit);
                return true;
            }
                      return false;
        }

        public List<Order> GetOrders()
        {
            foreach (  Order item in  DataSource.orders)
            {
                GetOrders().Add(item);
            }
            return GetOrders().ToList();
        }

        public List<HostingUnit> Getunits()
        {
            foreach (HostingUnit item in DataSource.hostingUn)
            {
                Getunits().Add(item);
            }
            return Getunits().ToList();
        }
    }
}
