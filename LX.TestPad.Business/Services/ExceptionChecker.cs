﻿
using LX.TestPad.DataAccess.Entities;

namespace LX.TestPad.Business.Services
{
    public static class ExceptionChecker
    {
        private static int MinimalSQLKeyId = 1;
        private static int MinimalPageNumber = 1;
        private static int MinimalTestCount = 1;

        private static string SqlIdMessage = "Id cannot have a value of 0 or be negative";
        private static string PageNumberMessage = "Page number cannot be 0 or negative";
        private static string TestPerPageCountMessage = "Quantity of tests per page cannot be 0 or negative";
        private static string IsAnswersRelatedToOneQuestionMessage = "Answer cannot be matched with question";
        private static string IsItemNullMessage = "Entity, received from repository, is null. Entity type: ";
        private static string IsRequestAValidStringMessage = "Received string in null, empty or contains only whitespace characters";

        public static void SQLKeyIdCheck(int id)
        {
            if (id < MinimalSQLKeyId)
                throw new ArgumentOutOfRangeException("id", id, SqlIdMessage);
        }
        public static void ListOfSQLKeyIdsCheck(List<int> ids)
        {
            if (ids.Any(id => id < 1))
                throw new ArgumentOutOfRangeException("ids", ids, SqlIdMessage);
        }

        public static void PageNumberCheck(int pageNumber)
        {
            if (pageNumber < MinimalPageNumber)
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, PageNumberMessage);
        }
        public static void TestPerPageCountCheck(int count)
        {
            if (count < MinimalTestCount)
                throw new ArgumentOutOfRangeException("count", count, TestPerPageCountMessage);
        }
        public static void IsAnswersRelatedToOneQuestionCheck(int questionId, List<Answer> answers)
        {
            foreach (var answer in answers)
            {
                if (questionId != answer.QuestionId)
                    throw new ArgumentException(IsAnswersRelatedToOneQuestionMessage, "answers[i].QuestionId");
            }
        }
        public static void IsItemNullCheck<T>(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity", IsItemNullMessage + entity.GetType().ToString());
        }
        public static void IsRequestAValidString(string request)
        {
            if (string.IsNullOrWhiteSpace(request))
                throw new ArgumentException(IsRequestAValidStringMessage, "request");
        }
    }
}
