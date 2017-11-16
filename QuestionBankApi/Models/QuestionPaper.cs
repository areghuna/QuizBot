using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionBankApi.Models
{
    public class QuestionPaper
    {
        public int QuestionPaperId { get; set; }
        public string QuestionPaperName { get; set; }
        public string QuestionPaperDescription { get; set; }
        public List<Question> Questions { get; set; }
    }
}