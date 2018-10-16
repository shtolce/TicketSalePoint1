using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSalePoint.Models
{
    public class User  {
        public int id {
            get;
            set;
        }
        public string firstName {
            get;
            set;
        }
        public string coName {
            get;
            set;
        }
        public int type {
            get;
            set;
        }
        public string address {
            get;
            set;
        }
        public Card card {
            get;
            set;
        }
        public string phoneNumber
        {
            get;
            set;
        }
        public int age
        {
            get;
            set;
        }
        public bool isChildren
        {
            get;
            set;
        }



    }
}
