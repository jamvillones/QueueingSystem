using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QueCounter
{
    public static class AppStartup
    {
        //public static string UniqueIdentifier
        //{
        //    get
        //    {
        //        string hostName = Dns.GetHostName(); // Retrive the Name of HOST              
        //        string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
        //        return myIP;
        //    }
        //}
        public static int CounterNumber { get; set; }

        public static bool AlreadyRegistered(int counter)
        {
            using (var q = new QueeuingEntities())
            {
                return q.Counters.Any(x => x.CounterNumber == counter);
            }
        }
    }
}
