using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionBankApi.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }

        public List<Option> Options { get; set; }

        public string Explanation { get; set; }
    }
}