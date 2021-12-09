using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class MagidDTO
    {
        public int Idmagid { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }

        public static MagidDTO ToMagidDTO(Magid m)
        {
            if (m == null) return null;
            MagidDTO m1 = new MagidDTO()
            {
                Idmagid=m.Idmagid,
                Id = m.Id,
                Name = m.Name
            };
            return m1;
        }
            public static List<MagidDTO> TOListMagidsDTO(List<Magid> ls)
        {
            List<MagidDTO> ls1 = new List<MagidDTO>();
            foreach (var item in ls)
            {
                ls1.Add(ToMagidDTO(item));
            }
            return ls1;
        }
    }
}
