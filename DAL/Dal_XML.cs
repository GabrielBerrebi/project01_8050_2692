using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using DSi;

namespace DAL
{
    public class Dal_XML : Idal 
    {
        XElement GuestRequestRoot;
        string GuestRequestPath = @"GuestRequestXML.xml";

        public List<GuestRequest> GetGuestRequestList()
        {
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
                                    MailAddress = n.Element("MailAddress").Value



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

        public bool addhostingunit(HostingUnit hostingUnit)
        {
            throw new NotImplementedException();
        }

        public bool AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public bool addrequest(GuestRequest getRequest)
        {
            throw new NotImplementedException();
        }

        public BankBranch GetBankBranch(int id)
        {
            throw new NotImplementedException();
        }

        public GuestRequest GetGuestRequest(int id)
        {
            throw new NotImplementedException();
        }

        public HostingUnit GetHostingUnit(int id)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public List<HostingUnit> Getunits()
        {
            throw new NotImplementedException();
        }

        public bool HostingUnitModify(HostingUnit hostingUnit)
        {
            throw new NotImplementedException();
        }

        public bool ModifyOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public bool releasehostingunit(HostingUnit hostingUnit)
        {
            throw new NotImplementedException();
        }

        public bool StatusModify(GuestRequest status)
        {
            throw new NotImplementedException();
        }

        public bool AddHost(Host a)
        {
            throw new NotImplementedException();
        }
    }
}
