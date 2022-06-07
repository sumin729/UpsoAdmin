using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpsoApiData.Models
{
    public class Goods
    {
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public int GoodsCount { get; set; }
        public int GoodsCategory { get; set; }
        public int GoodsPrice { get; set; }
        public string GoodsDetail { get; set; }
        public string GoodsImage { get; set; }
        public string GoodsDate { get; set; }
        public string GoodsUpdateDate { get; set; }
    }
}
