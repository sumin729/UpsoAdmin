using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpsoApiData.Models.ViewModels
{
    public class GoodsUpdateInfo
    {
        public int GoodsId { get; set; }   
        public string GoodsName { get; set; }
        public int GoodsCount { get; set; }
        public int GoodsCategory { get; set; }
        public int GoodsPrice { get; set; }
        public string GoodsDetail { get; set; }
        public string GoodsImage { get; set; }
        public DateTime GoodsUpdateDate { get; set; }
    }
}
