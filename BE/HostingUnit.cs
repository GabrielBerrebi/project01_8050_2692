using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using outils;
namespace BE
{
    
    public class HostingUnit
    {
        public int  HostingUnitKey { get;  set; }
        public Host Owner { get; set; }
        public string HostingUnitName { get; set; }
        public int price { get; set; }
        public bool[,] Diary { get; set; }//j ai rajouter ca pour poser les condition du host!
        public Area Area { get; set; }
        public HostingType HostType { get; set; }
        public string Description { get; set; }
        public int NumAdultes { get; set; }
        public int Children { get; set; }
        public CollectionClearance Pool { get; set; }
        public CollectionClearance Jaccuzzi { get; set; }
        public CollectionClearance Garden { get; set; }
        public CollectionClearance ChildrenAttraction { get; set; }
        public HostingUnit()
        {
            Diary = new bool[31, 12];//constructeur pour mon tableau !
            
        }
        
        public override string ToString()
        {
            return this.TostringProperties();
        }
      
    }
}
