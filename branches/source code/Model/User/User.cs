using System;

namespace EzPos.Model
{
    public class User
    {
        public const string CONST_USER_LOG_IN_NAME = "LogInName";
        public const string CONST_USER_ID = "UserID";

        public int UserID { get; set; }

        public string UserNumber { get; set; }

        public string UserName { get; set; }

        public int GenderID { get; set; }

        public string GenderStr { get; set; }

        public int CivilityID { get; set; }

        public string CivilityStr { get; set; }

        public int MaritalStatusID { get; set; }

        public string MaritalStatusStr { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhotoPath { get; set; }

        public int PositionID { get; set; }

        public string PositionStr { get; set; }

        public string PhoneNumber { get; set; }

        public int ContractID { get; set; }

        public string ContractStr { get; set; }

        public DateTime StartingDate { get; set; }

        public float Salary { get; set; }

        public string Address { get; set; }

        public string LogInName { get; set; }

        public string Password { get; set; }

        public string DefaultModule { get; set; }
    }
}