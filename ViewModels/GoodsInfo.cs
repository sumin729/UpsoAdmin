using System;


namespace UpsoApiData.Models.ViewModels
{
    public class GoodsInfo //상품 등록
    {
       public int GoodsId { get; set; }
       public string GoodsName{get; set;}
       public int GoodsCount { get; set; }
       public int GoodsCategory { get; set; }
       public int GoodsPrice { get; set; }
       public string GoodsDetail { get; set; }
       public string GoodsImage { get; set; }
       public DateTime GoodsDate { get; set; }
       public DateTime GoodsUpdateDate { get; set; }
    }
}
