using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface itheloaidal
    {
        List<theloai> GetData();
        theloai GetDatabyID(string id);
        bool Create(theloai model);
        bool Update(theloai model);
        bool Delete(string id);
        List<theloai> Search(int pageIndex, int pageSize, out long total, string tentheloai);
    }
}
