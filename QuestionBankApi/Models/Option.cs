using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionBankApi.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; }
        public bool isAnswer { get; set; }
    }
}