using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using DSi;
using outils;

namespace DAL
{
    public class Dal_imp : Idal
    {
        public bool AddHost(Host host)
        {
           
            DataSource.hosts.Add(host);
            return true;
        }
        public bool addhostingunit(HostingUnit hostingUnit)
        {

            if (DataSource.hostingUn.Any(n => n.HostingUnitKey==hostingUnit.HostingUnitKey)) { return false; }
            DataSource.hostingUn.Add(hostingUnit);
            return true;
        }

        public bool AddOrder(Order order)
        {
            Random aleatoire = new Random();
            
            if (DataSource.orders.Any(n=> n.OrderKey == order.OrderKey)) { return false; }
            order.OrderKey = aleatoire.Next(1000000);
            DataSource.orders.Add(order);
            
            
            return true;
        }

        public bool addrequest(GuestRequest getRequest)
        {
            if (GetGuestRequestList().Any(n => n.GuestRequestKey == getRequest.GuestRequestKey))
            {
                return false;
            }
            XElement GuestRequestKey = new XElement("GuestErequestKey", getRequest.GuestRequestKey);
            XElement PrivateName = new XElement("PrivateName", getRequest.PrivateName);
            XElement FamilyName = new XElement("FamilyName", getRequest.FamillyName);
            XElement Name = new XElement("Name", PrivateName, FamilyName);
            XElement MailAddress = new XElement("MailAdress", getRequest.MailAddress);
            XElement RequestStatus = new XElement("RequestStatus", getRequest.Status);
            XElement RegistrationDate = new XElement("RegistrationDate", getRequest.RegistrationDate);
            XElement EntryDate = new XElement("Entrydate", getRequest.EntryDate);
            XElement ReleaseDate = new XElement("ReleaseDate", getRequest.ReleaseDate);
            XElement Area = new XElement("Area", getRequest.Area);
            XElement HostingType = new XElement("HostingType", getRequest.HostType);
            XElement NumAdults = new XElement("NumAdults", getRequest.NumAdultes);
            XElement NumChildren = new XElement("NumChildren", getRequest.Children);
            XElement Pool = new XElement("Pool", getRequest.Pool);
            XElement Jacuzzi = new XElement("Jacuzzi", getRequest.Jaccuzzi);
            XElement Garden = new XElement("Garden", getRequest.Garden);
            XElement ChildrenAttraction = new XElement("ChildrenAttraction", getRequest.ChildrenAttraction);

            GuestRequestRoot.Add(new XElement("GuestRequest", GuestRequestKey, Name, MailAddress, RequestStatus,
             RegistrationDate, EntryDate, ReleaseDate, Area, HostingType, NumAdults, NumChildren, Pool, Jacuzzi, Garden, ChildrenAttraction));
            GuestRequestRoot.Save(GuestRequestPath);
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
        XElement GuestRequestRoot;
        string GuestRequestPath = @"GuestRequestXML.xml";


        public void SaveGuestRequest(List<GuestRequest> GuestRequestsList)
        {
            GuestRequestRoot = new XElement("GuestRequests", from p in GuestRequestsList
                                                             select new XElement("GuestRequest",
                                                             new XElement("GuestRequestKey", p.GuestRequestKey),
                                                             new XElement("Name",
                                                                new XElement("PrivateName", p.PrivateName),
                                                                new XElement("FamilyName", p.FamillyName)
                                                                        ),
                                                             new XElement("MailAddress", p.MailAddress),
                                                             new XElement("RequestStatus", p.Status),
                                                             new XElement("RegistrationDate", p.RegistrationDate),
                                                             new XElement("EntryDate", p.EntryDate),
                                                             new XElement("ReleaseDate", p.ReleaseDate),
                                                             new XElement("Area", p.Area),
                                                             new XElement("HostingType", p.HostType),
                                                             new XElement("NumAdults", p.NumAdultes),
                                                             new XElement("NumChildren", p.Children),
                                                             new XElement("Pool", p.Pool),
                                                             new XElement("Jacuzzi", p.Jaccuzzi),
                                                             new XElement("Garden", p.Garden),
                                                             new XElement("CildrenAttraction", p.ChildrenAttraction)
                                                                                )
                                            );
            GuestRequestRoot.Save(GuestRequestPath);
        }


        public List<GuestRequest> GetGuestRequestList()
        {
            SaveGuestRequest(GetGuestRequestList());
            LoadData();
            List<GuestRequest> guestRequest;
            try
            {
                guestRequest = (from n in GuestRequestRoot.Elements()
                                select new GuestRequest()
                                {
                                    GuestRequestKey = int.Parse(n.Element("GuestRequestKey").Value),
                                    PrivateName = n.Element("Name").Element("PriavteName").Value,
                                    FamillyName = n.Element("Name").Element("FamilyName").Value,
                                    MailAddress = n.Element("MailAddress").Value,

                                    RegistrationDate = DateTime.Parse(n.Element("RegistrationDate").Value),
                                    EntryDate = DateTime.Parse(n.Element("Entrydate").Value),
                                    ReleaseDate = DateTime.Parse(n.Element("ReleaseDate").Value),

                                    NumAdultes = int.Parse(n.Element("NumAdults").Value),
                                    Children = int.Parse(n.Element("NumChildren").Value)



                                }).ToList();

            }
            catch
            {
                guestRequest = null;
            }
            return guestRequest;
        }

        private void LoadData()
        {
            try
            {
                GuestRequestRoot = XElement.Load(GuestRequestPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
    }
}
