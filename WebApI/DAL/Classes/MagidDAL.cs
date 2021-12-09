using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Classes
{
    public class MagidDAL
    {
        public static List<Magid> GetListMagids()
        {
            using (VizelContext db = new VizelContext())
            {
                return db.Magids.ToList();
            }
        }
    }
}
