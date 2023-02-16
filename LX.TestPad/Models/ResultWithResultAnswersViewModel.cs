using LX.TestPad.Business.Models;

namespace LX.TestPad.Models
{
    public class ResultWithResultAnswersViewModel
    {
        public ResultIncludeTestModel ResultModel { get; set; }
        public List<IGrouping<string, ResultAnswerModel>> ResultAnswerModels { get; set; }
    }
}
