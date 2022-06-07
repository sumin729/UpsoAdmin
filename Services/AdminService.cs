using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Linq;
using UpsoApiData.Models;
using UpsoApiData.Models.ViewModels;


namespace UpsoApiService.Services
{
    public class AdminService : IAdminService
    {


        private readonly IConfiguration _configuration;
        public AdminService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private object CreateGoods(GoodsInfo goodsInfo)
        {
            string query = @"
                            INSERT INTO dbo.Goods
                            VALUES (@GoodsName, @GoodsCount, @GoodsCategory, @GoodsPrice, @GoodsDetail, @GoodsImage, GETDATE(), GETDATE())
                            ";
            string sqlDataSource = _configuration.GetConnectionString("UpsoCon");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                var result = myCon.Execute(query, goodsInfo);
                myCon.Close();
                if (result == 0)
                {
                    return result;
                }
                return "상품을 성공적으로 등록하였습니다.";
            }
        }
        private object DeleteGoods(int id)
        {
            string query = @"
                            DELETE FROM dbo.Goods
                            WHERE GoodsId = @GoodsId
                            ";
            string sqlDataSource = _configuration.GetConnectionString("UpsoCon");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                var result = myCon.Execute(query, new { GoodsId = id });
                myCon.Close();
                if (result == 0)
                {
                    return result;
                }
                return "상품을 성공적으로 삭제하였습니다.";
            }
        }
        private object ModifyGoods(GoodsUpdateInfo updateInfo)
        {
            string query = @"
                            UPDATE dbo.Goods
                            SET GoodsName = @GoodsName, GoodsCount = @GoodsCount, GoodsCategory = @GoodsCategory, GoodsPrice = @GoodsPrice, GoodsDetail = @GoodsDetail,  GoodsImage = @GoodsImage, GoodsUpdateDate = GetDate()
                            WHERE GoodsId = @GoodsId
                            ";
            string sqlDataSource = _configuration.GetConnectionString("UpsoCon");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                var result = myCon.Query(query, updateInfo);
                myCon.Close();
                if (result == null)
                {
                    return result;
                }
                return "상품을 성공적으로 수정하였습니다.";
            };
        }
        //상품리스트 불러오기
        private object GetGoodsList(int goodsid, int currentPage, int pagesize)
        {
            PageNation pagination = new PageNation();

            int skip = (currentPage - 1) * pagesize;
            int take = pagesize;
            int totalCount = GetGoodsTotalCount(goodsid);
            pagination.totalCount = totalCount;
            pagination.countPerPage = take;
            pagination.startPageNo = 1;
            pagination.endPageNo = (int)Math.Ceiling((double)totalCount / pagesize);
            pagination.currentPage = currentPage;

            string query = "SELECT Goodsid, GoodsName, GoodsCategory, GoodsCount, GoodsPrice, GoodsImage, GoodsDetail, GoodsDate, GoodsUpdateDate from dbo.Goods order by Goodsid desc OFFSET @Skip Rows FETCH NEXT @Take ROWS ONLY";

            string sqlDataSource = _configuration.GetConnectionString("UpsoCon");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                var result = myCon.Query<Goods>(query, new { GoodsId = goodsid, Skip = skip, Take = take }).ToList();
                myCon.Close();
                return new { pagination = pagination, goods = result };
            }
        }


        //Pagination totalCount 가져오기
        private int GetGoodsTotalCount(int goodsid)
        {
            string query = @"select Count(*) as totalCount from dbo.Goods";

            string sqlDataSource = _configuration.GetConnectionString("UpsoCon");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                var result = myCon.Query(query).FirstOrDefault();
                myCon.Close();
                if (result == null)
                {
                    return 0;
                }
                return result.totalCount;
            }
        }
       
        private object AnswerQnA(QnaAnswer answer)
        {
            string query = @"
                            UPDATE dbo.QnA SET AnswerContent = @AnswerContent, IsAnswer = 1, AnswerDate = GetDate()
                            WHERE PostId = @PostId 
                            ";
            string sqlDataSource = _configuration.GetConnectionString("UpsoCon");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                var result = myCon.Query<QnA>(query, answer);
                myCon.Close();     
                if (result == null)
                {
                    return result;
                }
                return "QnA답변이 성공적으로 등록되었습니다.";
            }
        }

        object IAdminService.GetGoodsList(int goodsid, int currentPage, int pagesize)
        {
            return GetGoodsList(goodsid, currentPage, pagesize);
        }



        object IAdminService.CreateGoods(GoodsInfo goodsInfo)
        {
            return CreateGoods(goodsInfo);
        }

        object IAdminService.DeleteGoods(int id)
        {
            return DeleteGoods(id);
        }

        object IAdminService.ModifyGoods(GoodsUpdateInfo updateInfo)
        {
            return ModifyGoods(updateInfo);
        }

        object IAdminService.AnswerQna(QnaAnswer answer)
        {
            return AnswerQnA(answer);
        }
    }
}
