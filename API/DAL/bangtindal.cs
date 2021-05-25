using DAL.Helper;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class bangtindal : ibangtindal
    {
        private IDatabaseHelper _dbHelper;
        public bangtindal(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Create(bangtin model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "bt_bantin_create",
                "@idbantin", model.idbantin,
                "@idtheloai", model.idtheloai,
                "@tieude", model.tieude,
                "@anh ", model.anh,
                "@noidung ", model.noidung,
                "@lanxem", model.lanxem,
                "@ngaydang", model.ngaydang);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "bt_bantin_delete",
                "@idbantin", id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(bangtin model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "bt_bantin_update",
                "@idbantin", model.idbantin,
                "@idtheloai", model.idtheloai,
                "@tieude", model.tieude,
                "@anh ", model.anh,
                "@noidung ", model.noidung,
                "@lanxem", model.lanxem,
                "@ngaydang", model.ngaydang);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<bangtin> Search(int pageIndex, int pageSize, out long total, string tieude)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "bt_bantin_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@tieude", tieude);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<bangtin>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<bangtin> SearchCategory(int pageIndex, int pageSize, out long total, string idtheloai)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "bt_bantin_get_by_theloai",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@idtheloai", idtheloai);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<bangtin>().ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<bangtin> GetDataNew2()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "bt_bantin_new_2");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<bangtin>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<bangtin> GetDataNew1()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "bt_bantin_new_1");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<bangtin>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<bangtin> GetDataNew3()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "bt_bantin_new_3");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<bangtin>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<bangtin> GetDataNew4()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "bt_bantin_new_4");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<bangtin>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<bangtin> GetDataNew5()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "bt_bantin_new_5");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<bangtin>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<bangtin> GetDataNewDoiSong()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "bt_bantin_new_doisong");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<bangtin>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<bangtin> GetDataNewDoiSong1()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "bt_bantin_new_doisong1");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<bangtin>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<bangtin> GetDataNewDuLich()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "bt_bantin_new_dulich");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<bangtin>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<bangtin> GetDataNewTheThao()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "bt_bantin_new_thethao");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<bangtin>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<bangtin> GetDataNewPhapLuat()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "bt_bantin_new_phapluat");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<bangtin>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<bangtin> GetDataNewViecLam()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "bt_bantin_new_vieclam");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<bangtin>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<bangtin> GetDataNewGiaoDuc()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "bt_bantin_new_giaoduc");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<bangtin>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bangtin GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "bt_bantin_get_by_id",
                     "@idbantin", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<bangtin>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<bangtin> Gettuongtu(int idbantin)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sptuongtu", " @idbantin", idbantin);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<bangtin>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
