using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;

namespace DSi
{
    public static class DataSourceXML
    {
        public class XML
        {
            XElement GuestRequestRoot;
            string GuestRequestPath = @"GuestRequestXML.xml";

            XElement HostingUnitRoot;
            string HostingUnitPath = @"HostingUnitXML.xml";

            XElement OrderRoot;
            string OrderPath = @"OrderXML.xml";

            XElement HostRoot;
            string HostPath = @"HostPathXML.xml";


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

            public void SaveHostingUnit(List<HostingUnit> HostingUnitList)
            {
                HostingUnitRoot = new XElement("HostingUnits", from p in HostingUnitList
                                                               select new XElement("HostingUnit",
                                                               new XElement("HostingUnitKey", p.HostingUnitKey),
                                                               new XElement("Owner",
                                                               new XElement("HostKey", p.Owner.HostKey),
                                                               new XElement("Name",
                                                               new XElement("PrivateName", p.Owner.PrivateName),
                                                               new XElement("FamilyName", p.Owner.FamillyName)
                                                                            ),
                                                               new XElement("PhoneNumber", p.Owner.PhoneNumber),
                                                               new XElement("MailAddress", p.Owner.MailAddress)
                                                                            ),
                                                               new XElement("HostingUnitName", p.HostingUnitName),
                                                               new XElement("Area", p.Area),
                                                               new XElement("HostingUnitType", p.HostType),
                                                               new XElement("Adults", p.NumAdultes),
                                                               new XElement("Chidren", p.Children),
                                                               new XElement("Pool", p.Pool),
                                                               new XElement("Jacuzzi", p.Jaccuzzi),
                                                               new XElement("Garden", p.Garden),
                                                               new XElement("ChildrenAttraction", p.ChildrenAttraction)
                                                                                    )
                                                 );
                HostingUnitRoot.Save(HostingUnitPath);
            }

            public void SaveOrder(List<Order> OrderList)
            {
                OrderRoot = new XElement("Orders", from p in OrderList
                                                   select new XElement("Order",
                                                   new XElement("HostingUnitKey", p.HostingUnitKey),
                                                   new XElement("GuestRequestKey", p.GuestRequestKey),
                                                   new XElement("OrderKey", p.OrderKey),
                                                   new XElement("Status", p.status),
                                                   new XElement("OrderDate", p.OrderDate)
                                                                        )
                                         );
                OrderRoot.Save(OrderPath);
            }

            public void SaveHost(List<Host> HostList)
            {
                HostRoot = new XElement("Hosts", from p in HostList
                                                 select new XElement("Host",
                                                 new XElement("HostKey", p.HostKey),
                                                 new XElement("Name",
                                                 new XElement("PrivateName", p.PrivateName),
                                                 new XElement("FamilyName", p.FamillyName)
                                                             ),
                                                 new XElement("PhoneNumber", p.PhoneNumber),
                                                 new XElement("MailAddress", p.MailAddress)
                                                                     )
                                        );
                HostRoot.Save(HostPath);
            }
        }
    }
}
