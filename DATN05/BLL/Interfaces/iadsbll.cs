using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface iadsbll
    {
        bool Create(ads model);
        bool Update(ads model);
        bool Delete(string id);
        ads GetDatabyID(int id);
        List<ads> Search(int pageIndex, int pageSize, out long total, string noidung);
    }
}
