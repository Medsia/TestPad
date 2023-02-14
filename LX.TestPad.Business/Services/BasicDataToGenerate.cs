using LX.TestPad.Business.Models;

namespace LX.TestPad.Controllers
{
    public static class BasicDataToGenerate
    {
        public const string QuestionText = "Some question text";
        public static AnswerModel Answer { get; } = new AnswerModel { Text = "Some answer text", IsCorrect = true };

    }
}
