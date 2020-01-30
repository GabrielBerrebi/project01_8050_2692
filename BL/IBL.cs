using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
namespace BL
{
    public interface IBL
    {
       string  unitpercity();
        void AddCalendar(GuestRequest x, HostingUnit y);
        List<HostingUnit> hostingUnits(int id);
        bool verifyunit(int id);
        void HostOrder(int hosting,int request);
        bool addhostingunit(HostingUnit hostingUnit);
        bool releasehostingunit(HostingUnit hostingUnit);
        bool HostingUnitModify(HostingUnit hostingUnit);
        void AddOrder(GuestRequest requete, HostingUnit unit);
        bool verifydate(GuestRequest a, HostingUnit c);
        bool addrequest(GuestRequest getRequest);
        HostingUnit GetHostingUnit(int prenom);
        GuestRequest GetGuestRequest(int id);
        string GetOrder(int id);
        string  GetBankBranch(int id);
        void AddHost(Host a);
        List<HostingUnit> proposition(GuestRequest a);
        bool Banq_Ishur(GuestRequest client);
        bool sent_mail(GuestRequest a);
        void insert_date(GuestRequest b, HostingUnit c);
        void choose_of_client(int guest, int host);
    }
}
