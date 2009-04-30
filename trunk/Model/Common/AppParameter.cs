namespace EzPos.Model
{
    public class AppParameter
    {
        public const string CONST_PARAMETER_ID = "ParameterID";
        public const string CONST_PARAMETER_LABEL = "ParameterLabel";
        public const string CONST_PARAMETER_VALUE = "ParameterValue";

        private string _ParameterCode;
        private int _ParameterID;
        private string _ParameterLabel;
        private int _ParameterTypeID;
        private string _ParameterValue;

        public int ParameterID
        {
            get { return _ParameterID; }
            set { _ParameterID = value; }
        }

        public string ParameterCode
        {
            get { return _ParameterCode; }
            set { _ParameterCode = value; }
        }

        public string ParameterLabel
        {
            get { return _ParameterLabel; }
            set { _ParameterLabel = value; }
        }

        public string ParameterValue
        {
            get { return _ParameterValue; }
            set { _ParameterValue = value; }
        }

        public int ParameterTypeID
        {
            get { return _ParameterTypeID; }
            set { _ParameterTypeID = value; }
        }
    }
}