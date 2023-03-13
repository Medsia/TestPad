
namespace LX.TestPad.Business.Services
{
    public static class ExceptionMessage
    {
        public static string SqlId { get; } = "Id cannot have a value of 0 or be negative";
        public static string PageNumber { get; } = "Page number cannot be 0 or negative";
        public static string TestPerPageCount { get; } = "Quantity of tests per page cannot be 0 or negative";
        public static string IsAnswersRelatedToOneQuestion { get; } = "Answer cannot be matched with question";
        public static string IsItemNull { get; } = "Entity, received from repository, is null. Entity type: ";
        public static string IsRequestAValidString { get; } = "Received string in null, empty or contains only whitespace characters";
    }
}
