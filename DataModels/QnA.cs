using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpsoApiData.Models
{
    public class QnA
    {
        public int PostId { get; set; }
        public string QnATitle { get; set; }
        public DateTime QnADate { get; set; }
        public int QnAType { get; set; }
        public string QnAContent { get; set; }
        public bool IsAnswer { get; set; }
        public string AnswerContent { get; set; }
        public string AnswerDate { get; set; }
        public string UserId { get; set; }
        public int GoodsId { get; set; }
    }
}
