namespace EzPos.Model
{
    /// <summary>
    /// Summary description for User.
    /// </summary>
    public class User
    {
        public const string CONST_USER_LOG_IN_NAME = "LogInName";
        public const string CONST_USER_ID = "UserID";
        public const string CONST_USER_LOG_IN = "LogInName";
        public const string CONST_USER_NAME = "UserName";

        public int UserID { get; set; }

        public string LogInName { get; set; }

        public string Password { get; set; }

        public string IDNumber { get; set; }

        public string UserName { get; set; }

        public int SexID { get; set; }

        public object BirthDate { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int PositionID { get; set; }

        public int MaritalStatusID { get; set; }

        public float BaseSalary { get; set; }

        public int ContractTypeID { get; set; }

        public object ContractStartDate { get; set; }
    }
}