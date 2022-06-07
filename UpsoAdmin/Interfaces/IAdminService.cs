using UpsoApiData.Models.ViewModels;

namespace UpsoApiService.Services
{
    public interface IAdminService
    {
        //상품 조회 - 전체리스트 가져오기
        object GetGoodsList(int goodsid, int countPerPage, int currentPage);
        //상품등록
        object CreateGoods(GoodsInfo goodsInfo);
        //상품 삭제
        object DeleteGoods(int id);
        //상품 수정 
        object ModifyGoods(GoodsUpdateInfo updateInfo);
        //QNA답변
        object AnswerQna(QnaAnswer answer);


    }
}
