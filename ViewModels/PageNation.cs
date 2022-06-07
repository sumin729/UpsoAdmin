using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpsoApiData.Models.ViewModels
{
    public class PageNation
    {
        public int totalCount { get; set; }
        public int countPerPage { get; set; }
        public int startPageNo { get; set; }
        public int endPageNo { get; set; }
        public int currentPage { get; set; }
    }
}
