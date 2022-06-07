using Microsoft.AspNetCore.Mvc;
using UpsoApiData.Models.ViewModels;
using UpsoApiService.Services;


namespace UpsoAdmin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public IAdminService _adminService;

        public AdminController(IAdminService admin)
        {
            _adminService = admin;
        }

        [HttpGet] //상품 전체 리스트
        public JsonResult GetGoodsList(int goodsid, int currentPage, int pagesize)
        {
            var goodsList = _adminService.GetGoodsList(goodsid, currentPage, pagesize);
            return new JsonResult(goodsList);
        }
        [HttpPost]//상품등록
        public JsonResult CreateGoods(GoodsInfo goodsInfo)
        {
            var result = _adminService.CreateGoods(goodsInfo);
            return new JsonResult(result);
        }
        [HttpPut]//상품 수정
        public JsonResult ModifyGoods(GoodsUpdateInfo updateInfo)
        {
            var result = _adminService.ModifyGoods(updateInfo);
            return new JsonResult(result);
        }
        [HttpDelete] //상품 삭제
        public JsonResult DeleteGoods(int goodsid)
        {
            var result = _adminService.DeleteGoods(goodsid);
            return new JsonResult(result);
        }
        [HttpPut]
        public JsonResult AnswerQna(QnaAnswer answer)
        {
            var result = _adminService.AnswerQna(answer);
            return new JsonResult(result);
        }
    }
}

