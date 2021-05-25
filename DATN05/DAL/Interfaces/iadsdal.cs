using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace DAL.Interfaces
{
    public partial interface iadsdal
    {
        bool Create(ads model);
        bool Update(ads model);
        bool Delete(string id);
        ads GetDatabyID(int id);
        List<ads> Search(int pageIndex, int pageSize, out long total, string noidung);
    }
}
