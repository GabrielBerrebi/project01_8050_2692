using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using outils;
namespace BE
{
   public class Host
    {
        public int HostKey { get;  set; }
        public string PrivateName { get; set; }
        public string FamillyName { get; set; }
        public int PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public BankBranch BankBranchDetail { get; set; }
     
      
        public override string ToString()
        {
            return this.TostringProperties();
        }
    }
}
