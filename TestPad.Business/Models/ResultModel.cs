﻿using LX.TestPad.DataAccess.Entities;

namespace LX.TestPad.Business.Models
{
    public class ResultModel
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Email { get; set; }
        public double Score { get; set; }
        public bool IsCalculated { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
    }
}
