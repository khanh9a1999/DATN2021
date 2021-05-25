using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace DATN05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheLoaiController : ControllerBase
    {
        private itheloaibll _CategoryBusiness;
        public TheLoaiController(itheloaibll CategoryBusiness)
        {
            _CategoryBusiness = CategoryBusiness;
        }
        // GET: api/<LoaiController>
        [Route("get-category")]
        [HttpGet]
        public IEnumerable<theloai> GetAllCategory()
        {
            return _CategoryBusiness.GetData();
        }
        [Route("delete-category")]
        [HttpPost]
        public IActionResult DeleteCategory([FromBody] Dictionary<string, object> formData)
        {
            string idtheloai = "";
            if (formData.Keys.Contains("idtheloai") && !string.IsNullOrEmpty(Convert.ToString(formData["idtheloai"]))) { idtheloai = Convert.ToString(formData["idtheloai"]); }
            _CategoryBusiness.Delete(idtheloai);
            return Ok();
        }

        [Route("create-category")]
        [HttpPost]
        public theloai CreateCategory([FromBody] theloai model)
        {
            model.idtheloai = Guid.NewGuid().ToString();
            model.parent_maloai = "10";
            _CategoryBusiness.Create(model);
            return model;
        }

        [Route("update-category")]
        [HttpPost]
        public theloai UpdateCategory([FromBody] theloai model)
        {

            _CategoryBusiness.Update(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public theloai GetDatabyID(string id)
        {
            return _CategoryBusiness.GetDatabyID(id);
        }

        [Route("search-category")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tentheloai = "";
                if (formData.Keys.Contains("tentheloai") && !string.IsNullOrEmpty(Convert.ToString(formData["tentheloai"]))) { tentheloai = Convert.ToString(formData["tentheloai"]); }
                long total = 0;
                var data = _CategoryBusiness.Search(page, pageSize, out total, tentheloai);
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
    }
}
