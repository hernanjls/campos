namespace EzPos.Model.Common
{
    public class AppParameter
    {
        public const string ConstParameterId = "ParameterId";
        public const string ConstParameterLabel = "ParameterLabel";
        public const string ConstParameterValue = "ParameterValue";

        public int ParameterId { get; set; }

        public string ParameterCode { get; set; }

        public string ParameterLabel { get; set; }

        public string ParameterValue { get; set; }

        public int ParameterTypeId { get; set; }
    }
}