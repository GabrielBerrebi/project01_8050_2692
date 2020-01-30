using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using DAL;
using DSi;

namespace BL
{
    class BL_imp : IBL
    {

        Idal instance = DalFactory.Instance;

        public string unitpercity()
        {
            string str = "";
            var city = from HostingUnit unit in DataSource.hostingUn
                       group unit by unit.Area;
            foreach (IGrouping<string, HostingUnit> group in city)
            {
                str += group.Key + ":";
                foreach (HostingUnit unit in group)
                    str += unit.HostingUnitKey;
            }
            return str;
        }
        public void AddCalendar(GuestRequest x, HostingUnit y)
        {
            for (int i = x.EntryDate.Day - 1, j = x.EntryDate.Month - 1; i != x.ReleaseDate.Day - 1 && j != x.ReleaseDate.Month - 1; i++)
            {
                y.Diary[i, j] = true;
                if (i > 30)
                {
                    i = 0;
                    j++;
                    if (j > 11)
                    {
                        j = 0;
                    }
                }
            }
        }
       
        public List<HostingUnit> hostingUnits(int id)
        {
            List < HostingUnit>units = new List<HostingUnit>();
            foreach(HostingUnit unit in DataSource.hostingUn)
            {
                if(unit.Owner.HostKey==id)
                {
                    units.Add(unit);
                }

            }
            return units;
        }
        public bool verifyunit(int id)
        {
            foreach(HostingUnit unit in  DataSource.hostingUn)
            {
                if (unit.HostingUnitKey==id)
                {
                    return true;
                }
            }
            return false;
        }
        public void  HostOrder(int a,int b)
        {
            DataSource.orders.Add(new Order {GuestRequestKey=b,HostingUnitKey=a,status=Status.CloseByNoCustomerResponse,unit=GetHostingUnit(a),OrderDate=DateTime.Now, });

        }
        public void AddHost(Host b)
        {
            instance.AddHost(b);
        }
        public void insert_date(GuestRequest b, HostingUnit a)
        {

        }

        public bool addhostingunit(HostingUnit hostingUnit)
        {

             hostingUnit.HostingUnitKey = config.newroom++;
            DataSource.hostingUn.Add(hostingUnit);
            return true;
        }

        public bool addrequest(GuestRequest getRequest)
        {
            if (instance.addrequest(getRequest) == false || getRequest.EntryDate.AddDays(1) >= getRequest.ReleaseDate)
            {
                return false;
            }
            else
                getRequest.GuestRequestKey = config.serialguestrequest++;
              instance.addrequest(getRequest);
              return true;
        }

        public GuestRequest GetGuestRequest(int id)// affiche toutes les requetes appartenant a un client 
        {
            LoadData();
            GuestRequest guestRequest;

            try
            {
                guestRequest = (from n in GuestRequestRoot.Elements()
                                where int.Parse(n.Element("GuestRequestKey").Value) == id
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

                                }).FirstOrDefault();
            }
            catch
            {
                guestRequest = null;
            }

            return guestRequest;


        }

        public HostingUnit GetHostingUnit(int id)//affiche tout mes hosting unit 
        {
            HostingUnit unit=null;
            foreach (HostingUnit units in DataSource.hostingUn)
            {
                if (units.HostingUnitKey == id)
                {
                    return units;
                }

            }
            return unit;
        }

        public string GetOrder(int id)// affiche tout les orders du client 
        {
            string str = " ";
            foreach (Order unit in DataSource.orders)
            {
                if (unit.OrderKey == id)
                {
                    str += unit.ToString();
                }
            }
            return str;
        }

        public bool HostingUnitModify(HostingUnit hostingUnit)//A MODIFIER

        {
            if (instance.GetHostingUnit(hostingUnit.HostingUnitKey) !=null)
            {
               instance.HostingUnitModify(hostingUnit);
                return true;
            }
            else
                return false;//on ne la pas trouve
        }


        public bool releasehostingunit(HostingUnit hostingUnit)
        {
            foreach (Order order in DataSource.orders)
            {
                if (order.HostingUnitKey == hostingUnit.HostingUnitKey)
                {
                    return false;
                }
            }
            DataSource.hostingUn.Remove(hostingUnit);
            return true;
        }

       

        private void insert_date(GuestRequest status, object unit)//deja faite du targuil 2 va remplir mes dates
        {
            throw new NotImplementedException();
        }

        public bool Banq_Ishur(GuestRequest status)// le client a payer 
        {
            if (status.sum_to_pay == 0) { return true; }
            else return false;
        }

        public bool sent_mail(GuestRequest status)//l'hote regarde si il est daccord ou pas 
        {
            HostingUnit selctione= new HostingUnit();
            foreach (Order unit in DataSource.orders)
            {
                if (unit.status==Status.MailSent)
                {
                    if(status.interessing==true)
                    {
                        return true;
                    }
                }
            }
            return false;

        }
        public void modify_order(GuestRequest requete)
        {
            foreach (Order item in DataSource.orders)
            {
                if (requete.GuestRequestKey==item.GuestRequestKey)
                {
                    if (item.status==Status.CloseByApp)
                    {
                        DataSource.orders.Remove(item);
                    }
                }
            }
        }

        public void AddOrder(GuestRequest requete,HostingUnit unit)
        {
            DataSource.orders.Add(new Order
            {
                OrderKey = config.serialorder++,
                HostingUnitKey = unit.HostingUnitKey,
                unit = unit,
                requete=requete,
                status=Status.InProgress,
                GuestRequestKey=requete.GuestRequestKey
                
            });

        }


       
        void choose_of_client(int guest, int host)// me  change le statut de mes order en fonction du choix du client

        {
            foreach (Order item in DataSource.orders)
            {
                if (item.GuestRequestKey==guest)
                {
                    if (item.HostingUnitKey == host)
                    {
                        item.status = Status.MailSent;
                    }
                    else
                        item.status = Status.CloseByApp; 
                }
            }
        }

        bool verifydate(GuestRequest guest, HostingUnit unit)//si les dates sont libre alors envoie une proposition
        {

            for (int i = guest.EntryDate.Day - 1, j = guest.EntryDate.Month - 1; i != guest.ReleaseDate.Day - 1 && j != guest.ReleaseDate.Month - 1; i++)
            {
                if (unit.Diary[i, j] == true)
                {
                    return false;
                }
                if (i > 30)
                {
                    i = 0;
                    j++;
                    if (j > 11)
                    {
                        j = 0;
                    }
                }
            }
            return true;
        }

        public void AddOrder(GuestRequest requete)
        {
            throw new NotImplementedException();
        }

        bool IBL.verifydate(GuestRequest guest, HostingUnit unit)
        {
            for (int i = guest.EntryDate.Day - 1, j = guest.EntryDate.Month - 1; i != guest.ReleaseDate.Day - 1 && j != guest.ReleaseDate.Month - 1; i++)
            {
                if (unit.Diary[i, j] == true)
                {
                    return false;
                }
                if (i > 30)
                {
                    i = 0;
                    j++;
                    if (j > 11)
                    {
                        j = 0;
                    }
                }
            }
            return true;
        }

        public string GetBankBranch(int id)
        {
            throw new NotImplementedException();
        }

        List<HostingUnit> IBL.proposition(GuestRequest requete)
        {
            List<HostingUnit> best = new List<HostingUnit>();
            var compatible2 = from g in DataSource.hostingUn
                              where g.Area == requete.Area && g.Children >= requete.Children && g.NumAdultes >= requete.NumAdultes && g.Pool == requete.Pool && g.Jaccuzzi == requete.Jaccuzzi &&
                              g.ChildrenAttraction == requete.ChildrenAttraction && g.Garden == requete.Garden
                              select g;

            foreach (HostingUnit item in compatible2)
            {
                if (verifydate(requete, item))
                {
                    best.Add(item);
                }
              
            }
            return best;
        }

        void IBL.choose_of_client(int guest, int host)
        {
            throw new NotImplementedException();
        }
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














