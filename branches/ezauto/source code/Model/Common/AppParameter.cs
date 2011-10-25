namespace EzPos.Model
{
    public class AppParameter
    {
        public const string CONST_PARAMETER_ID = "ParameterID";
        public const string CONST_PARAMETER_LABEL = "ParameterLabel";
        public const string CONST_PARAMETER_VALUE = "ParameterValue";

        public int ParameterID { get; set; }

        public string ParameterCode { get; set; }

        public string ParameterLabel { get; set; }

        public string ParameterValue { get; set; }

        public int ParameterTypeID { get; set; }
    }
}