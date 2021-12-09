using System;
using System.Collections.Generic;
using System.Text;
using DAL.Classes;
using DTO;

namespace BLL.Classes
{
    public class MagidBLL
    {
        public static List<MagidDTO> GetListMagids()
        {
            return MagidDTO.TOListMagidsDTO(MagidDAL.GetListMagids());
        }
    }
}
