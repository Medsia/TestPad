
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
                throw new ArgumentOutOfRangeException("id", id, ExceptionMessage.SqlId);
        }
        public static void ListOfSQLKeyIdsCheck(List<int> ids)
        {
            if (ids.Any(id => id < 1))
                throw new ArgumentOutOfRangeException("ids", ids, ExceptionMessage.SqlId);
        }

        public static void PageNumberCheck(int pageNumber)
        {
            if (pageNumber < MinimalPageNumber)
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, ExceptionMessage.PageNumber);
        }
        public static void TestPerPageCountCheck(int count)
        {
            if (count < MinimalTestCount)
                throw new ArgumentOutOfRangeException("count", count, ExceptionMessage.TestPerPageCount);
        }
        public static void IsAnswersRelatedToOneQuestionCheck(int questionId, List<Answer> answers)
        {
            foreach (var answer in answers)
            {
                if (questionId != answer.QuestionId)
                    throw new ArgumentException(ExceptionMessage.IsAnswersRelatedToOneQuestion, "answers[i].QuestionId");
            }
        }
        public static void IsItemNullCheck<T>(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity", ExceptionMessage.IsItemNull + entity.GetType().ToString());
        }
        public static void IsRequestAValidString(string request)
        {
            if (string.IsNullOrWhiteSpace(request))
                throw new ArgumentException(ExceptionMessage.IsRequestAValidString, "request");
        }
    }
}
