using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LX.TestPad.Business.Models
{
    public struct QuestionConstants
    {
        private const int firstQuestionNumber = 0;
        private const string questionNumberKey = "questionNumber";
        public int GetFirstQuestionNumber
        {
            get { return firstQuestionNumber; }
        }
        public string GetQuestionNumberKey
        {
            get { return questionNumberKey; }
        }
    }
}
