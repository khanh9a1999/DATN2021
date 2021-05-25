using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Interfaces;
using Models;

namespace BLL
{
    public class bangtinbll : ibangtinbll
    {
        private ibangtindal _res;
        public bangtinbll (ibangtindal LoaiSPRes)
        {
            _res = LoaiSPRes;
        }
        public bool Create(bangtin model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(bangtin model)
        {
            return _res.Update(model);
        }
        //timkiem
        
        public List<bangtin> Search(int pageIndex, int pageSize, out long total, string tieude)
        {
            return _res.Search(pageIndex, pageSize, out total, tieude);
        }
        public List<bangtin> SearchCategory(int pageIndex, int pageSize, out long total, string idtheloai)
        {
            return _res.SearchCategory(pageIndex, pageSize, out total, idtheloai);
        }
        public List<bangtin> GetDataNew1()
        {
            return _res.GetDataNew1();
        }
        public List<bangtin> GetDataNew2()
        {
            return _res.GetDataNew2();
        }
        public List<bangtin> GetDataNew3()
        {
            return _res.GetDataNew3();
        }
        public List<bangtin> GetDataNew4()
        {
            return _res.GetDataNew4();
        }
        public List<bangtin> GetDataNew5()
        {
            return _res.GetDataNew5();
        }
        public List<bangtin> GetDataNewDoiSong()
        {
            return _res.GetDataNewDoiSong();
        }
        public List<bangtin> GetDataNewDoiSong1()
        {
            return _res.GetDataNewDoiSong1();
        }
        public List<bangtin> GetDataNewDuLich()
        {
            return _res.GetDataNewDuLich();
        }
        public List<bangtin> GetDataNewTheThao()
        {
            return _res.GetDataNewTheThao();
        }
        public List<bangtin> GetDataNewPhapLuat()
        {
            return _res.GetDataNewPhapLuat();
        }
        public List<bangtin> GetDataNewViecLam()
        {
            return _res.GetDataNewViecLam();
        }
        public List<bangtin> GetDataNewGiaoDuc()
        {
            return _res.GetDataNewGiaoDuc();
        }
        public bangtin GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public List<bangtin> Gettuongtu(int idbantin)
        {
            return _res.Gettuongtu(idbantin);
        }
    }
}
