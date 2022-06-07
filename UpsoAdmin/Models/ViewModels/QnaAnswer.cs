using System;

namespace UpsoApiData.Models.ViewModels
{
    public class QnaAnswer
    {
        public int PostId { get; set; }
        public string AnswerContent { get; set; }
        public bool IsAnswer { get; set; }
        public DateTime AnswerDate { get; set; }
    }
}
