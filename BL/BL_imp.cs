using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using DSi;

namespace BL
{
    class BL_imp : IBL
    {

        Idal instance = DalFactory.Instance;
        public void AddHost(Host b)
        {
            DSi.DataSource.hosts.Add(b);
        }
        public void insert_date(GuestRequest b, HostingUnit a)
        {

        }

        public bool addhostingunit(HostingUnit hostingUnit)
        {

            if (instance.addhostingunit(hostingUnit) == false)//this hosting unit already exist! 1 ere condition
            {
                return false;
            }
            else
                hostingUnit.HostingUnitKey = config.newroom;
            instance.addhostingunit(hostingUnit);
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

        public string GetGuestRequest(int id)// affiche toutes les requetes appartenant a un client 
        {
            string str = " ";
            foreach (GuestRequest request in DataSource.guestRequests)
            {
                if (request.GuestRequestKey == id)
                {
                    str += request.ToString();
                }

            }
            return str;

        }

        public string GetHostingUnit(int id)//affiche tout mes hosting unit 
        {
            string str = " ";
            foreach (HostingUnit unit in DataSource.hostingUn)
            {
                if (unit.HostingUnitKey == id)
                {
                    str += unit.ToString();
                }

            }
            return str;
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

        public void StatusModify(GuestRequest status)//fonction qui va modifier le statut de ma commande si elle est accepte
        {
            if (status.Status==Status.InProgress )
            {
                status.Status = Status.MailSent;
            }
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
            OrderKey=config.serialorder++,
            HostingUnitKey=unit.HostingUnitKey,
                status=Status.InProgress
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

        bool IBL.verifydate(GuestRequest a, HostingUnit c)
        {
            throw new NotImplementedException();
        }

        public string GetBankBranch(int id)
        {
            throw new NotImplementedException();
        }

        List<HostingUnit> IBL.proposition(GuestRequest requete)
        {
            List<HostingUnit> best = new List<HostingUnit>();
            var compatible2 = from g in DataSource.hostingUn
                              where g.Area == requete.Area && g.Children <= requete.Children && g.NumAdultes <= requete.NumAdultes && g.Pool == requete.Pool && g.Jaccuzzi == requete.Jaccuzzi &&
                              g.ChildrenAttraction == requete.ChildrenAttraction && g.Garden == requete.Garden
                              select g;

            foreach (HostingUnit item in compatible2)
            {
                if (verifydate(requete, item) == true)
                {
                    best.Add(item);
                    AddOrder(requete, item);
                }
            }
            return best;
        }

        void IBL.choose_of_client(int guest, int host)
        {
            throw new NotImplementedException();
        }
    }
}














