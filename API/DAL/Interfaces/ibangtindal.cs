using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DAL.Interfaces
{
    public partial interface ibangtindal
    {
        bool Create(bangtin model);
        bool Update(bangtin model);
        bool Delete(string id);
        //timkiem
        List<bangtin> Search(int pageIndex, int pageSize, out long total, string tieude);
        List<bangtin> SearchCategory(int pageIndex, int pageSize, out long total, string idtheloai);
        List<bangtin> GetDataNew1();
        List<bangtin> GetDataNew2();
        List<bangtin> GetDataNew3();
        List<bangtin> GetDataNew4();
        List<bangtin> GetDataNew5();
        List<bangtin> GetDataNewDoiSong();
        List<bangtin> GetDataNewDoiSong1();
        List<bangtin> GetDataNewDuLich();
        List<bangtin> GetDataNewTheThao();
        List<bangtin> GetDataNewPhapLuat();
        List<bangtin> GetDataNewViecLam();
        List<bangtin> GetDataNewGiaoDuc();
        bangtin GetDatabyID(int id);
        List<bangtin> Gettuongtu(int idbantin);






    }
}
