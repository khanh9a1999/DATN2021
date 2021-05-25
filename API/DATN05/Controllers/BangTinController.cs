using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;

namespace DATN05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BangTinController : ControllerBase
    {
        private ibangtinbll _productBusiness;
        private string _path;
        public BangTinController(ibangtinbll productBusiness, IConfiguration configuration)
        {
            _productBusiness = productBusiness;
            _path = configuration["AppSettings:PATH"];
        }

        [Route("create-bantin")]
        [HttpPost]
        public bangtin CreateBanTin([FromBody] bangtin model)
        {
            if (model.anh != null)
            {
                var arrData = model.anh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"{arrData[0]}";
                    model.anh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            
            _productBusiness.Create(model);
            return model;
        }

        [Route("update-bantin")]
        [HttpPost]
        public bangtin UpdateBanTin([FromBody] bangtin model)
        {
            if (model.anh != null)
            {
                var arrData = model.anh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"{arrData[0]}";
                    model.anh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            //model.ngaydang = DateTime.Now.T;
            _productBusiness.Update(model);
            return model;
        }
        [Route("delete-bantin")]
        [HttpPost]
        public IActionResult DeleteProduct([FromBody] Dictionary<string, object> formData)
        {
            string idbantin = "";
            if (formData.Keys.Contains("idbantin") && !string.IsNullOrEmpty(Convert.ToString(formData["idbantin"]))) { idbantin = Convert.ToString(formData["idbantin"]); }
            _productBusiness.Delete(idbantin);
            return Ok();
        }
        //timkiem
        [Route("search-bantin")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tieude = "";
                if (formData.Keys.Contains("tieude") && !string.IsNullOrEmpty(Convert.ToString(formData["tieude"]))) { tieude = Convert.ToString(formData["tieude"]); }
                long total = 0;
                var data = _productBusiness.Search(page, pageSize, out total, tieude);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
        [Route("search-category")]
        [HttpPost]
        public ResponseModel SearchCategory([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string idtheloai = "";
                if (formData.Keys.Contains("idtheloai") && !string.IsNullOrEmpty(Convert.ToString(formData["idtheloai"]))) { idtheloai = Convert.ToString(formData["idtheloai"]); }
                long total = 0;
                var data = _productBusiness.SearchCategory(page, pageSize, out total, idtheloai);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
        [Route("get-new1")]
        [HttpGet]
        public IEnumerable<bangtin> GetDataNew1()
        {
            return _productBusiness.GetDataNew1();
        }
        [Route("get-new2")]
        [HttpGet]
        public IEnumerable<bangtin> GetDataNew2()
        {
            return _productBusiness.GetDataNew2();
        }
        [Route("get-new3")]
        [HttpGet]
        public IEnumerable<bangtin> GetDataNew3()
        {
            return _productBusiness.GetDataNew3();
        }
        [Route("get-new4")]
        [HttpGet]
        public IEnumerable<bangtin> GetDataNew4()
        {
            return _productBusiness.GetDataNew4();
        }
        [Route("get-new5")]
        [HttpGet]
        public IEnumerable<bangtin> GetDataNew5()
        {
            return _productBusiness.GetDataNew5();
        }
        [Route("get-newdoisong")]
        [HttpGet]
        public IEnumerable<bangtin> GetDataNewDoiSong()
        {
            return _productBusiness.GetDataNewDoiSong();
        }
        [Route("get-newdoisong1")]
        [HttpGet]
        public IEnumerable<bangtin> GetDataNewDoiSong1()
        {
            return _productBusiness.GetDataNewDoiSong1();
        }
        [Route("get-newdulich")]
        [HttpGet]
        public IEnumerable<bangtin> GetDataNewDuLich()
        {
            return _productBusiness.GetDataNewDuLich();
        }
        [Route("get-newthethao")]
        [HttpGet]
        public IEnumerable<bangtin> GetDataNewTheThao()
        {
            return _productBusiness.GetDataNewTheThao();
        }
        [Route("get-newphapluat")]
        [HttpGet]
        public IEnumerable<bangtin> GetDataNewPhapLuat()
        {
            return _productBusiness.GetDataNewPhapLuat();
        }
        [Route("get-newvieclam")]
        [HttpGet]
        public IEnumerable<bangtin> GetDataNewViecLam()
        {
            return _productBusiness.GetDataNewViecLam();
        }
        [Route("get-newgiaoduc")]
        [HttpGet]
        public IEnumerable<bangtin> GetDataNewGiaoDuc()
        {
            return _productBusiness.GetDataNewGiaoDuc();
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public bangtin GetDatabyID(int id)
        {
            
            return _productBusiness.GetDatabyID(id);
        }
        [Route("get-tuongtu/{id}")]
        [HttpGet]
        public IEnumerable<bangtin> Gettuongtu(int id)
        {
            return _productBusiness.Gettuongtu(id);
        }
        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
