using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LX.TestPad.Business.Models
{
    public static class QuestionConstants
    {
        private const int firstQuestionNumber = 0;
        private const string questionNumberKey = "questionNumber";
        public static int FirstQuestionNumber
        {
            get { return firstQuestionNumber; }
        }
        public static string QuestionNumberKey
        {
            get { return questionNumberKey; }
        }
    }
}
