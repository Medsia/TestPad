
using LX.TestPad.DataAccess.Entities;

namespace LX.TestPad.Business.Services
{
    public static class ExceptionChecker
    {
        private static int MinimalSQLKeyId = 1;
        private static int MinimalPageNumber = 1;
        private static int MinimalTestCount = 1;

        public static void SQLKeyIdCheck(int id)
        {
            if (id < MinimalSQLKeyId)
                throw new ArgumentOutOfRangeException("id", id, "Id cannot have a value of 0 or be negative.");
        }
        public static void ListOfSQLKeyIdsCheck(List<int> ids)
        {
            if (ids.Any(id => id < 1))
                throw new ArgumentOutOfRangeException("ids", ids, "Id cannot have a value of 0 or be negative.");
        }

        public static void PageNumberCheck(int pageNumber)
        {
            if (pageNumber < MinimalPageNumber)
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "Page number cannot be 0 or negative.");
        }
        public static void TestPerPageCountCheck(int count)
        {
            if (count < MinimalTestCount)
                throw new ArgumentOutOfRangeException("count", count, "Quantity of tests per page cannot be 0 or negative.");
        }
        public static void IsAnswersRelatedToOneQuestionCheck(int questionId, List<Answer> answers)
        {
            foreach (var answer in answers)
            {
                if (questionId != answer.QuestionId)
                    throw new ArgumentException("Answer cannot be matched with question.", "answers[i].QuestionId");
            }
        }
    }
}
