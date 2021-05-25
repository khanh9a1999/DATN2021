using BLL.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class adsbll : iadsbll
    {
        private iadsdal _res;
        public adsbll(iadsdal LoaiSPRes)
        {
            _res = LoaiSPRes;
        }
        public bool Create(ads model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(ads model)
        {
            return _res.Update(model);
        }
        public ads GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public List<ads> Search(int pageIndex, int pageSize, out long total, string noidung)
        {
            return _res.Search(pageIndex, pageSize, out total, noidung);
        }
    }
}
