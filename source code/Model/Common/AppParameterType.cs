namespace EzPos.Model.Common
{
    public class AppParameterType
    {
        public const string ConstParameterId = "ParameterTypeId";
        public const string ConstParameterLabel = "ParameterType";

        public int ParameterTypeId { get; set; }

        public string ParameterType { get; set; }

        public int IsActive { get; set; }
    }
}