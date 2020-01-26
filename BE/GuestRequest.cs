using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using outils;

namespace BE
{
    public class GuestRequest
    {
        public int HostingUnitkeychoose { get; set; }//hosting unit qui interesse mon client 
        public int GuestRequestKey { get;  set; }
        public String PrivateName { get;  set; }
        public String FamillyName { get;  set; }
        public String  MailAddress { get;  set; }
        public Status Status{ get;  set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Area Area { get; set; }
        public HostingType HostType { get; set; }
        public int NumAdultes { get; set; }
        public int Children { get; set; }
        public CollectionClearance Pool { get; set; }
        public CollectionClearance Jaccuzzi { get; set; }
        public CollectionClearance Garden { get; set; }
        public CollectionClearance  ChildrenAttraction  { get; set; }
        public bool interessing { get; set; }
        public int sum_to_pay = 0;// rien a payer car rien na encore ete fait
        public GuestRequest() { }
        
     
        public override string ToString()
        {
            return this.TostringProperties();
        }


    }
}
