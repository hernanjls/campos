namespace EzPos.Model
{
    public class AppParameterType
    {
        public const string CONST_PARAMETER_ID = "ParameterTypeID";
        public const string CONST_PARAMETER_LABEL = "ParameterType";

        public int ParameterTypeID { get; set; }

        public string ParameterType { get; set; }

        public int IsActive { get; set; }
    }
}