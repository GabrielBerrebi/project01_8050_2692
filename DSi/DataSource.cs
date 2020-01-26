using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DSi
{
    public static class DataSource
    {
        public static List<HostingUnit> hostingUn = new List<HostingUnit>()
       {
        new HostingUnit()
         {
            HostingUnitName="gabriel",Pool=CollectionClearance.yes,Jaccuzzi=CollectionClearance.yes,Garden=CollectionClearance.yes,ChildrenAttraction=CollectionClearance.yes,Area=Area.Jerusalem,Owner=new Host{PrivateName="gabriel",FamillyName="berrebi",PhoneNumber=058668240,MailAddress="gabriel@gmail.com",
            BankBranchDetail =new BankBranch
            {
                

                BankName ="leumi",BranchNumber=12345,
                BranchAddress ="talpiot",
                BranchCity ="jerusalem",BankNumber=12345
            }
          }

        }
        };



        public static List<GuestRequest> guestRequests = new List<GuestRequest>()
        {
            new GuestRequest()
            {
               // GuestRequestKey=1000,PrivateName="gabriel",FamillyName="Berrebi"
               // ,MailAddress="gabriel27051998@gmail.com",
               // Status =Status.MailSent,RegistrationDate=DateTime.Now,EntryDate=new DateTime(12,03,2020),
               // ReleaseDate =new DateTime(12,04,2020),
              //  Area=Area.Jerusalem,HostType=HostingType.Hotel,NumAdultes=2,Children=3,
      
            }

        };
        public static List<HostingUnit> units = new List<HostingUnit>();
        public static List<Order> orders = new List<Order>();
        public static List<BankBranch> banks = new List<BankBranch>();
        public static List<Host> hosts = new List<Host>();
    };
   
}
