using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Model
{
    public partial class Client
    {
        public int Idclient { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public int? Idaddress { get; set; }
        public string Mail { get; set; }
        public string Contact { get; set; }
        public string ContactTel { get; set; }
        public int? IdcontactAdress { get; set; }
        public string ContactMail { get; set; }

        public virtual Address IdaddressNavigation { get; set; }
    }
}
