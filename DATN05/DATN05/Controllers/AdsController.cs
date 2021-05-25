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
    public class AdsController : ControllerBase
    {
        private iadsbll _adsBusiness;
        private string _path;
        public AdsController(iadsbll adsBusiness, IConfiguration configuration)
        {
            _adsBusiness = adsBusiness;
            _path = configuration["AppSettings:PATH"];
        }
        [Route("create-ads")]
        [HttpPost]
        public ads CreateAds([FromBody] ads model)
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

            _adsBusiness.Create(model);
            return model;
        }
        [Route("update-ads")]
        [HttpPost]
        public ads UpdateAds([FromBody] ads model)
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
            _adsBusiness.Update(model);
            return model;
        }
        [Route("delete-ads")]
        [HttpPost]
        public IActionResult DeleteProduct([FromBody] Dictionary<string, object> formData)
        {
            string idads = "";
            if (formData.Keys.Contains("idads") && !string.IsNullOrEmpty(Convert.ToString(formData["idads"]))) { idads = Convert.ToString(formData["idads"]); }
            _adsBusiness.Delete(idads);
            return Ok();
        }
        [Route("search-ads")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string noidung = "";
                if (formData.Keys.Contains("noidung") && !string.IsNullOrEmpty(Convert.ToString(formData["noidung"]))) { noidung = Convert.ToString(formData["noidung"]); }
                long total = 0;
                var data = _adsBusiness.Search(page, pageSize, out total, noidung);
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
        [Route("get-by-id/{id}")]
        [HttpGet]
        public ads GetDatabyID(int id)
        {

            return _adsBusiness.GetDatabyID(id);
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