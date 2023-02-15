using LX.TestPad.Business.Models;

namespace LX.TestPad.Models
{
    public class ResultWithResultAnswersViewModel
    {
        public ResultIncludeTestModel resultModel { get; set; }
        public List<IGrouping<string, ResultAnswerModel>> resultAnswerModels { get; set; }
    }
}
