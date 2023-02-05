namespace LX.TestPad.Business.Models
{
    public class ResultModel
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string UserName { get; set; }
        public double Score { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }

        public ResultModel()
        {

        }

        public ResultModel(int testId, string userName, double score, DateTime startesAt, DateTime finishedAt)
        {
            TestId = testId;
            UserName = userName;
            Score = score;
            StartedAt = startesAt;
            FinishedAt = finishedAt;
        }
    }
}
