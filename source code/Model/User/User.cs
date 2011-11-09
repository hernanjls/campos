using System;

namespace EzPos.Model.User
{
    public class User
    {
        public const string ConstUserLogInName = "LogInName";
        public const string ConstUserId = "UserId";

        public int UserId { get; set; }

        public string UserNumber { get; set; }

        public string UserName { get; set; }

        public int GenderId { get; set; }

        public string GenderStr { get; set; }

        public int CivilityId { get; set; }

        public string CivilityStr { get; set; }

        public int MaritalStatusId { get; set; }

        public string MaritalStatusStr { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhotoPath { get; set; }

        public int PositionId { get; set; }

        public string PositionStr { get; set; }

        public string PhoneNumber { get; set; }

        public int ContractId { get; set; }

        public string ContractStr { get; set; }

        public DateTime StartingDate { get; set; }

        public float Salary { get; set; }

        public string Address { get; set; }

        public string LogInName { get; set; }

        public string Password { get; set; }

        public string DefaultModule { get; set; }
    }
}