﻿using DAL.Helper;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class userdal : iuserdal
    {
        private IDatabaseHelper _dbHelper;
        public userdal(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Create(User model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "bt_user_create",
                "@user_id", model.user_id,
                "@hoten", model.hoten,
                "@ngaysinh", model.ngaysinh,
                "@diachi", model.diachi,
                "@gioitinh", model.gioitinh,
                "@email", model.email,
                "@taikhoan", model.taikhoan,
                "@matkhau", model.matkhau,
                "@role", model.role,
                "@image_url", model.image_url);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "bt_user_delete",
                "@user_id", id);
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
        public bool Update(User model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "bt_user_update",
                "@user_id", model.user_id,
                "@hoten", model.hoten,
                "@ngaysinh", model.ngaysinh,
                "@diachi", model.diachi,
                "@gioitinh", model.gioitinh,
                "@email", model.email,
                "@taikhoan", model.taikhoan,
                "@matkhau", model.matkhau,
                "@role", model.role,
                "@image_url", model.image_url);
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


        public User GetUser(string username, string password)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "bt_user_get_by_username_password",
                     "@taikhoan", username,
                     "@matkhau", password);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<User>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "bt_user_get_by_id",
                     "@user_id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<User>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<User> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "bt_user_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@hoten", hoten,
                    "@taikhoan", taikhoan);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<User>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
