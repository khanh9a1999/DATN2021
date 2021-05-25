using BLL.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class theloaibll : itheloaibll
    {
        private itheloaidal _res;
        public theloaibll(itheloaidal iloaisp2)
        {
            _res = iloaisp2;
        }
        public List<theloai> GetData()
        {
            var allCategory = _res.GetData();
            var lstParent = allCategory.Where(ds => ds.parent_maloai == null).OrderBy(s => s.idtheloai).ToList();
            foreach (var item in lstParent)
            {
                item.children = GetHiearchyList(allCategory, item);
            }
            return lstParent;
        }
        public List<theloai> GetHiearchyList(List<theloai> lstAll, theloai node)
        {
            var lstChilds = lstAll.Where(ds => ds.parent_maloai == node.idtheloai).ToList();
            if (lstChilds.Count == 0)
                return null;
            for (int i = 0; i < lstChilds.Count; i++)
            {
                var childs = GetHiearchyList(lstAll, lstChilds[i]);
                lstChilds[i].type = (childs == null || childs.Count == 0) ? "leaf" : "";
                lstChilds[i].children = childs;
            }
            return lstChilds.OrderBy(s => s.idtheloai).ToList();
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public theloai GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(theloai model)
        {
            return _res.Create(model);
        }
        public bool Update(theloai model)
        {
            return _res.Update(model);
        }
        public List<theloai> Search(int pageIndex, int pageSize, out long total, string tentheloai)
        {
            return _res.Search(pageIndex, pageSize, out total, tentheloai);
        }
    }
}
