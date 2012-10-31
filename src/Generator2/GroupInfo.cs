using System.Collections.Generic;
using System.Linq;

namespace Generator2
{
    public class GroupInfo
    {
        public string Name;
        public bool Global;
        public List<MethodInfo> Methods=new List<MethodInfo>(); 
        public override string ToString()
        {
            return Name ;
        }



    }
}