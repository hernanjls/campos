namespace EzPos.Model
{
    public class AppParameterType
    {
        public const string CONST_PARAMETER_ID = "ParameterTypeID";
        public const string CONST_PARAMETER_LABEL = "ParameterType";

        private int _IsActive;
        private string _ParameterType;
        private int _ParameterTypeID;

        public int ParameterTypeID
        {
            get { return _ParameterTypeID; }
            set { _ParameterTypeID = value; }
        }

        public string ParameterType
        {
            get { return _ParameterType; }
            set { _ParameterType = value; }
        }

        public int IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
    }
}